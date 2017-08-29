using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleDeterminator
{
    public class Triangle : IEquatable<Triangle>
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public TriangleType Type { get; set; }
        public IEnumerable<double> AsArray => new[] { A, B, C };

        public Triangle(double a, double b, double c, TriangleType type = TriangleType.NotFound)
        {
            A = a;
            B = b;
            C = c;
            Type = type;
            Validate();
        }

        public Triangle(double[] toArray) : this(toArray[0], toArray[1], toArray[2])
        {

        }

        public bool Equals(Triangle other)
        {
            return other != null && A == other.A && B == other.B && C == other.C;
        }

        public void Validate()
        {
            if (AsArray.Any(t => t <= 0))
                throw new TriangleNegativParameterException();

            if (Area == Double.NaN)
                throw new IndexOutOfRangeException("One side has to many digits to calculate area");

            // A prerequisite for a triangle is that the total length of the two smallest sides are longer than the longest side. 
            var array = AsArray.ToList();
            var longestSide = array.Max();
            array.RemoveAt(array.IndexOf(longestSide));
            var shorterSides = array.Sum();
            if (shorterSides < longestSide)
            {
                throw new TriangleDimensionException();
            }
        }

        public override string ToString() => $"A: {A.PadDoubleLeft(6)}, B: {B.PadDoubleLeft(6)}, C: {C.PadDoubleLeft(6)}, Type: {Type}, Area: {Area.PadDoubleLeft(6)}";

        public double Area => this.CalculateAreaHeron();

    }
}