using System;
using System.Collections.Generic;
using System.Linq;

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

            var entries = GetEntriesFromUser();
            if (!entries.Any())
                return;
            DisplayTriangleStatus(entries);
        }

        private static void DisplayTriangleStatus(List<double> entries)
        {
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

        private static List<double> GetEntriesFromUser()
        {
            var entries = new List<double>();
            while (entries.Count < 3)
            {
                Console.Write("Insert a number: ");
                var entry = Console.ReadLine();

                if (entry.ToLower().Trim() == "exit")
                {
                    Console.WriteLine("PROGRAM TERMINATED. Press any key to exit.");
                    Console.ReadLine();
                    break;
                }

                if (double.TryParse(entry, out var result))
                {
                    if (result < 1)
                    {
                        Console.WriteLine("You cannot use a negative number or zero! Please retry.");
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
            return entries;
        }
    }
}