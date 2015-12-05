namespace CodeGen
open System.Collections.Generic
open System.Text.RegularExpressions
open System.Text
open System
open CodeGen.Parse
module Common =
    type Result<'a> = 
        | Success of 'a
        | Error of string

    let toResult' p str =
        match FParsec.CharParsers.run p str with
        | FParsec.CharParsers.Success(result, _, _)   -> Success result
        | FParsec.CharParsers.Failure(errorMsg, _, _) -> Error errorMsg

    let getValue (group : System.Text.RegularExpressions.Group) = 
        match group.Success with
        | true -> Some group.Value
        | _ -> None

    let toResult error opt =
        match opt with
            | Some v -> Success v
            | _ -> Error error


    let bindOpt (f : 'a -> 'b option) (opt : 'a option) = 
        match opt with
            | Some v -> f(v)
            | _ -> None

    let bindResult (f : 'a -> 'b Result) (r : 'a Result)  = 
        match r with
            | Success v -> f(v)
            | Error error -> Error error

    let mapResult (f : 'a -> 'b) (r : 'a Result)  = 
        match r with
            | Success v -> Success (f v)
            | Error error -> Error error



    let aggregateResults (rSeq : 'a Result seq) =
        let aggregator state' r' =
            match (state', r') with
            | (Success state, Success r) -> Success (Array.concat [|state; [|r|]|])
            | (Success state, Error error) -> Error error
            | (Error stateError, Error error) -> Error (stateError + "\r\n" +  error)
            | (Error stateError, _) -> Error stateError
        rSeq |> Seq.fold aggregator (Success [||])
 
    let firstLetterLowerCase (s : String) = s.[0].ToString().ToLower() + s.Substring(1)     
    let firstLetterUpperCase (s : String) = s.[0].ToString().ToUpper() + s.Substring(1)


    let rec toValidName  = function  
        | BasicType s -> s
        | GenericTypeParam c -> c.ToString().ToUpper()
        | GenericType (baseType, pt) ->
            if baseType = "[]"
            then (pt |> List.map toValidName |> Seq.head) + "[]"
            else  baseType + "<" + String.Join(",", pt |> List.map toValidName)  + ">"

    let addTabs (s : String) count = 
        let tabs = new String('\t', count)
        let splitter = [|Environment.NewLine|]
        String.Join(Environment.NewLine, s.Split(splitter, StringSplitOptions.None) |> Seq.map( fun s -> if String.IsNullOrEmpty(s) then s else tabs + s))
   
    let methodBuilder methodDecl methodBody =
            let strBuilder = new StringBuilder()
            strBuilder.AppendLine(methodDecl)|> ignore
            strBuilder.AppendLine("{")|> ignore
            strBuilder.AppendLine(addTabs methodBody 1) |> ignore
            strBuilder.AppendLine("}")|> ignore
            strBuilder.ToString()

