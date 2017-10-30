open System
open System.IO
open System.Collections

let getRandArrElement =
  let rnd = Random()
  fun (arr : string[]) -> arr.[rnd.Next(arr.Length)]

let LaBeoufs = [| "Do it! Just do it!"; "Don't let your dreams be dreams."; "Yesterday you said tomorrow. So just do it!"; "Make your dreams come true. Just do it."; "If you're tired of starting over; stop giving up."; "YES YOU CAN! JUST DO IT! "; "Nothing is impossible..."; "DO IT! JUST DO IT!"; "What are you waiting for?!"|]

let printList list = 
    List.fold (fun acc elem -> 
                    printfn "%A %A \n %A\n" acc elem (getRandArrElement LaBeoufs)
                    acc + 1) 0 list |> ignore

let rec remove i l =
    match i, l with
    | 0, x::xs -> xs
    | i, x::xs -> x::remove (i - 1) xs
    | i, [] -> failwith "index out of range"

let rec start (input:string) (todo:List<string>) =
    let command = if input.Contains(" ") then
                    input.Remove(input.IndexOf(' '))
                    else
                    input
    let value = if input.Contains(" ") then
                    input.Substring(input.IndexOf(' ') + 1)
                else
                    ""
    let commandArray = [| command; value; |]
    match command with
    | ""  ->
        let command = Console.ReadLine()
        start command []
    | "add" ->
        let updatedTodo = commandArray.[1]::todo
        let command = Console.ReadLine()
        start command updatedTodo
    | "delete" ->
        let commandValueIsNumeric, numericCommandValue = Int32.TryParse(commandArray.[1])
        if commandValueIsNumeric && numericCommandValue <= todo.Length then
            let updatedToDo = remove numericCommandValue todo
            printfn "YOU DID IT! I knew you could %A!\n" todo.[numericCommandValue]
            let command = Console.ReadLine()
            start command updatedToDo
        else if commandValueIsNumeric && numericCommandValue > todo.Length then
            printfn "YOU DIDN'T HAVE THAT ON YOUR LIST!"
            let command = Console.ReadLine()
            start command todo
        else
            let toBeDeletedIndex = if todo |> List.contains(value) then 
                                    todo |> List.findIndex (fun elem -> String.Equals(elem, value))
                                   else
                                    -1
            if toBeDeletedIndex <> -1 then
                let updatedTodo = remove toBeDeletedIndex todo
                printfn "YOU DID IT! I knew you could %A!\n" todo.[toBeDeletedIndex]
                let command = Console.ReadLine()
                start command updatedTodo
            else
                printfn "YOU DIDN'T HAVE THAT ON YOUR LIST!"
                let command = Console.ReadLine()
                start command todo
    | "view" ->
        printList todo
        let command = Console.ReadLine()
        start command todo
    | _ -> 
        printfn "bye"
[<EntryPoint>]
let main argv = 
    start " " []
    0 // return an integer exit code
