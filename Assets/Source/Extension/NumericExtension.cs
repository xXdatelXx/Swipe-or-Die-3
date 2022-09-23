using System;

namespace SwipeOrDie.Extension
{
    public static class NumericExtension
    {
        public static dynamic TryThrowSubZeroException(this IComparable value)
        {
            if (value.CompareTo(0) < 0)
                throw new SubZeroException(nameof(value));

            return value;
        }

        public static dynamic TryThrowSubOrEqualZeroException(this IComparable value)
        {
            if (value.CompareTo(0) <= 0)
                throw new SubZeroException(nameof(value));

            return value;
        }
    }
}