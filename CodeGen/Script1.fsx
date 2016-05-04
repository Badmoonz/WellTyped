#r @"..\packages\FParsec.1.0.2\lib\net40-client\FParsecCS.dll"
#r @"..\packages\FParsec.1.0.2\lib\net40-client\FParsec.dll"

#load "Parse.fs"
#load "Common.fs"
#load "Record.fs"
#load "DiscriminatedUnion.fs"

open System
open System.Collections.Generic
open System.Text
open System.Text.RegularExpressions
open CodeGen



Record.Generate "type A<'t> = { Name : string  }"
Record.Generate "type A = { Name : List<string[]> ;  Age : List<'t>[]}"
Record.Generate "type A<'t> = { Name :  't[] }"

Record.Generate "type A<'t> = {
                     Name : List<string[]>
                     Age : List<'t>[]
                     }"



DU.Generate @"type AAA<'t> = | A of azaa : 't * name : string | B | C of  aaa : 't" 
DU.Generate @"type AAA<'t> = | A | B of date : 't[] | C of name : List<'t> | D of age : int * name : string * ll : Option<'t>"
DU.Generate @"type Signal = | NoSignal | GoodSignal of date : DateTime * value : double | CorruptedSignal of date : DateTime"

DU.Generate @"type TestSum<'t> = 
                | A of azaa : 't * name : string
                | B 
                | C of  aaa : 't" 

DU.Generate @"type A = 
                | A of azaa : int * name : string
                | B 
                | C of  aaa : long" 

