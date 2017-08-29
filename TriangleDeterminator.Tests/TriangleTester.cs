using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TriangleDeterminator.Tests
{
    [TestFixture]
    public class TriangleTester
    {
        private List<Triangle> _scalenes;
        private List<Triangle> _isosceles;
        private List<Triangle> _equilaterals;
        private static readonly Random Random = new Random();

        [SetUp]
        public void CreateData()
        {
            _equilaterals = GenerateTestEquilaterals();
            _isosceles = GenerateTestIsosceles();
            _scalenes = GenerateTestScalenes();
        }

        [Test]
        public void TestMaxValues()
        {
            // double
            var triangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);
            var type = TriangleExtensions.DetermineType(triangle);
            Assert.AreEqual(TriangleType.Equilateral, type);
            Assert.IsTrue(double.IsInfinity(triangle.Area)); // We simply don't want to calculate numbers this large anyways.

            // int
            var intTriangle = new Triangle(int.MaxValue, int.MaxValue, int.MaxValue);
            var intType = TriangleExtensions.DetermineType(intTriangle);
            Assert.AreEqual(TriangleType.Equilateral, intType);

            // float
            var floatTriangle = new Triangle(float.MaxValue, float.MaxValue, float.MaxValue);
            var floatType = TriangleExtensions.DetermineType(floatTriangle);
            Assert.AreEqual(TriangleType.Equilateral, floatType);

            // int, double, float
            Assert.ThrowsException<TriangleDimensionException>(() => new Triangle(int.MaxValue, double.MaxValue, float.MaxValue)); // Due to the triangle rule
        }

        [Test]
        public void TestsEquilaterals()
        {
            foreach (var triangle in _equilaterals)
            {
                var type = TriangleExtensions.DetermineType(triangle);
                Assert.AreEqual(TriangleType.Equilateral, type);
            }
        }

        [Test]
        public void InvalidDimensionsTests()
        {
            Assert.ThrowsException<TriangleDimensionException>(() => { new Triangle(1, 1, 10); });
        }

        [Test]
        public void NegativeTests()
        {
            Assert.ThrowsException<TriangleNegativParameterException>(() => TriangleExtensions.DetermineType(new Triangle(-1, -1, -1)));
        }

        [Test]
        public void TestIsosceles()
        {
            foreach (var triangle in _isosceles)
            {
                var type = TriangleExtensions.DetermineType(triangle);
                Assert.AreEqual(TriangleType.Isosceles, type);
            }
        }

        [Test]
        public void TestScalenes()
        {
            foreach (var triangle in _scalenes)
            {
                var type = TriangleExtensions.DetermineType(triangle);
                Assert.AreEqual(TriangleType.Scalene, type);
            }
        }

        private static List<Triangle> GenerateTestEquilaterals()
        {
            return Enumerable.Range(1, 100).Select(t => (double)t).Select(t => new Triangle(t / 10.0, t / 10.0, t / 10.0)).ToList();
        }

        /// <summary>
        /// Generates 20 triangles where 2 sides are similar and one is different
        /// </summary>
        /// <returns></returns>
        private static List<Triangle> GenerateTestIsosceles()
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

        private static List<Triangle> GenerateTestScalenes()
        {
            var scalenes = new List<Triangle>();
            while (true)
            {
                var sides = new List<double>();

                while (sides.Count < 3)
                {
                    var randomDouble = GetRandomDouble();
                    if (!sides.Contains(randomDouble))
                        sides.Add(randomDouble);
                }

                try
                {
                    var triangle = new Triangle(sides.ToArray());
                    if (!scalenes.Contains(triangle))
                        scalenes.Add(triangle);
                    // Base case
                    if (scalenes.Count >= 20)
                        return scalenes;
                }
                catch (Exception e)
                {
                    // We expect some triangle not to follow constraints
                }
            }
        }

        private static double GetRandomDouble() => Math.Round(Random.NextDouble() * 10.0, TriangleExtensions.Decimals);
    }
}