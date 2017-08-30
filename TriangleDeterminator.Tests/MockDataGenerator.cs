using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleDeterminator.Tests
{
    public static class MockDataGenerator
    {
        private static readonly Random Random = new Random();

        public static List<Triangle> GetEquilaterals()
        {
            return Enumerable.Range(1, 100).Select(t => (double)t).Select(t => new Triangle(t / 10.0, t / 10.0, t / 10.0)).ToList();
        }

        /// <summary>
        /// Generates 20 triangles where 2 sides are similar and one is different
        /// </summary>
        /// <returns></returns>
        public static List<Triangle> GetIsosceles()
        {
            var isosceles = new List<Triangle>();
            while (true)
            {
                var a = GetRandomDouble();
                var b = a;
                while (b == a)
                    b = GetRandomDouble();
                try
                {
                    var triangle = new Triangle(a, b, b);
                    if (!isosceles.Contains(triangle))
                        isosceles.Add(triangle);
                    // Base case
                    if (isosceles.Count >= 20)
                        return isosceles;
                }
                catch (Exception e)
                {
                    // We expect some triangle not to follow constraints
                }
            }
        }

        public static List<Triangle> GetScalenes()
        {
            const int testSize = 20;
            var scalenes = new List<Triangle>();
            while (true)
            {
                try
                {
                    var triangle = new Triangle(GetRandomDoubles(3));
                    if (!scalenes.Contains(triangle))
                        scalenes.Add(triangle);
                    if (scalenes.Count >= testSize)
                        return scalenes;
                }
                catch (Exception e)
                {
                    // We expect some triangle not to follow constraints
                }
            }
        }

        private static double[] GetRandomDoubles(int size)
        {
            var sides = new List<double>();

            while (sides.Count < size)
            {
                var randomDouble = GetRandomDouble();
                if (!sides.Contains(randomDouble))
                    sides.Add(randomDouble);
            }
            return sides.ToArray();
        }

        private static double GetRandomDouble() => Math.Round(Random.NextDouble() * 10.0, TriangleExtensions.Decimals);
    }
}