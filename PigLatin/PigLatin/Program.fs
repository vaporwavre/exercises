open System
let pig (word:string) =
    word.Substring(1) + word.Substring(0,1) + "ay"

let rec run() =
    let input = Console.ReadLine().Trim()
    match input with
    | "exit" -> 0 |> ignore
    | "" -> 
        printfn ""
        run()
    | _ -> 
        let words = input.Split([|' '|])
        words |> Array.iter (fun elem -> printf "%A " (pig elem)) 
        run()           


[<EntryPoint>]
let main argv = 
    run()
    0
