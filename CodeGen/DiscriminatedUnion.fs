namespace CodeGen
open System.Collections.Generic
open System.Text.RegularExpressions
open System.Text
open System
open CodeGen.Common
open CodeGen.Parse
module DiscriminatedUnion = 
    type UnNamedProp = 
        { Type : Type'}
        member __.TypeName = toValidName __.Type      
    type NamedProp = 
        { Name : string; Type : Type'}
        member __.TypeName = toValidName __.Type 
         
    type ParsedProp = 
        | UnNamedProp of UnNamedProp
        | NamedProp of NamedProp
        member this.TypeName = 
            match this with
            | UnNamedProp p -> p.TypeName
            | NamedProp p -> p.TypeName        


    type ParsedDuCaseType =
         | Singleton of Name : string
         | Class of Name : string * Props : NamedProp array  
         member this.CaseName = 
            match this with
            | Singleton name -> name
            | Class (name,_) -> name

    type ParsedDU =
        { Type : Type' ; Cases : ParsedDuCaseType array }
        member __.ClassName = toValidName __.Type
        member __.CtorName = 
            match __.Type with
            | BasicType name -> name
            | GenericType (name ,_) -> name 
            | GenericTypeParam _ -> failwith "GenericTypeParam cannot be typeDef"

    let duParse (str : string)  =
        toResult' parseDU str
        |> mapResult (fun duDef ->
            let typeDef , cases = duDef
            let type' = 
                match typeDef with
                | BasicTypeDef name -> BasicType name
                | GenericTypeDef (name, params') -> GenericType (name, List.map GenericTypeParam params'  )                
            let cases' =
                cases
                |> List.map (fun (name', body) ->
                    match body with
                    | Some fields ->
                        let fields' = 
                            fields 
                            |> List.map (fun (fname, ftype) -> { Name =fname ; Type = ftype})
                            |> List.toArray
                        Class(name', fields')
                    | None -> Singleton name'
                    )
                |> List.toArray
            { Type = type' ; Cases = cases' }
            )

    let generateCaseClass unionClassName tag caseClass =
        let singletonClassDef className =  
            String.Format("public sealed class {0} : {1} {{ internal {0}(): base({2}){{}}}}", className, unionClassName,tag)
        let classDef (className : string) (props : NamedProp array) =
            let ctorDef =
                let ctorArgs = String.Join(", " , props |> Array.map(fun s -> s.TypeName + " " + firstLetterLowerCase(s.Name)))
                let ctorDecl = String.Format("internal {0}({1}) : base({2})", className,ctorArgs, tag)
                let ctorBody = String.Join(Environment.NewLine,  props |> Array.map(fun s -> firstLetterUpperCase(s.Name) + " = " + firstLetterLowerCase(s.Name) + ";"))
                methodBuilder ctorDecl ctorBody

            let propsDef = 
                String.Join(Environment.NewLine,props |> Array.map(fun s -> String.Format("public {0} {1} {{get; private set;}}", s.TypeName , s.Name)))

            let strBuilder = new StringBuilder()
            strBuilder.AppendLine(String.Format("public sealed class {0} : {1}", className, unionClassName)) |> ignore
            strBuilder.AppendLine("{") |> ignore
            strBuilder.AppendLine(addTabs ctorDef 1) |> ignore
            strBuilder.AppendLine()|> ignore
            strBuilder.AppendLine(addTabs propsDef 1)|> ignore
            strBuilder.AppendLine("}") |> ignore
            strBuilder.ToString()    
        
        match caseClass with
        | Singleton name -> singletonClassDef name
        | Class (name,props) -> classDef name props

    let generateCaseStaticCtors unionClassName = function
        | Singleton className -> 
            let uniqueFildName = String.Format("_unique_{0}", className)
            let l1 = String.Format("private static readonly {0} {1} = new {2}();", unionClassName, uniqueFildName, className)
            let l2 =  String.Format("public static {0} {2}Instance {{ get {{ return {1}; }}}}", unionClassName, uniqueFildName, className)
            String.Join(Environment.NewLine, [|l1;l2|])
        | Class (className, props) -> 
            let args = String.Join(", " , props |> Array.map(fun s -> s.TypeName + " " + firstLetterLowerCase(s.Name)))
            let methodDecl = String.Format("public static {0} New{1}({2})", unionClassName, className, args)
            let ctorParams = String.Join(", " , props |> Array.map(fun s -> firstLetterLowerCase(s.Name)))
            let methodBody = String.Format("return new {0}({1});", className, ctorParams)
            methodBuilder methodDecl methodBody

    let caseClassHashCode tag  =  function 
      | Singleton className ->  sprintf "return %d;" tag
      | Class (className, props) ->     
            let directVarName = sprintf "direct%d" tag
            let numVarname = sprintf "num%d" tag       
            let hashRow (propName : string) =  String.Format("{0} = -1640531527 + ((({1}.{2} == null) ? 0 : {1}.{2}.GetHashCode()) + (({0} << 6) + ({0} >> 2)));",numVarname,directVarName, propName)
            let strBuilder = new StringBuilder()
            strBuilder.AppendLine(sprintf "int %s = %d;" numVarname tag) |> ignore
            strBuilder.AppendLine(sprintf "var %s = (%s)this;" directVarName className) |> ignore
            props
            |> Seq.map(fun s -> hashRow s.Name)
            |> Seq.iter (fun s -> strBuilder.AppendLine(s) |> ignore)
            strBuilder.Append(sprintf "return %s;" numVarname) |> ignore
            strBuilder.ToString()

    let caseClassEquality tag objVarName = function
        | Singleton _ -> "return true;"
        | Class (className, props) ->
            let direct1VarName = sprintf "direct%d_1" tag
            let direct2VarName = sprintf "direct%d_2" tag
            let l1 = sprintf "var %s = (%s)this;" direct1VarName className
            let l2 = sprintf "var %s = (%s)%s;" direct2VarName className objVarName
            let propsEqs =  props |> Array.map (fun f -> String.Format("StructuralComparisons.StructuralEqualityComparer.Equals({0}.{2}, {1}.{2})", direct1VarName,direct2VarName, f.Name))  
            let eqString = String.Join(Environment.NewLine + String(' ',7) + "&& ", propsEqs)
            String.Join(Environment.NewLine, [|l1;l2; "return " + eqString + ";"|])

    let generateCode (du : ParsedDU) = 
        let { Type = duTypeDef ; Cases  = duCases} = du
        let className = du.ClassName

        let staticCtroDef = 
            let methodDecl = String.Format("static {0}()", du.CtorName)
            let methodBody = ""
            methodBuilder methodDecl methodBody

        let ctorDef =
            let ctorDecl = String.Format("internal {0}(int tag)", du.CtorName)
            let ctorBody = "Tag = tag;"
            methodBuilder ctorDecl ctorBody

        let caseClasses = 
            String.Join(Environment.NewLine, duCases|> Array.mapi (generateCaseClass className))
        let caseClassStaticCtors = 
            String.Join(Environment.NewLine, duCases|> Array.map (generateCaseStaticCtors className))

        let ``int GetHashCode()`` =
                let methodDecl = "public sealed override int GetHashCode()"
                let methodBody =
                    let strBuilder = new StringBuilder()
                    strBuilder.AppendLine(String.Format("switch(this.Tag)", className)) |> ignore
                    strBuilder.AppendLine("{") |> ignore  
                    duCases
                    |> Array.iteri(fun tag caseClass -> 
                        strBuilder.AppendLine(addTabs (sprintf "case %d:" tag) 1) |> ignore
                        strBuilder.AppendLine(addTabs (caseClassHashCode tag caseClass) 2) |> ignore
                    )
                    strBuilder.AppendLine("}") |> ignore  
                    strBuilder.AppendLine("return 0;") |> ignore  
                    strBuilder.ToString()
                methodBuilder methodDecl methodBody
     
        let ``bool Equals(Object obj)`` =
            let methodDecl = "public sealed override bool Equals(object obj)"
            let methodBody =            
                let strBuilder = new StringBuilder()
                strBuilder.AppendLine(String.Format("var o = obj as {0};", className)) |> ignore
                strBuilder.AppendLine("return ((object)o != null) && this.Equals(o);") |> ignore
                strBuilder.ToString();
            methodBuilder methodDecl methodBody
        
        let ``bool Equals(T obj)`` = 
            let objVarName = "obj"
            let methodDecl = String.Format("public bool Equals({0} {1})", className, objVarName)
            let methodBody =
                let switchBlock = 
                    let strBuilder = new StringBuilder()
                    strBuilder.AppendLine(String.Format("switch(this.Tag)", className)) |> ignore
                    strBuilder.AppendLine("{") |> ignore 
                    duCases
                    |> Array.iteri(fun tag caseClass -> 
                        strBuilder.AppendLine(addTabs (sprintf "case %d:" tag) 1) |> ignore
                        strBuilder.AppendLine(addTabs (caseClassEquality tag objVarName caseClass) 2) |> ignore
                    )
                    strBuilder.AppendLine("}") |> ignore
                    strBuilder.ToString()  
                let strBuilder = new StringBuilder()
                strBuilder.AppendLine(sprintf "if ((object)%s == null) return false;" objVarName) |> ignore  
                strBuilder.AppendLine(sprintf "if(this.Tag == %s.Tag)" objVarName) |> ignore
                strBuilder.AppendLine("{") |> ignore
                strBuilder.AppendLine(addTabs switchBlock 1) |> ignore
                strBuilder.AppendLine("}") |> ignore  
                strBuilder.AppendLine("return false;") |> ignore  
                strBuilder.ToString()
            methodBuilder methodDecl methodBody   

        let ``==(T o1, T o2)`` =
            let methodDecl =  String.Format("public static bool operator ==({0} o1, {0} o2)", className) 
            let methodBody =            
                let strBuilder = new StringBuilder()
                strBuilder.AppendLine("return ((object)o1 != null) && o1.Equals(o2);") |> ignore
                strBuilder.ToString();
            methodBuilder methodDecl methodBody

        let ``!=(T o1, T o2)`` =
            let methodDecl =  String.Format("public static bool operator !=({0} o1, {0} o2)", className) 
            let methodBody =            
                let strBuilder = new StringBuilder()
                strBuilder.AppendLine("return !(o1 == o2);") |> ignore
                strBuilder.ToString();
            methodBuilder methodDecl methodBody    


        let matchFunctions =
            let actionMatch = 
                let args = String.Join(", ",  duCases |> Array.mapi(fun i x -> sprintf "Action<%s> a%d" x.CaseName i))
                let methodDecl = sprintf "public void Match(%s)" args
                let methodBody =             
                    let strBuilder = new StringBuilder()
                    strBuilder.AppendLine(String.Format("switch(this.Tag)", className)) |> ignore
                    strBuilder.AppendLine("{") |> ignore 
                    duCases
                    |> Array.iteri(fun tag caseClass -> 
                        strBuilder.AppendLine(addTabs (sprintf "case %d:" tag) 1) |> ignore
                        strBuilder.AppendLine(addTabs (sprintf "a%d((%s)this);return;" tag caseClass.CaseName) 2) |> ignore
                    )
                    strBuilder.AppendLine("}") |> ignore
                    strBuilder.AppendLine("""throw new Exception("Matching failed");""") |> ignore
                    strBuilder.ToString()  
                methodBuilder methodDecl methodBody
            let funcMatch = 
                let args = String.Join(", ",  duCases |> Array.mapi(fun i x -> sprintf "Func<%s,TR> f%d" x.CaseName i))
                let methodDecl = sprintf "public TR Match<TR>(%s)" args
                let methodBody =             
                    let strBuilder = new StringBuilder()
                    strBuilder.AppendLine(String.Format("switch(this.Tag)", className)) |> ignore
                    strBuilder.AppendLine("{") |> ignore 
                    duCases
                    |> Array.iteri(fun tag caseClass -> 
                        strBuilder.AppendLine(addTabs (sprintf "case %d:" tag) 1) |> ignore
                        strBuilder.AppendLine(addTabs (sprintf "return f%d((%s)this);" tag caseClass.CaseName) 2) |> ignore
                    )
                    strBuilder.AppendLine("}") |> ignore
                    strBuilder.AppendLine("""throw new Exception("Matching failed");""") |> ignore
                    strBuilder.ToString()  
                methodBuilder methodDecl methodBody
            String.Join(Environment.NewLine, [|actionMatch; funcMatch|])
             
        let strBuilder = new StringBuilder()
        strBuilder.AppendLine(String.Format("public partial class {0} : IEquatable<{0}>", className)) |> ignore
        strBuilder.AppendLine("{") |> ignore
        strBuilder.AppendLine(addTabs staticCtroDef 1)|> ignore   
        strBuilder.AppendLine(addTabs ctorDef 1)|> ignore
        strBuilder.AppendLine(addTabs "public int Tag {get; private set;}" 1)|> ignore
        strBuilder.AppendLine(addTabs caseClasses 1)|> ignore
        strBuilder.AppendLine(addTabs ``int GetHashCode()`` 1) |> ignore
        strBuilder.AppendLine(addTabs ``bool Equals(Object obj)`` 1) |> ignore
        strBuilder.AppendLine(addTabs ``bool Equals(T obj)`` 1) |> ignore
        strBuilder.AppendLine()|> ignore
        strBuilder.AppendLine(addTabs ``==(T o1, T o2)`` 1)|> ignore
        strBuilder.AppendLine()|> ignore
        strBuilder.AppendLine(addTabs ``!=(T o1, T o2)`` 1)|> ignore
        strBuilder.AppendLine(addTabs caseClassStaticCtors 1)|> ignore
        strBuilder.AppendLine(addTabs matchFunctions 1)|> ignore
        strBuilder.AppendLine("}") |> ignore
        strBuilder.ToString()

module DU =
    open DiscriminatedUnion 
    let Generate(s : String) = 
        match duParse s |> mapResult generateCode with
            | Success code -> code
            | Error error -> raise(Exception(error))
