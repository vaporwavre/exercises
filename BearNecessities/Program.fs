open System
open System.Text
open System.Text.RegularExpressions

//https://www.reddit.com/r/dailyprogrammer/comments/5bn0b7/20161107_challenge_291_easy_goldilocks_bear/

//The input begins with a line specifying Goldilocks' weight (as an integer in arbitrary weight-units) and the maximum temperature of porridge she will tolerate (again as an arbitrary-unit integer). This line is then followed by some number of lines, specifying a chair's weight capacity, and the temperature of the porridge in front of it.
//
//Sample input:
//
//100 80
//30 50
//130 75
//90 60
//150 85
//120 70
//200 200
//110 100
//
//Interpreting this, Goldilocks has a weight of 100 and a maximum porridge temperature of 80. The first seat at the table has a chair with a capacity of 30 and a portion of porridge with the temperature of 50. The second has a capacity of 130 and temperature of 60, etc.
//Formal Output
//
//The output must contain the numbers of the seats that Goldilocks can sit down at and eat up. This number counts up from 1 as the first seat.

[<EntryPoint>]
let main argv = 
    let inputLines : string[] = Regex.Split(argv.[0], "\r\n|\r|\n")
    let goldilocksWeight = Int32.Parse(inputLines.[0].Split(' ').[0])
    let desiredTemperature = Int32.Parse(inputLines.[0].Split(' ').[1])
    let rec loop index result:string =
        if index < inputLines.Length then 
            let currentOptions = inputLines.[index].Split ' '
            if Int32.Parse(currentOptions.[0]) >= goldilocksWeight && Int32.Parse(currentOptions.[1]) <= desiredTemperature then
                loop (index + 1) (result + (index |> string) + " ")
            else
                loop (index + 1)  result
        else
            result
    Console.WriteLine(loop 1 "")
    0
