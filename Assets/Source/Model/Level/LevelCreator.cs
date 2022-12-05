using FluentValidation;
using SwipeOrDie.Factory;

namespace SwipeOrDie.Model
{
    public sealed class LevelCreator : ILevelCreator
    {
        private readonly IMazeFactory _factory;
        private readonly Score _score;
        private readonly ICharacterTeleport _teleport;
        private readonly IGameTimer _gameTimer;

        public LevelCreator(IMazeFactory factory, Score score, ICharacterTeleport teleport, IGameTimer gameTimer)
        {
            _factory = factory;
            _score = score;
            _teleport = teleport;
            _gameTimer = gameTimer;

            new Validator().ValidateAndThrow(this);
        }

        public void Create()
        {
            _gameTimer.AddTime();
            _score.Append();
            _factory.Destroy();
            _teleport.Teleport(_factory.Create(_score).StartPoint);
        }

        private class Validator : AbstractValidator<LevelCreator>
        {
            public Validator()
            {
                RuleFor(creator => creator._factory).NotNull();
                RuleFor(creator => creator._score).NotNull();
                RuleFor(creator => creator._teleport).NotNull();
                RuleFor(creator => creator._gameTimer).NotNull();
            }
        }
    }
}
