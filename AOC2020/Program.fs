// Learn more about F# at http://fsharp.org

module HelloWorld
open System



[<EntryPoint>]
let main argv =
    let day=2
    if day=1 then 
        printfn "Day 1"
        printfn $"processing 'aocSampleInput' {Inputs.aocSampleInput} through 'FixExpenseReport' produces: {ReportRepair.FixExpenseReport  Inputs.aocSampleInput}, should be 514579."
        printfn $"processing 'aocSampleInput' {Inputs.aocPuzzleInput} through 'FixExpenseReport' produces: {ReportRepair.FixExpenseReport  Inputs.aocPuzzleInput}."
    elif day=2 then
        printfn "Day 2"
        //printfn $"processing 'aocSampleInput' {Day2.Inputs.aocSampleInput} through 'FixExpenseReport'"// produces: {ReportRepair.FixExpenseReport  Inputs.aocSampleInput}, should be 514579."
        //printfn $"hej {Day2.Inputs.aocPuzzleInput}."
        //printfn $"hej {Day2.File1.echo}."
        //printfn $"test {Day2.File1.testParse}."
        //printfn $"test {Day2.File1.test}."
        //printfn $"test {Day2.Data().Read(}."
        //printfn $"test {Day2.File1.data.ValidCount}."
        printfn $"read {Day2.PasswordPhilosophy.Data().Read()}."
        printfn $"part1 {Day2.PasswordPhilosophy.data.Part1ValidCount}."
        printfn $"part2 {Day2.PasswordPhilosophy.data.Part2ValidCount}."

        // Högre än 394
    0 // Return an integer exit code