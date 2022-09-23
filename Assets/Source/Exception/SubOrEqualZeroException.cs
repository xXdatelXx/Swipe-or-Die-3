namespace System
{
    public class SubOrEqualZeroException : Exception
    {
        public SubOrEqualZeroException(string message) : base($"Value <= 0 {message}")
        {
        }
    }
}