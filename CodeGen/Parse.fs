// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

namespace CodeGen
module Parse = 
    open FParsec
    open FParsec.CharParsers
    open FParsec.Primitives
    open FParsec.Error

    let test p str =
        match run p str with
        | Success(result, _, _)   -> printfn "Success: %A" result
        | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg

    type GenericTypeParam' = char
    type BasicType' = string
    and Type' =
        | GenericTypeParam of GenericTypeParam'
        | BasicType of BasicType'
        | GenericType of BasicType' * Type' list

    type TypeDef =
        | BasicTypeDef of BasicType'
        | GenericTypeDef of BasicType' * GenericTypeParam' list

    type FieldDef = string * Type'

    type TypeDecl =
        | RecordType of TypeDef * FieldDef list
        | DiscriminatedUnion

    let str = pstring
    let ws' = many (pchar ' ') 
    let ws = spaces
    let pchar' c = between  ws' ws' (pchar c) 
    let genericTypeParam': Parser<GenericTypeParam',_>   = pchar ''' >>. letter
    let parseFieldName   : Parser<string,_> = many1Chars (letter <|> pchar '_')
    let parseBasicType   : Parser<BasicType',_> = many1Chars letter
    let parseGeneric' paramParser =  parseBasicType .>>. opt ((pchar '<') >>. sepBy1 paramParser (pchar ',') .>> (pchar '>'))
    let parseType' : Parser<Type',_>  = 
        let type', typeRef = createParserForwardedToRef<Type', _>() 
        let genericArgs =
            choice [
                (genericTypeParam' |>> GenericTypeParam) 
                type'
            ] <?> "generic type params list cannot be empty"
            .>>.? opt (skipString "[]")
            |>> (function |(type', Some _) -> GenericType("[]", [type']) |(type', _) -> type')
        do typeRef := 
            parseGeneric' genericArgs 
            |>> (function |(name, Some params') -> GenericType(name, params') |(name, _) -> BasicType name)
        genericArgs
    let parseTypedef = 
         parseGeneric' genericTypeParam' 
         |>> (function | (name, Some params') -> GenericTypeDef(name, params') | (name, _) -> BasicTypeDef name)

    let parseField  : Parser<FieldDef, _> = parseFieldName .>>. (pchar' ':' >>. parseType' <?> "type not defined")
    let parseRecordBody  =  sepEndBy1  (attempt(between ws' ws'  parseField)) (pchar ';' <|> pchar '\n') 
    let parseRecord = ws >>. str "type" >>. ws' >>. parseTypedef .>> pchar' '=' .>>. between (pchar '{' .>>. ws) (ws .>>. pchar '}') parseRecordBody  .>> ws
    let parseCaseBody  =  sepBy1 (between ws' ws'  parseField) (pchar '*' ) 
    let parseDUCase = ws >>. (pchar '|') >>. ws' >>. parseFieldName .>> ws' .>>. opt ((str "of") >>. parseCaseBody) 
    let parseDU =  ws >>. str "type" >>. ws' >>. parseTypedef .>> pchar' '=' .>>. many1 parseDUCase .>> ws

    test parseDUCase "|  A of Name :long * AZAZA : int"
    test parseDU @"
        type A =
        | A of Name :long * AZAZA : int
        | B of Q : T<'d>"


    test parseType' "Tuple<'b,int,Tuple<'c,'a>,Tuple<'c,'e,'f>>"
    test parseType' "Tuple"
    test parseType' "'b"



    test parseTypedef "Tuple<'a,'b>"
    test parseTypedef "a<'a>"

    test parseField "Name : 'a"
    test parseField "Name : t<'a>"
    test parseField "Name : t"



    test parseRecordBody "Name : string"

    test parseRecordBody @"Name : string ;
       Name_asda : string"


    test parseRecord @"
    type Tuple = {
        Name : string ;
        NickName : Tuple<'a,'b> ;
        Age : int }  
        "


    test parseRecord @"
    type Tuple<'a,'b> = {
        Name : string ;
        NickName : Tuple<'a,'b> ;
        Age : int }  
        "




    test parseType' "Tupla<asdasd,asda>"



