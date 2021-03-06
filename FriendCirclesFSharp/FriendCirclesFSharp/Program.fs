﻿//https://leetcode.com/problems/friend-circles/description/
//There are N students in a class. Some of them are friends, while some are not.Their friendship is transitive in nature.For example, if A is a direct friend of B, and B is a direct friend of C, then A is an indirect friend of C.And we defined a friend circle is a group of students who are direct or indirect friends.
//Given a N*N matrix M representing the friend relationship between students in the class. If M[i][j] = 1, then the ith and jth students are direct friends with each other, otherwise not.And you have to output the total number of friend circles among all the students.

let toArray (arr:_[,]) = 
  Array.init arr.Length (fun i -> arr.[0, i])

let rec dfs(startNode : int, m : int[,], visited : bool[]) = 
    visited.[startNode] <- true;
    m.[0..0, 0..m.GetLength(1)-1] |> toArray |> Array.iteri(fun i element -> if m.[startNode,i] = 1 && not visited.[i] then 
                                                                                dfs(i, m, visited) 
                                                                                printfn "%A is friends with %A" startNode i)  

let findCircleNum (m : int[,]) =
    let visited : bool[] = Array.zeroCreate(m.GetLength(0))
    let rec innerFindCircleNum(startNode : int, result : int) = 
        if startNode < m.GetLength(0) && not visited.[startNode] then
            printfn "Friend circle %A: " startNode
            dfs(startNode, m, visited)
            innerFindCircleNum(startNode + 1, result + 1)
        elif startNode < m.GetLength(0) && visited.[startNode] then
            innerFindCircleNum(startNode + 1, result)
        else
            result
    innerFindCircleNum(0,0)

[<EntryPoint>]
let main argv = 
    let m : int[,] = Array2D.init 3 3 (fun i j -> [ [1; 1; 0]; [1; 1; 0]; [0; 0; 1] ].[i].[j])
    let result = findCircleNum m
    printfn "%d" result
    0 // return an integer exit code