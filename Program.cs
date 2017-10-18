using System;
using System.Diagnostics;

namespace EightQueens
{
    class Program
    {
        // ----------------------------------

        const int N = 8;
        const bool drawSolutions = false;

        // ----------------------------------

        static void Main(string[] args)
        {
            Console.WriteLine($"N: {N}\nCalculating...");

            var sw = new Stopwatch();
            sw.Start();
            var solutions = Solver.GetSolutions(N);
            sw.Stop();
            
            if (drawSolutions)
            {
                foreach (var solution in solutions)
                {
                    PrintField(solution);
                    Console.WriteLine();
                }
            }
            
            Console.WriteLine($"Solution count: {solutions.Count}\nTime elapsed: {sw.Elapsed}");
            Console.ReadLine();
        }

        static void PrintField(bool[,] field)
        {
            for (int y = 0; y < field.GetLength(0); ++y)
            {
                for (int x = 0; x < field.GetLength(1); ++x)
                {
                    if (field[x, y])
                    {
                        const ConsoleColor c = ConsoleColor.Cyan;
                        Console.ForegroundColor = c;
                        Console.BackgroundColor = c;
                        Console.Write('Q');
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.Write('O');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}