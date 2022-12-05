using SwipeOrDie.Model;
using SwipeOrDie.Tools;

namespace SwipeOrDie.Factory
{
    public interface ITimerFactory
    {
        ITimer Create(float time);
    }
}