using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeRouteCircle
{
    //https://leetcode.com/problems/judge-route-circle/description/
    class Program
    {
        static string validMoves = "UDLR";
        static void Main(string[] args)
        {
            while (true)
                run();
        }

        private static void run()
        {
            int startX = 0, startY = 0;
            int currentX = startX, currentY = startY;
            string moveInput = Console.ReadLine();
            foreach(char move in moveInput)
            {
                if (!validMoves.Contains(move))
                {
                    Console.WriteLine("Invalid move " + move + " found");
                    return;
                }

                switch (move)
                {
                    case 'U':
                        currentY++;
                        break;
                    case 'D':
                        currentY--;
                        break;
                    case 'L':
                        currentX--;
                        break;
                    case 'R':
                        currentX++;
                        break;
                }
            }
            Console.WriteLine(startY == currentY && startX == currentX);
        }
    }
}
