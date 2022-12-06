namespace System
{
    public sealed class SubOrEqualZeroException : Exception
    {
        public SubOrEqualZeroException(string message) : base($"Value <= 0 {message}")
        {
        }
    }
}