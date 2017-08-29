using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TriangleDeterminator
{
    public class Triangle : IEquatable<Triangle>
    {
        public int A { get; }
        public int B { get; }
        public int C { get; }
        public TriangleType Type { get; set; }
        private IEnumerable<int> AsArray => new int[3] { A, B, C };

        public Triangle(int a, int b, int c, TriangleType type = TriangleType.NotFound)
        {
            A = a;
            B = b;
            C = c;
            Type = type;
            Validate();
        }

        public bool Equals(Triangle other)
        {
            return other != null && A == other.A && B == other.B && C == other.C;
        }

        public void Validate()
        {
            if (AsArray.Any(t => t < 1))
                throw new ArgumentException("A triangle cannot have a side with zero or negative length!");
        }

        public override string ToString()
        {
            return $"A: {A}, B: {B}, C: {C}, Type: {Type}";
        }
    }
}