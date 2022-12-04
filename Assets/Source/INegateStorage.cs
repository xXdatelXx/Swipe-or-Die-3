namespace SwipeOrDie.Roots
{
    public interface INegateStorage
    {
        void Negate();
        bool Value { get; }
    }
}