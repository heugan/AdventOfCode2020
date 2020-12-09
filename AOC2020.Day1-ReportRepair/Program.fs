// Learn more about F# at http://fsharp.org

module HelloWorld
open System



[<EntryPoint>]
let main argv =
    printfn $"processing 'aocSampleInput' {Inputs.aocSampleInput} through 'FixExpenseReport' produces: {ReportRepair.FixExpenseReport  Inputs.aocSampleInput}, should be 514579."
    printfn $"processing 'aocSampleInput' {Inputs.aocPuzzleInput} through 'FixExpenseReport' produces: {ReportRepair.FixExpenseReport  Inputs.aocPuzzleInput}."
    0 // Return an integer exit code