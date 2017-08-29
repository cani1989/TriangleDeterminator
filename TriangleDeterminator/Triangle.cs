using System;
using System.Collections.Generic;

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
            this.Validate();
        }

        public Triangle(double[] toArray) : this(toArray[0], toArray[1], toArray[2])
        {
        }

        public bool Equals(Triangle other) => other != null && A == other.A && B == other.B && C == other.C;

        public override string ToString() => $"A: {A.PadDoubleLeft(6)}, B: {B.PadDoubleLeft(6)}, C: {C.PadDoubleLeft(6)}, Type: {Type}, Area: {Area.PadDoubleLeft(6)}";

        public double Area => this.CalculateAreaHeron();
    }
}