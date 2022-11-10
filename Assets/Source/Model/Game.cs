using JetBrains.Annotations;
using Sirenix.OdinInspector;
using SwipeOrDie.Factory;
using SwipeOrDie.Extension;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.GameLogic
{
    public class Game : SerializedMonoBehaviour
    {
        [SerializeField, CanBeNull] private IGameView _view;
        [SerializeField] private ICharacter _character;
        private IMazeFactory _factory;
        private IGameTimer _gameTimer;

        [Inject]
        public void Construct(IMazeFactory factory, IGameTimer timer)
        {
            _factory = factory.ThrowExceptionIfNull();
            _gameTimer = timer.ThrowExceptionIfNull();
            _character.Disable();
        }

        public void Play()
        {
            _view?.Play();
            _character.Enable();
            _factory.Create(new Score());
            _gameTimer.Play();
        }
    }
}
