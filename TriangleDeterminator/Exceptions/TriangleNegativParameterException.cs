using System;

namespace TriangleDeterminator
{
    public class TriangleNegativParameterException : Exception
    {
        public TriangleNegativParameterException() : base("A triangle cannot have a side with zero or negative length!")
        {
        }
    }
}