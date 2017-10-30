open System
open System.IO
//Challenge: https://www.reddit.com/r/dailyprogrammer/comments/45w6ad/20160216_challenge_254_easy_atbash_cipher/
let plain = "abcdefghijklmnopqrstuvwxyz"
let cipher = "ZYXWVUTSRQPONMLKJIHGFEDCBA"

let rec start input =
     match input with
     | "" -> 
        printfn "$$$$$$$$$$ Type something $$$$$$$$$$"
        let text = Console.ReadLine()
        start text
     | "SUPER" -> 
        printfn "HOT" 
        start ""
     | "EXIT" -> printfn "smoke break!"
     | _ -> 
        input |> String.iter (fun elem -> 
                                    let charIndex = plain.IndexOf(elem)
                                    if charIndex <> -1 then
                                        printf "%c" cipher.[charIndex]
                                    else
                                        printf "%c" elem
                                    )
        printf "\n"
        start ""
     
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    start ""
    0 // return an integer exit code
