module ReportRepair
//http://www.fssnip.net/75/title/Finding-matching-pairs-in-two-sequences
//https://docs.microsoft.com/en-us/dotnet/fsharp/tour#pipelines-and-composition

let allPairs compare seqA seqB =
    seq{
        for itemA in seqA do
            for itemB in seqB do
                if (compare itemA itemB) then
                    yield (itemA, itemB)
    }

let firstPair compare seqA seqB =
    let matches = allPairs compare seqA seqB
    if not (Seq.isEmpty matches) then
        Some(Seq.item 0 matches)
    else
        None

let isPair x y = 2020 = x + y
let multiply (x, y) = x * y

let FixExpenseReport numbers =
    let pair = firstPair isPair numbers numbers
    let product = multiply pair.Value
    product