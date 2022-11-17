using System;

namespace SwipeOrDie.Extension
{
    public static class ExceptionExtension
    {
        public static dynamic ThrowExceptionIfValueSubZero(this IComparable value, string name = "value") => 
            (dynamic)value < 0 ? throw new SubZeroException(name) : value;

        public static dynamic ThrowExceptionIfValueSubOrEqualZero(this IComparable value, string name = "value") => 
            (dynamic)value <= 0 ? throw new SubOrEqualZeroException(name) : value;

        public static T ThrowExceptionIfNull<T>(this T value, string name = "value") => 
            value ?? throw new NullReferenceException($"{name} == null");
        
        public static T ThrowExceptionIfArgumentNull<T>(this T value, string name = "value") => 
            value ?? throw new ArgumentNullException($"{name} == null");
    }
}