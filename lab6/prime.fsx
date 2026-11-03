// Tail-recursive: divisor d se shuru karke sqrt(n) tak check karta hai
let isPrime n =
    let rec hasNoDivisor d =
        if d > n / d then true            // d*d > n, overflow-safe
        elif n % d = 0 then false
        else hasNoDivisor (d + 2)         // sirf odd divisors
    match n with
    | n when n < 2 -> false
    | 2 -> true
    | n when n % 2 = 0 -> false
    | _ -> hasNoDivisor 3

// Test cases: (description, inputs, expected result for every input)
let testSets =
    [ "Known primes",            [2; 3; 5; 7; 13; 97; 7919],        true
      "Known composites",        [4; 9; 15; 49; 100; 7917],         false
      "Edge cases (<2)",         [1; 0; -7; -2],                    false
      "Large prime (Int32.Max)", [2147483647],                      true ]

let runSet (name, inputs, expected) =
    printfn "\n== %s ==" name
    inputs
    |> List.map (fun n -> n, isPrime n)
    |> List.iter (fun (n, r) ->
        let status = if r = expected then "PASS" else "FAIL"
        printfn "isPrime %d = %b  [%s]" n r status)

testSets |> List.iter runSet
