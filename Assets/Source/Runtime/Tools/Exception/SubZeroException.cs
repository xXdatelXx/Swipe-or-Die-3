namespace System
{
    public sealed class SubZeroException : Exception
    {
        public SubZeroException(string message) : base($"Value is sub zero! Value {message}")
        {
        }
    }
}