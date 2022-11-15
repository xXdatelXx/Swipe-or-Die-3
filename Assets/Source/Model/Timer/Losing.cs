using FluentValidation;
using SwipeOrDie.GameLogic;

namespace Source.Model.Timer
{
    public sealed class Losing : ILose
    {
        private readonly ILoseView _view;
        private readonly IPause _pause;
        private readonly IMaxScore _maxScore;
        private bool _lost;

        public Losing(ILoseView view, IPause pause, IMaxScore maxScore)
        {
            _view = view;
            _pause = pause;
            _maxScore = maxScore;

            new Validator().ValidateAndThrow(this);
        }

        public void Lose()
        {
            if (_lost)
                return;

            _lost = true;

            _maxScore.TrySave();
            _pause.Pause();
            _view.OnLose();
        }

        private class Validator : AbstractValidator<Losing>
        {
            public Validator()
            {
                RuleFor(lose => lose._view).NotNull();
                RuleFor(lose => lose._pause).NotNull();
                RuleFor(lose => lose._maxScore).NotNull();
            }
        }
    }
}