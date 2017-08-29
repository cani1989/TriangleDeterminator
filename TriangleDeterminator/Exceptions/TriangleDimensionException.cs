using System;

namespace TriangleDeterminator
{
    public class TriangleDimensionException : Exception
    {
        public TriangleDimensionException() : base("A prerequisite for a triangle is that the total length of the two smallest sides are longer than the longest side!")
        {
        }
    }
}