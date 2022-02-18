namespace Kse.Algorithms.Samples
{
    using System;
    using System.Collections.Generic;

    public class MapPrinter
    {
        public void Print(string[,] maze, Point start, Point destination, List<Point> path)
        {
            PrintTopLine();
            for (var pathed = 1; pathed <= path.Count - 1; pathed++)
            {
                var newX = path[pathed].Column;
                var newY = path[pathed].Row;
                maze[newX, newY] = "🟢";
            }
            
            maze[start.Column, start.Row] = "🏠";
            maze[destination.Column, destination.Row] = "🏁";
            
            for (var row = 0; row < maze.GetLength(1); row++)
            {
                Console.Write($"{row}\t");
                for (var column = 0; column < maze.GetLength(0); column++)
                {
                    Console.Write(maze[column, row]);
                }

                Console.WriteLine();
            }

            void PrintTopLine()
            {
                Console.Write($" \t");
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    Console.Write(i % 10 == 0? i / 10 : " ");
                }
    
                Console.Write($"\n \t");
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    Console.Write(i % 10);
                }
    
                Console.WriteLine("\n");
            }
        }
    }
}