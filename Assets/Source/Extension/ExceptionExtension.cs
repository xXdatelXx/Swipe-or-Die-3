using System;

namespace SwipeOrDie.Extension
{
    public static class ExceptionExtension
    {
        public static dynamic TryThrowSubZeroException(this IComparable value)
        {
            if ((dynamic)value < 0)
                throw new SubZeroException(nameof(value));

            return value;
        }

        public static dynamic TryThrowSubOrEqualZeroException(this IComparable value)
        {
            if ((dynamic)value <= 0)
                throw new SubOrEqualZeroException(nameof(value));

            return value;
        }

        public static T TryThrowNullReferenceException<T>(this T value, string name = "value") => 
            value ?? throw new NullReferenceException($"{name} == null");
        
        public static T TryThrowArgumentNullException<T>(this T value, string name = "value") => 
            value ?? throw new ArgumentNullException($"{name} == null");
    }
}