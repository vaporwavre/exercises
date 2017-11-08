using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

////https://leetcode.com/problems/friend-circles/description/
//There are N students in a class. Some of them are friends, while some are not.Their friendship is transitive in nature.For example, if A is a direct friend of B, and B is a direct friend of C, then A is an indirect friend of C.And we defined a friend circle is a group of students who are direct or indirect friends.
//Given a N*N matrix M representing the friend relationship between students in the class. If M[i][j] = 1, then the ith and jth students are direct friends with each other, otherwise not.And you have to output the total number of friend circles among all the students.
namespace FriendCircles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] M = { { 1, 1, 0 }, { 1, 1, 0 }, { 0, 0, 1 } };
            Console.Write(FindCircleNum(M));
        }

        public static int FindCircleNum(int[,] M)
        {
            int result = 0;
            bool[] visited = new bool[M.GetLength(0)];

            for (int i = 0; i < M.GetLength(0); i++)
                if (!visited[i])
                {
                    Console.WriteLine("Friend circle " + i + ": ");
                    Dfs(i, M, visited);
                    result++;
                }

            return result;
        }

        private static void Dfs(int startNode, int[,] M, bool[] visited)
        {
            visited[startNode] = true;

            for (int i = 0; i <= M.GetLength(1) - 1; i++)
            {
                if (startNode == i)
                    continue;

                if (M[startNode, i] == 1 && !visited[i])
                {
                    Dfs(i, M, visited);
                    Console.WriteLine(startNode + " is friends with " + i);
                }
            }
        }
    }
}
