using FluentValidation;

public class LevelCreator
{
    private readonly MazeFactory _factory;
    private readonly Score _score;
    private readonly ICharacterTeleport _teleport;

    public LevelCreator(MazeFactory factory, Score score, ICharacterTeleport teleport)
    {
        _factory = factory;
        _score = score;
        _teleport = teleport;

        new Validator().ValidateAndThrow(this);
    }

    public void Create()
    {
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
        }
    }
}
