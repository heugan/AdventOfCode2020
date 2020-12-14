module Day2.File1


//let echo =
//    let me = Day2.Inputs.aocSampleInput
//    me

//let echo2 = Day2.Inputs.me

open System.IO
open System.Text.RegularExpressions

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None

//type PasswordPolicyCheck(minOccurrence, maxOccurence, token, userPassword) = 
//    member x.MinOccurrence : string = minOccurrence
//    member x.MaxOccurence : string = maxOccurence
//    member x.Token : string = token
//    member x.UserPassword : string = userPassword

type PasswordPolicyCheck(minOccurrence, maxOccurence, token, userPassword) = 
    member x.MinOccurrence : int = minOccurrence
    member x.MaxOccurence : int = maxOccurence
    member x.Token : string = token
    member x.UserPassword : string = userPassword
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

let parsePolicy input = 
    match input with
    | Regex @"([0-9])[-. ]?([0-9])[-. ]?(\w):[-. ]?(\w*)" [min; max; token; password] ->
    Some(new PasswordPolicyCheck(int min, int max, token, password))
    | _ -> None

//let verifyPolicy (input : PasswordPolicyCheck) =
//    input.UserPassword
//    Seq.filter ((=) input.Token) >> Seq.length
    
//    //let result = input.UserPassword.Contains(input.Token)
//    //result

let verifyPolicy (input : PasswordPolicyCheck) =
    let count = Regex.Matches(input.UserPassword, input.Token).Count
    let result = input.MinOccurrence <= count && count <= input.MaxOccurence
    result
    
    //let result = input.UserPassword.Contains(input.Token)
    //result

let test =
    let testString = "1-3 a: abcde"
    let res = parsePolicy testString
    if res = None then
        printfn "knas"
    else
        printfn $"{res.Value.MinOccurrence},{res.Value.MaxOccurence},{res.Value.Token},{res.Value.UserPassword}"



type Data() =
    member val ValidCount : int = 0 with get, set

    member x.Read() =
        use stream = new StreamReader @".\..\..\..\Day2-PasswordPhilosophy\data\input-day2.txt"
//let path = ".\data\input-day2.txt"
        // Continue reading while valid lines.
        let mutable valid = true
        //let mutable validCount = 0
        while (valid) do
            let line = stream.ReadLine()
            if (line = null) then
                valid <- false
            else
                // Display line.
                //printfn "%A" line
                let temp = parsePolicy line
                if temp.IsSome then
                    //let isValid = 
                    if (verifyPolicy temp.Value) then
                        x.ValidCount <- x.ValidCount + 1
                

// Create instance of Data and Read in the file.
let data = Data()
data.Read()