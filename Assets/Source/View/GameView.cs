using Sirenix.OdinInspector;
using SwipeOrDie.Model;
using SwipeOrDie.Ui;
using UnityEngine;

namespace SwipeOrDie.View
{
    public sealed class GameView : SerializedMonoBehaviour, IGameView
    {
        [SerializeField] private Animator _player;
        [SerializeField] private Animator _menu;
        [SerializeField] private Animator _gameUi;
        [SerializeField] private IMazeInstantiateAnimation _maze;
        [SerializeField] private IBackgroundMask _background;
        private readonly string Play = nameof(Play);

        public void View()
        {
            _player.SetTrigger(Play);
            _menu.SetTrigger(Play);
            _gameUi.SetTrigger(Play);
            _maze.Animate();
            _background.Play();
        }
    }
}