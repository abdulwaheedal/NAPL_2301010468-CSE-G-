open System

type TaskConfig = {
    Id: int
    Name: string
    DelayMs: int
}

let executeTask (config: TaskConfig) =
    async {
        let startTime = DateTime.Now.ToString("HH:mm:ss.fff")
        printfn "[%s] Starting Task %d (%s)..." startTime config.Id config.Name

        // Simulate I/O delay without blocking the main thread
        do! Async.Sleep config.DelayMs

        let endTime = DateTime.Now.ToString("HH:mm:ss.fff")
        printfn "[%s] Finished Task %d (%s)" endTime config.Id config.Name

        return sprintf "Task %d (%s) completed in %dms" config.Id config.Name config.DelayMs
    }

[<EntryPoint>]
let main _ =
    // Define tasks with varying delays to show non-sequential completion
    let tasks = [
        { Id = 1; Name = "Fetch User Profile"; DelayMs = 1500 }
        { Id = 2; Name = "Load Order History"; DelayMs = 500 }
        { Id = 3; Name = "Verify Payment Token"; DelayMs = 1000 }
        { Id = 4; Name = "Sync Preferences"; DelayMs = 300 }
    ]

    printfn "Dispatching all tasks concurrently...\n"

    // Run workflows in parallel and collect all results
    let results =
        tasks
        |> List.map executeTask
        |> Async.Parallel
        |> Async.RunSynchronously

    printfn "\n--- Summary of Collected Results ---"
    results |> Array.iter (printfn "%s")

    0
