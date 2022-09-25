using System;
using SwipeOrDie.GameLogic;

namespace Source.Model.Timer
{
    public class Losing : ILose
    {
        private readonly ILoseView _view;
        private readonly IPause _pause;
        private bool _lost;

        public Losing(ILoseView view, IPause pause)
        {
            _view = view ?? throw new NullReferenceException(nameof(view));
            _pause = pause ?? throw new NullReferenceException(nameof(pause));
        }

        public void Lose()
        {
            if(_lost)
                return;
            
            _lost = true;
            
            _pause.Pause();
            _view.OnLose();
        }
    }
}