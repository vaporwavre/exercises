using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KnightsMetric
{
    //https://www.reddit.com/r/dailyprogrammer/comments/6coqwk/20170522_challenge_316_easy_knights_metric/
    class Program
    {
        class KnightPoint{
            public int x, y;
            public KnightPoint previousPoint;
            public KnightPoint(int x, int y, KnightPoint previousPoint)
            {
                this.x = x;
                this.y = y;
                this.previousPoint = previousPoint;
            }
        }
        
        static void Main(string[] args)
        {
            while (true)
                run();
        }

        private static void run()
        {
            string inputPattern = "[0-9]+\\s+[0-9]+";
            string moveInput = Console.ReadLine();
            if (!Regex.IsMatch(moveInput, inputPattern))
            {
                Console.WriteLine("Incorrect input. Please enter 2 numbers separated by a space");
                return;
            }
            KnightPoint start = new KnightPoint(0, 0, null);
            string[] endStringArray = moveInput.Split(' ');
            KnightPoint end = new KnightPoint(Int32.Parse(endStringArray[0]), Int32.Parse(endStringArray[1]),null);
            List<KnightPoint> path = Bfs(start, end);
            Console.WriteLine(path.Count);
            foreach(KnightPoint point in path)
            {
                Console.WriteLine(point.x + " " + point.y);
            }
        }

        private static List<KnightPoint> Bfs(KnightPoint start, KnightPoint end)
        {
            Queue<KnightPoint> queue = new Queue<KnightPoint>();
            List<KnightPoint> visited = new List<KnightPoint>();
            List<KnightPoint> path = new List<KnightPoint>();
            queue.Enqueue(start);

            while(queue.Count != 0)
            {
                KnightPoint currentCoordinate = queue.Dequeue();
                visited.Add(currentCoordinate);
                if (KnightPointsAreEqual(currentCoordinate, end)){
                    while(currentCoordinate.previousPoint != null)
                    {
                        path.Add(currentCoordinate);
                        currentCoordinate = currentCoordinate.previousPoint;
                    }
                    path.Add(start);
                    return path;
                }
                else
                {
                    List<KnightPoint> nextCoordinates = NextCoordinates(currentCoordinate);
                    foreach(KnightPoint nextCoordinate in nextCoordinates)
                    {
                        if(!ContainsPoint(visited, nextCoordinate))
                        {
                            queue.Enqueue(nextCoordinate);
                        }
                    }
                }
            }
            return path;
        }

        private static bool ContainsPoint(List<KnightPoint> list, KnightPoint point)
        {
            return list.Any(element => element.x == point.x && element.y == point.y);
        }

        private static List<KnightPoint> NextCoordinates(KnightPoint coordinate)
        {
            int[][] moves = new int[8][];
            moves[0] = new int[2] { -1, -2 };
            moves[1] = new int[2] { 1, -2 };
            moves[2] = new int[2] { -1, 2 };
            moves[3] = new int[2] { 1, 2 };
            moves[4] = new int[2] { -2, -1 };
            moves[5] = new int[2] { 2, -1 };
            moves[6] = new int[2] { -2, 1 };
            moves[7] = new int[2] { 2, 1 };

            List<KnightPoint> results = new List<KnightPoint>();

            foreach(int[] move in moves)
            {
                results.Add(new KnightPoint(coordinate.x + move[0], coordinate.y + move[1],coordinate));
            }
            return results;
        }

        private static bool KnightPointsAreEqual(KnightPoint k1, KnightPoint k2)
        {
            return (k1.x == k2.x && k1.y == k2.y);
        }
    }
}
