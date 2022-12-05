using FluentValidation;
using JetBrains.Annotations;
using SwipeOrDie.Storage;
using SwipeOrDie.Tools;
using SwipeOrDie.View;

namespace SwipeOrDie.Model
{
    public sealed class Losing : ILose
    {
        private readonly IPause _pause;
        private readonly IMaxScore _maxScore;
        private readonly IPlayedGames _playedGames;
        [CanBeNull] private readonly IView _view;
        private bool _lost;

        public Losing(IPause pause, IMaxScore maxScore, IPlayedGames playedGames, IView view = null)
        {
            _pause = pause;
            _maxScore = maxScore;
            _view = view;
            _playedGames = playedGames;

            new Validator().ValidateAndThrow(this);
        }

        public void Lose()
        {
            if (_lost)
                return;

            _lost = true;

            _playedGames.Add();
            _maxScore.TrySave();
            _pause.Pause();
            _view?.View();
        }

        private class Validator : AbstractValidator<Losing>
        {
            public Validator()
            {
                RuleFor(lose => lose._pause).NotNull();
                RuleFor(lose => lose._maxScore).NotNull();
                RuleFor(lose => lose._playedGames).NotNull();
            }
        }
    }
}