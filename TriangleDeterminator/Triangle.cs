using System;
using System.Collections;

namespace TriangleDeterminator
{
    public class Triangle : IEquatable<Triangle>
    {
        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public int A { get; }
        public int B { get; }
        public int C { get; }

        public bool Equals(Triangle other)
        {
            return other != null && A == other.A && B == other.B && C == other.C;
        }
    }
}