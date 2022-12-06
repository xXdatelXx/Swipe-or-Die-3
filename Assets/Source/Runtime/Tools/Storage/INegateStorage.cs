namespace SwipeOrDie.Storage
{
    public interface INegateStorage
    {
        void Negate();
        bool Value { get; }
    }
}