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
Record.Generate "type A<'t> = { Name : t[] }"


let test1 = @"type A<'t> = | A of azaa : 't * name : string | B | C of  aaa : 't" 
let test2 = @"type A<'t> = | A | B of t[] | C of List<'t> | D of int * name : string * Option<'t>"
let test3 = @"type Signal = | NoSignal | GoodSignal of date : DateTime * value : double | CorruptedSignal of date : DateTime"
DU.Generate test1
DU.Generate test2
DU.Generate test3
