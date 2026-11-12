let demonstrateMap (list1: int list) (list2: int list) =
    printfn "=== 1. List.map (Square each element) ==="
    let squared1 = list1 |> List.map (fun x -> x * x)
    let squared2 = list2 |> List.map (fun x -> x * x)

    printfn "Input 1: %A -> Squared: %A" list1 squared1
    printfn "Input 2: %A -> Squared: %A\n" list2 squared2

let demonstrateFilter (list1: int list) (list2: int list) =
    printfn "=== 2. List.filter (Retain even numbers) ==="
    let evens1 = list1 |> List.filter (fun x -> x % 2 = 0)
    let evens2 = list2 |> List.filter (fun x -> x % 2 = 0)

    printfn "Input 1: %A -> Evens: %A" list1 evens1
    printfn "Input 2: %A -> Evens: %A\n" list2 evens2

let demonstrateFold (list1: int list) (list2: int list) =
    printfn "=== 3. List.fold (Compute sum of elements) ==="
    // Accumulator starts at 0 and adds each element
    let sum1 = list1 |> List.fold (fun acc x -> acc + x) 0
    let sum2 = list2 |> List.fold (fun acc x -> acc + x) 0

    printfn "Input 1: %A -> Sum: %d" list1 sum1
    printfn "Input 2: %A -> Sum: %d\n" list2 sum2

[<EntryPoint>]
let main _ =
    let sampleListA = [ 1; 2; 3; 4; 5 ]
    let sampleListB = [ 10; 15; 20; 25; 30 ]

    demonstrateMap sampleListA sampleListB
    demonstrateFilter sampleListA sampleListB
    demonstrateFold sampleListA sampleListB

    0
