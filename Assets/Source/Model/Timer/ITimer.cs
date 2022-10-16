namespace SwipeOrDie.GameLogic
{
    public interface ITimer : IAsyncTimer
    {
        float AccumulatedTime { get; }
        void Effect(float effect);
    }
}
