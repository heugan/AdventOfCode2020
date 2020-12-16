module Day2.PasswordPhilosophy

open System.IO
open System.Text.RegularExpressions

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None

type PasswordPolicyCheck(firstNumber, secondNumber, token, userPassword) = 
    member x.FirstNumber : int = firstNumber
    member x.SecondNumber : int = secondNumber
    member x.Token : string = token
    member x.UserPassword : string = userPassword

type Data(?useSample : bool) =
    let isSample = defaultArg useSample false
    member x.FilePath with get() = 
        if isSample then
            @".\..\..\..\Day2-PasswordPhilosophy\data\sample-day2.txt"
        else
            @".\..\..\..\Day2-PasswordPhilosophy\data\input-day2.txt"
    member val Part1ValidCount : int = 0 with get, set
    member val Part2ValidCount : int = 0 with get, set

    member x.ParsePolicyInput input = 
        match input with
        | Regex @"([0-9]*)[-. ]?([0-9]*)[-. ]?(\w):[-. ]?(\w*)" [min; max; token; password] ->
        Some(new PasswordPolicyCheck(int min, int max, token, password))
        | _ -> None
    
    member x.VerifyOccurencePolicy (input : PasswordPolicyCheck) =
        let count = Regex.Matches(input.UserPassword, input.Token).Count
        let result = input.FirstNumber <= count && count <= input.SecondNumber
        result

    member x.VerifyPositionPolicy (input : PasswordPolicyCheck) =
        if input.UserPassword.Length < input.SecondNumber || input.FirstNumber = 0 then
            false
        else
            let result = (input.UserPassword.Substring(input.FirstNumber-1, 1) = input.Token) <> (input.UserPassword.Substring(input.SecondNumber-1, 1) = input.Token)
            result
    
    member x.Read() =
        use stream = new StreamReader @".\..\..\..\Day2-PasswordPhilosophy\data\input-day2.txt"
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
                let temp = x.ParsePolicyInput line
                if temp.IsSome then
                    if (x.VerifyOccurencePolicy temp.Value) then
                        x.Part1ValidCount <- x.Part1ValidCount + 1
                    if (x.VerifyPositionPolicy temp.Value) then
                        x.Part2ValidCount <- x.Part2ValidCount + 1
                

// Create instance of Data and Read in the file.
let data = Data()
data.Read()

// Dag 2 del 1: 643
// Dag 2 del 2: 388

