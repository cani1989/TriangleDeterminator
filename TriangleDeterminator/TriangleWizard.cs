using System;
using System.Linq;

namespace TriangleDeterminator
{
    public static class TriangleWizard
    {
        /// <summary>
        /// Determines the type of three sides of a triangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static TriangleType DetermineType(int a, int b, int c)
        {
            var sides = new[] { a, b, c };
            if (sides.Any(t => t < 1))
                throw new ArgumentException("A triangle cannot have a side with zero or negative length!");

            var distinctSideCount = sides.Distinct().Count();

            // Check uniqueness of sides
            switch (distinctSideCount)
            {
                case 1:
                    return TriangleType.Equilateral;
                case 2:
                    return TriangleType.Isosceles;
                case 3:
                    return TriangleType.Scalene;
                default:
                    return TriangleType.NotFound;
            }
        }

        public static TriangleType DetermineType(Triangle triangle)
        {
            return DetermineType(triangle.A, triangle.B, triangle.C);
        }
    }
}