using System;

namespace SwipeOrDie.Extension
{
    public static class ExceptionExtension
    {
        public static dynamic ThrowExceptionIfValueSubZero(this IComparable value) => 
            (dynamic)value < 0 ? throw new SubZeroException(nameof(value)) : value;

        public static dynamic ThrowExceptionIfValueSubOrEqualZero(this IComparable value) => 
            (dynamic)value <= 0 ? throw new SubOrEqualZeroException(nameof(value)) : value;

        public static T ThrowExceptionIfNull<T>(this T value, string name = "value") => 
            value ?? throw new NullReferenceException($"{name} == null");
        
        public static T ThrowExceptionIfArgumentNull<T>(this T value, string name = "value") => 
            value ?? throw new ArgumentNullException($"{name} == null");
    }
}