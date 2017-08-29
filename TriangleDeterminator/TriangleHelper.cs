﻿using System;
using System.Linq;

namespace TriangleDeterminator
{
    public static class TriangleHelper
    {
        public const int Decimals = 2;

        // Overload
        public static TriangleType DetermineType(double a, double b, double c) => DetermineType(new Triangle(a, b, c));

        /// <summary>
        /// Returns the type of a given triangle
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns>Dependant on distinct sides the relevant triangle type</returns>
        public static TriangleType DetermineType(Triangle triangle)
        {
            // Validate the triangle hasn't been tampered with
            triangle.Validate();

            var sides = new[] { triangle.A, triangle.B, triangle.C };
            var distinctSideCount = sides.Distinct().Count();

            // Check uniqueness of sides
            switch (distinctSideCount)
            {
                case 1:
                    triangle.Type = TriangleType.Equilateral; break;
                case 2:
                    triangle.Type = TriangleType.Isosceles; break;
                case 3:
                    triangle.Type = TriangleType.Scalene; break;
                default:
                    triangle.Type = TriangleType.NotFound; break;
            }
            return triangle.Type;
        }

        /// <summary>
        /// Calculates the area of a triangle using Heron's formula
        /// </summary>
        /// <returns></returns>
        public static double CalculateAreaHeron(this Triangle triangle)
        {
            var s = triangle.A + triangle.B + triangle.C / 2.0;
            var partA = Math.Round(s - triangle.A, Decimals);
            var partB = Math.Round(s - triangle.B, Decimals);
            var partC = Math.Round(s - triangle.C, Decimals);
            var sqrt = Math.Sqrt(s * partA * partB * partC);
            return Math.Round(sqrt, Decimals);
        }

    }
}