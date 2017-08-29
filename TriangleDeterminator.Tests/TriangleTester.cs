using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleDeterminator.Tests
{
    [TestClass]
    public class TriangleTester
    {
        private List<Triangle> _scalenes;
        private List<Triangle> _isosceles;
        private List<Triangle> _equilaterals;

        [TestInitialize]
        public void CreateData()
        {
            _equilaterals = GenerateTestEquilaterals();
            _isosceles = GenerateTestIsosceles();
            _scalenes = GenerateTestScalenes();
        }

        [TestMethod]
        public void PositiveTestsEquilaterals()
        {
            foreach (var triangle in _equilaterals)
            {
                var type = TriangleWizard.DetermineType(triangle);
                Assert.Equals(type, TriangleType.Equilateral);
            }
        }

        [TestMethod]
        public void NegativeTestsEquilaterals()
        {
            foreach (var triangle in _equilaterals)
            {
                var type = TriangleWizard.DetermineType(triangle);
                Assert.Equals(type, TriangleType.Equilateral);
            }
        }

        [TestMethod]
        public void TestIsosceles()
        {
            foreach (var triangle in _isosceles)
            {
                var type = TriangleWizard.DetermineType(triangle);
                Assert.Equals(type, TriangleType.Isosceles);
            }
        }

        [TestMethod]
        public void TestEqualsScalenes()
        {
            foreach (var triangle in _scalenes)
            {
                var type = TriangleWizard.DetermineType(triangle);
                Assert.Equals(type, TriangleType.Scalene);
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
                if (scalenes.Contains(triangle))
                    scalenes.Add(triangle);

                if (scalenes.Count == 10)
                    return scalenes;
            }
        }
    }
}