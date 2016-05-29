namespace CodeGen
open System.Collections.Generic
open System.Text.RegularExpressions
open System.Text
open System
open CodeGen.Common
open CodeGen.Parse
module Record =

    type ParsedField = 
        { Name : string; Type : Type'}
        member __.TypeName = toValidName __.Type        
    type ParsedRecord =
        { Type : Type' ; Fields : ParsedField array }
        member __.ClassName = toValidName __.Type 

    let recordParser str = 
        toResult' parseRecord str
        |> mapResult (fun recordDef ->
            let typeDef , fieldList = recordDef
            let type' = 
                match typeDef with
                | BasicTypeDef name -> BasicType name
                | GenericTypeDef (name, params') -> GenericType (name, List.map GenericTypeParam params'  )                
            let fields' = fieldList |> List.map (fun (name', type') -> { Name = name'; Type = type'}) |> List.toArray
            { Type = type' ; Fields = fields' }
            )
        

    

    let generateCode parsedRecord =
         let {Fields = fields} = parsedRecord
         let className = parsedRecord.ClassName
         let ctorDef =
            let pureClassName =  (new Regex("^(?<pureClassName>\\w+)")).Match(className).Groups.["pureClassName"].Value
            let ctorArgs = String.Join(", " , fields |> Array.map(fun s -> s.TypeName + " " + firstLetterLowerCase(s.Name)))
            let ctorDecl = String.Format("public {0}({1})", pureClassName,ctorArgs)
            let ctorBody = String.Join(Environment.NewLine,  fields |> Array.map(fun s -> firstLetterUpperCase(s.Name) + " = " + firstLetterLowerCase(s.Name) + ";"))
            methodBuilder ctorDecl ctorBody
         let statiCtorDef =
            let args = String.Join(", " , fields |> Array.map(fun s -> s.TypeName + " " + firstLetterLowerCase(s.Name)))
            let methodDecl = String.Format("public static {0} New({1})", className, args)
            let ctorParams = String.Join(", " , fields |> Array.map(fun s -> firstLetterLowerCase(s.Name)))
            let methodBody = String.Format("return new {0}({1});", className, ctorParams)
            methodBuilder methodDecl methodBody
  
         let propsDef = 
            String.Join(Environment.NewLine,fields |> Array.map(fun s -> String.Format("public {0} {1} {{get; private set;}}", s.TypeName , s.Name)))
   
         let ``int GetHashCode()`` =
            let hashKey = -1640531527
            let hash = 0;
            let methodDecl = "public sealed override int GetHashCode()"
            let methodBody =
                let hashRow (propName : string) =  String.Format("num = -1640531527 + ((({0} == null) ? 0 : {0}.GetHashCode()) + ((num << 6) + (num >> 2)));", propName)
                let strBuilder = new StringBuilder()
                strBuilder.AppendLine("int num = 0;") |> ignore
                fields
                |> Seq.map(fun s -> hashRow s.Name)
                |> Seq.iter (fun s -> strBuilder.AppendLine(s) |> ignore)
                strBuilder.Append("return num;") |> ignore
                strBuilder.ToString()
            methodBuilder methodDecl methodBody
     

         let ``==(T o1, T o2)`` =
            let methodDecl =  String.Format("public static bool operator ==({0} o1, {0} o2)", className) 
            let methodBody =            
                let strBuilder = new StringBuilder()
                strBuilder.AppendLine("return (object)o1 == null ? (object)o2 == null :  o1.Equals(o2);") |> ignore
                strBuilder.ToString();
            methodBuilder methodDecl methodBody

         let ``!=(T o1, T o2)`` =
            let methodDecl =  String.Format("public static bool operator !=({0} o1, {0} o2)", className) 
            let methodBody =            
                let strBuilder = new StringBuilder()
                strBuilder.AppendLine("return !(o1 == o2);") |> ignore
                strBuilder.ToString();
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
            let methodDecl = String.Format("public bool Equals({0} obj)", className)
            let methodBody =
                let nullCheck =  [| "return ((object)obj != null)"|]
                let propsCompares =  fields |> Array.map (fun f -> String.Format("StructuralComparisons.StructuralEqualityComparer.Equals({1}, obj.{1})", f.TypeName, f.Name))  
                String.Join(Environment.NewLine + String(' ',7) + "&& ", Array.concat [|nullCheck; propsCompares|]) + ";"
            methodBuilder methodDecl methodBody

         let ``bool Equals(object obj, IEqualityComparer comp)`` = 
            let methodDecl = "public bool Equals(object obj, IEqualityComparer comp)"
            let methodBody = 
                let castCheck = 
                    let l1 = String.Format("var target = obj as {0};", className);
                    let l2 = "if((object)target == null) return false;"
                    l1 + Environment.NewLine + l2
                castCheck
            methodBuilder methodDecl methodBody
     
         let ``bool Equals(T obj) v2`` = 
            let methodDecl = String.Format("public bool Equals({0} obj)", className)
            let methodBody =
                let nullCheck =  [| "return ((object)obj != null)"|]
                let propsCompares =  fields |> Array.map (fun f -> String.Format("{1} is IStructuralEquatable ? (StructuralComparisons.StructuralEqualityComparer.Equals({1}, obj.{1})) : EqualityComparer<{0}>.Default.Equals({1}, obj.{1})", f.TypeName, f.Name))  
                String.Join(Environment.NewLine + String(' ',7) + "&& ", Array.concat [|nullCheck; propsCompares|]) + ";"
            methodBuilder methodDecl methodBody

         let ``bool Equals(T obj) v1`` = 
            let methodDecl = String.Format("public bool Equals({0} obj)", className)
            let methodBody =
                let nullCheck =  [| "return ((object)obj != null)"|]
                let propsCompares =  fields |> Array.map (fun f -> String.Format("EqualityComparer<{0}>.Default.Equals({1}, obj.{1})", f.TypeName, f.Name))  
                String.Join(" && ", Array.concat [|nullCheck; propsCompares|]) + ";"
            methodBuilder methodDecl methodBody

         let withStatement = 
            let methodArgs = String.Join(", " , fields |> Array.map(fun s -> System.String.Format("WellTyped.Prelude.OptionalParam<{0}> {1} = default(WellTyped.Prelude.OptionalParam<{0}>)", s.TypeName, firstLetterLowerCase(s.Name))))
            let methodDecl = String.Format("public {0} With({1})", className, methodArgs)
            let methodBody =
                let insertArgs = String.Join(", " , fields |> Array.map(fun s -> System.String.Format("{0}.HasValue ? {0}.Value : this.{1} ", firstLetterLowerCase(s.Name), firstLetterUpperCase(s.Name))))
                sprintf "return new %s(%s);" className insertArgs
            methodBuilder methodDecl methodBody

         let strBuilder = new StringBuilder()
         strBuilder.AppendLine(String.Format("public sealed partial class {0} : IEquatable<{0}>", className)) |> ignore
         strBuilder.AppendLine("{") |> ignore
         strBuilder.AppendLine(addTabs ctorDef 1) |> ignore
         strBuilder.AppendLine()|> ignore
         strBuilder.AppendLine(addTabs propsDef 1)|> ignore
         strBuilder.AppendLine()|> ignore
         strBuilder.AppendLine(addTabs statiCtorDef 1)|> ignore
         strBuilder.AppendLine()|> ignore
         strBuilder.AppendLine(addTabs ``bool Equals(Object obj)`` 1)|> ignore
         strBuilder.AppendLine()|> ignore
         strBuilder.AppendLine(addTabs ``bool Equals(T obj)`` 1)|> ignore
         strBuilder.AppendLine()|> ignore
         strBuilder.AppendLine(addTabs ``int GetHashCode()`` 1)|> ignore
         strBuilder.AppendLine()|> ignore
         strBuilder.AppendLine(addTabs ``==(T o1, T o2)`` 1)|> ignore
         strBuilder.AppendLine()|> ignore
         strBuilder.AppendLine(addTabs ``!=(T o1, T o2)`` 1)|> ignore
         strBuilder.AppendLine() |> ignore
         strBuilder.AppendLine(addTabs withStatement 1) |> ignore
         strBuilder.AppendLine("}") |> ignore
         strBuilder.ToString()

    let Generate(s : String) =
        match recordParser s |> mapResult generateCode with
            | Success code -> code
            | Error error -> raise(Exception(error))
