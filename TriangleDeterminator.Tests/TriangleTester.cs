using NUnit.Framework;
using System.Collections.Generic;
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
            _equilaterals = MockDataGenerator.GetEquilaterals();
            _isosceles = MockDataGenerator.GetIsosceles();
            _scalenes = MockDataGenerator.GetScalenes();
        }

        [Test]
        public void TestEdgeVase()
        {
            Assert.ThrowsException<TriangleDimensionException>(() => new Triangle(2, 3, 5));
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
    }
}