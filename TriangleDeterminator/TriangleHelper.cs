using System.Linq;

namespace TriangleDeterminator
{
    public class TriangleHelper
    {
        public static TriangleType DetermineType(Triangle triangle)
        {
            triangle.Validate();

            var sides = new[] { triangle.A, triangle.B, triangle.C };
            
            var distinctSideCount = sides.Distinct().Count();

            // Check uniqueness of sides
            switch (distinctSideCount)
            {
                case 1:
                    return TriangleType.Equilateral;
                case 2:
                    return TriangleType.Isosceles;
                case 3:
                    return TriangleType.Scalene;
                default:
                    return TriangleType.NotFound;
            }
        }
    }
}