using System;
using System.Collections.Generic;

namespace TriangleDeterminator
{
    /// <summary>
    /// Main class only for fields and constructors
    /// </summary>
    public partial class Triangle
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

        /// <summary>
        /// Takes an array of 3 numbers
        /// </summary>
        /// <param name="asArray"></param>
        public Triangle(IReadOnlyList<double> asArray) : this(asArray[0], asArray[1], asArray[2]) { }
    }

    /// <summary>
    /// Partial class for any helper methods
    /// </summary>
    public partial class Triangle : IEquatable<Triangle>
    {
        public bool Equals(Triangle other) => other != null && A == other.A && B == other.B && C == other.C;

        public override string ToString() => $"A: {A.PadDoubleLeft(6)}, B: {B.PadDoubleLeft(6)}, C: {C.PadDoubleLeft(6)}, Type: {Type}, Area: {Area.PadDoubleLeft(6)}";

        public double Area => this.CalculateAreaHeron();
    }
}