using SwipeOrDie.Extension;
using SwipeOrDie.Model;

namespace SwipeOrDie.Ui
{
    public sealed class PlayButtonAction : IButtonAction
    {
        private readonly IGame _game;

        public PlayButtonAction(IGame game) =>
            _game = game.ThrowExceptionIfArgumentNull(nameof(game));

        public void OnClick() => _game.Play();
    }
}