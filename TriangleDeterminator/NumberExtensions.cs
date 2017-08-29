using System.Globalization;

namespace TriangleDeterminator
{
    public static class NumberExtensions
    {
        public static string PadDoubleLeft(this double number, int padding) => number.ToString(CultureInfo.InvariantCulture).PadLeft(padding);
    }
}