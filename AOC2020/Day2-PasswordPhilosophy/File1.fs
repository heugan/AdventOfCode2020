module Day2.File1


let echo =
    let me = Day2.Inputs.aocSampleInput
    me

let echo2 = Day2.Inputs.me

open System.IO
open System.Text.RegularExpressions

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None

//Example:

//let phone = "(555) 555-5555"
//match phone with
//| Regex @"\(([0-9]{3})\)[-. ]?([0-9]{3})[-. ]?([0-9]{4})" [ area; prefix; suffix ] ->
//    printfn "Area: %s, Prefix: %s, Suffix: %s" area prefix suffix
//| _ -> printfn "Not a phone number"

let testParse =
    let testString = "1-3 a: abcde"
    match testString with
    | Regex @"([0-9]-[0-9])[-. ]([a-z]):[-. ](\w*)" [ range; token; pass ] ->
    //([0-9])(-)([0-9])[-. ]([a-z]):[-. ](\w*)
        printfn "Range: %s, Token: %s, Passowrd: %s" range token pass
    //| Regex @"([0-9]-[0-9]{3+})[-. ]?([a-z]{1})[-.: ]?([a-z]{*})" [ range; token; pass ] ->
    //    printfn "Range: %s, Token: %s, Passowrd: %s" range token pass
    | _ -> printfn "Knas"


type Password(range, token, userPassword) = 
    member this.Range : seq<int> = range
    member this.Token : string = token
    member this.UserPassword : string = userPassword  


//type Row() =
//    let mutable myRange : seq<int> = myRange
//    member x.range
//        with get() = myRange
//        and set(value) = myRange <- value
            
//    member this.MyReadWriteProperty
//    with get () = myInternalValue
//    and set (value) = myInternalValue <- value


type Data() =

    member x.Read() =
        // Read in a file with StreamReader.
        //use stream = new StreamReader @"C:\programs\file.txt"
        use stream = new StreamReader @".\..\..\..\Day2-PasswordPhilosophy\data\input-day2.txt"
//let path = ".\data\input-day2.txt"


        // Continue reading while valid lines.
        let mutable valid = true
        while (valid) do
            let line = stream.ReadLine()
            if (line = null) then
                valid <- false
            else
                //let temp = Password line
                // Display line.
                printfn "%A" line

// Create instance of Data and Read in the file.
//let data = Data()
//data.Read()
