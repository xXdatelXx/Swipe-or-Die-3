using Source.Model.Timer;
using SwipeOrDie.Extension;
using SwipeOrDie.GameLogic;

namespace SwipeOrDie.Factory
{
    public sealed class TimerFactory : ITimerFactory
    {
        private readonly IUpdatebles _updatebles;

        public TimerFactory(IUpdatebles updatebles) => 
            _updatebles = updatebles.ThrowExceptionIfNull();

        public ITimer Create(float time)
        {
            var timer = new Timer(time);
            _updatebles.Add(timer);

            return timer;
        }
    }
}