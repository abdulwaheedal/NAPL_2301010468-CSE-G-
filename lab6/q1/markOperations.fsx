open System

let getDivision percentage =
    match percentage with
    | p when p >= 60.0 -> "First Division"
    | p when p >= 50.0 -> "Second Division"
    | p when p >= 40.0 -> "Third Division"
    | _ -> "Fail"

let rec readMark subjectName =
    printf "Enter marks for %s (out of 100): " subjectName
    match Double.TryParse(Console.ReadLine()) with
    | true, v when v >= 0.0 && v <= 100.0 -> v
    | _ ->
        printfn "Invalid input. Enter a number between 0 and 100."
        readMark subjectName

let main argv =
    let marks = [ for i in 1..4 -> readMark $"Subject {i}" ]
    let total = List.sum marks
    let percentage = total / 4.0

    printfn "\n--- Results ---"
    printfn "Total Marks: %.2f / 400.00" total
    printfn "Percentage : %.2f%%" percentage
    printfn "Division   : %s" (getDivision percentage)
    0

main [||] |> ignore
