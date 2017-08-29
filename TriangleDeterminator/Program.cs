using System;
using System.Collections.Generic;

namespace TriangleDeterminator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Triangle determinator | 29/08/17 | Author: Carsten Nilsson");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Please write 3 numbers; one for each side of a triangle. Type 'Exit' to quit.");
            Console.WriteLine();

            var entries = new List<double>();
            while (entries.Count < 3)
            {
                Console.Write("Insert a number: ");
                var entry = Console.ReadLine();

                if (entry.ToLower().Trim() == "exit")
                {
                    Console.WriteLine("PROGRAM TERMINATED. Press any key to exit.");
                    Console.ReadLine();
                    return;
                }

                double result;
                if (double.TryParse(entry, out result))
                {
                    if (result < 0)
                    {
                        Console.WriteLine("You cannot use a negative number! Please retry.");
                        continue;
                    }

                    entries.Add(result);
                    Console.WriteLine($"Adding {entry} as triangle side. Current state: [{string.Join(", ", entries)}]");
                }
                else
                {
                    Console.WriteLine("Input was Not-a-Number! Please retry or type exit.");
                }
            }
            Console.WriteLine();
            try
            {
                var triangle = new Triangle(entries.ToArray());
                Console.WriteLine("Area size: " + triangle.Area);
                var type = TriangleExtensions.DetermineType(triangle.A, triangle.B, triangle.C);
                Console.WriteLine("Triangle type: " + type);
                Console.WriteLine("Program completed. Press any key to exit.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine("Please re-try by running the program agian. Press any key to exit.");
                Console.ReadLine();
            }
        }
    }
}