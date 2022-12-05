namespace SwipeOrDie.Tools
{
    public interface ITimer : IAsyncTimer
    {
        float AccumulatedTime { get; }
        void Effect(float effect);
    }
}
