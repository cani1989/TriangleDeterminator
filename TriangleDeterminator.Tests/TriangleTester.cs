using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TriangleDeterminator.Tests
{
    [TestFixture]
    public class TriangleTester
    {
        private List<Triangle> _scalenes;
        private List<Triangle> _isosceles;
        private List<Triangle> _equilaterals;

        [SetUp]
        public void CreateData()
        {
            _equilaterals = GenerateTestEquilaterals();
            _isosceles = GenerateTestIsosceles();
            _scalenes = GenerateTestScalenes();
        }

        [Test]
        public void TestsEquilaterals()
        {
            foreach (var triangle in _equilaterals)
            {
                var type = TriangleHelper.DetermineType(triangle);
                Assert.AreEqual(type, TriangleType.Equilateral);
            }
        }

        [Test]
        public void NegativeTests()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleHelper.DetermineType(new Triangle(-1, -1, -1)));
        }

        [Test]
        public void TestIsosceles()
        {
            foreach (var triangle in _isosceles)
            {
                var type = TriangleHelper.DetermineType(triangle);
                Assert.AreEqual(type, TriangleType.Isosceles);
            }
        }

        [Test]
        public void TestScalenes()
        {
            foreach (var triangle in _scalenes)
            {
                var type = TriangleHelper.DetermineType(triangle);
                Assert.AreEqual(type, TriangleType.Scalene);
            }
        }

        private static List<Triangle> GenerateTestEquilaterals()
        {
            return Enumerable.Range(1, 10).Select(t => new Triangle(t, t, t)).ToList();
        }

        private static List<Triangle> GenerateTestIsosceles()
        {
            const int fixedSide = 4;
            return Enumerable.Range(1, 10).Where(t => t != fixedSide).Select(t => new Triangle(t, t, fixedSide)).ToList();
        }

        private static List<Triangle> GenerateTestScalenes()
        {
            var random = new Random();
            var scalenes = new List<Triangle>();
            while (true)
            {
                var a = random.Next(1, 10);
                var b = a + random.Next(1, 10);
                var c = b + random.Next(1, 10);
                var triangle = new Triangle(a, b, c);
                if (!scalenes.Contains(triangle))
                    scalenes.Add(triangle);

                if (scalenes.Count >= 10)
                    return scalenes;
            }
        }
    }
}