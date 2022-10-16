using SwipeOrDie.GameLogic;

namespace SwipeOrDie.Factory
{
    public interface ITimerFactory
    {
        ITimer Create(float time);
    }
}