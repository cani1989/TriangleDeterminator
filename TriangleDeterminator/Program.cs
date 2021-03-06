﻿using System;
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

                // Validate input
                if (CheckEmpty(entry)) continue;
                if (CheckExit(entry)) break;
                if (CheckNaN(entry, out var result)) continue;
                if (CheckZero(result)) continue;
                if (CheckNegative(result)) continue;

                // Use input
                entries.Add(result);
                Console.WriteLine($"Adding {entry} as triangle side. Current state: [{string.Join(", ", entries)}]");
            }
            return entries;
        }

        private static bool CheckNaN(string entry, out double result)
        {
            if (entry.Contains('.'))
                entry = entry.Replace('.', ',');
            var res = double.TryParse(entry, out result);
            return ConditionCheck(() => !res, "Input was not valid number! Please retry or type exit.");
        }

        private static bool CheckNegative(double result)
        {
            return ConditionCheck(() => result < 0, "You cannot have a negative number as input! Try again.");
        }

        private static bool CheckZero(double result)
        {
            return ConditionCheck(() => result == 0, "You cannot have zero as input! Try again.");
        }

        private static bool CheckExit(string entry)
        {
            return ConditionCheck(() => entry.ToLower().Trim() == "exit", "PROGRAM TERMINATED. Press any key to exit.");
        }

        private static bool ConditionCheck(Func<bool> condition, string msg = null)
        {
            var result = condition.Invoke();
            if (result && !string.IsNullOrWhiteSpace(msg))
                Console.WriteLine(msg);
            return result;
        }

        private static bool CheckEmpty(string entry)
        {
            return ConditionCheck(() => string.IsNullOrWhiteSpace(entry), "Please type a number! Try again.");
        }
    }
}