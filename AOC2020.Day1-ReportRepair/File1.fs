module File1

//// Learn more about F# at http://fsharp.org

//module HelloSquare
//open System

let square x = x * x

///// Adds 1 to a value.
//let addOne x = x + 1

///// Tests if an integer value is odd via modulo.
//let isOdd x = x % 2 <> 0

///// A list of 5 numbers.  More on lists later.
//let numbers = [ 1; 2; 3; 4; 5 ]

//let evenNumbers = Seq.init 1001 (fun n -> n * 2)

//let rec factorial n = 
//    if n = 0 then 1 else n * factorial (n-1)

//let rec greatestCommonFactor a b =
//       if a = 0 then b
//       elif a < b then greatestCommonFactor a (b - a)
//       else greatestCommonFactor (a - b) b

//let squareOddValuesAndAddOne values = 
//       let odds = List.filter isOdd values
//       let squares = List.map square odds
//       let result = List.map addOne squares
//       result

//let squareOddValuesAndAddOnePipeline values =
//       values
//       |> List.filter isOdd
//       |> List.map square
//       |> List.map addOne

//let inputs = [0,1,7,9]
///// This is a list of all tuples containing all the numbers from 0 to 99 and their squares.
//let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]
//let aocInput = [1721; 979; 366; 299; 675; 1456]


///// Given two sequences and a comparator function, find the pairs of items for 
///// which the comparator returns true
//let findPairs compare seqT seqU =
//    seq {
//            for t in seqT do
//                for u in seqU do
//                    if (compare t u) then
//                        yield (t, u)
//    }

///// Given two sequences and a comparator function, find the first pair of items 
///// for which the comparator returns true
//let tryFindFirstPair compare seqT seqU =
//    let matches = findPairs compare seqT seqU
//    if not (Seq.isEmpty matches) then
//        Some(Seq.item 0 matches)
//    else
//        None

//let tryFindFirstPair2 compare seqT seqU =
//    let matches = findPairs compare seqT seqU
//    if not (Seq.isEmpty matches) then
//        Seq.item 0 matches
//    else
//        (0,0)

//let find2020pair x y = 2020=x+y
//let multiply2020pair (x : int, y : int) = x * y

////let multiply2020pair2 (int: x int: y) = x*y

//let rec multi listX listY =
//    let temp1 = match listX with
//    | head :: tail -> multi tail (List.filter (find2020pair head) listY)
//    | [] -> listY
//    temp1

//let hh2 x y =
//    let tmp = tryFindFirstPair2 find2020pair x y
//    let tmp2 = multiply2020pair tmp
//    tmp2

//let hh x y =
//    let tmp = tryFindFirstPair find2020pair x y
//    let tmp2 = multiply2020pair tmp.Value
//    tmp2



//let mult a b =
//    let pairs = match a with
//    | head :: tail -> (List.filter (find2020pair head) b)
//    pairs

////let mult2 a b =
////    let pair = match a with
////    | head :: tail -> (List.filter (find2020pair head) b)
////    (pair, p2)

////let mult2 a b =
////    let pair = match a with
////    | head :: tail ->
////    if (find2020pair head) tail then

////    | head :: tail -> (List.filter (find2020pair head) b)
////    (pair, p2)

////let hej n =
////    let temp1 = multi n
////    let temp2 = List.map square temp1
////    temp2

////let multi2 listX listY =
////    let temp1 = List.filter listX listY
////    let temp2 = List.map temp1
////    temp2
////let multiply2020i (xValues : int list, yValues : int list) =
////    let temp = List.filter find2020pair (xValues; yValues)
////    let temp2 = List.map multiply2020pair temp
////    result

////let multiply2020 (xValues : int list, yValues : int list) =
////    (xValues, yValues)
////    |> List.filter find2020pair
////    |> List.map multiply2020pair




//let IsPrimeMultipleTest n x =
//   x = n || x % n <> 0

//let rec RemoveAllMultiples listn listx =
//   match listn with
//   | head :: tail -> RemoveAllMultiples tail (List.filter (IsPrimeMultipleTest head) listx)
//   | [] -> listx


//let GetPrimesUpTo n =
//    let max = int (sqrt (float n))
//    RemoveAllMultiples [ 2 .. max ] [ 1 .. n ]


//[<EntryPoint>]
//let main argv =
//    printfn "%d squared is: %d!" 12 (square 12)
//    printfn $"inputs is: {inputs.[0]}"
//    printfn $"The table of squares from 0 to 99 is:\n{sampleTableOfSquares}"
//    //printfn $"processing {aocInput} through 'squareOddValuesAndAddOnePipeline' produces: {multiply2020 aocInput }"
//    printfn $"Factorial of 6 is: %d{factorial 6}"
//    printfn $"The Greatest Common Factor of 300 and 620 is %d{greatestCommonFactor 300 620}"
//    printfn $"The Greatest Common Factor of 300 and 620 is %d{greatestCommonFactor 0 620}"
//    printfn "Primes Up To %d:\n %A" 100 (GetPrimesUpTo 100)
//    printfn $"processing {aocInput} through 'multi' produces: {multi aocInput aocInput}"
//    printfn $"processing {aocInput} through 'multi' produces: {mult aocInput aocInput}"
//    //printfn $"processing {aocInput} through 'find' produces: {find2020pair aocInput aocInput}"
//    printfn $"processing {aocInput} through 'find' produces: {tryFindFirstPair find2020pair aocInput aocInput}"
//    printfn $"processing {aocInput} through 'hh' produces: {hh aocInput aocInput}"
//    printfn $"processing {aocInput} through 'hh2' produces: {hh2 aocInput aocInput}"
//    //printfn $"processing {aocInput} through 'find' produces: {findPairs find2020pair aocInput aocInput}"

//    //printfn $"The Greatest Common Factor of 300 and 620 is %d{greatestCommonFactor 620 0}"
//    0 // Return an integer exit code

