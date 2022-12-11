using JetBrains.Annotations;
using Sirenix.OdinInspector;
using SwipeOrDie.Factory;
using SwipeOrDie.Extension;
using SwipeOrDie.View;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.Model
{
    public sealed class Game : SerializedMonoBehaviour, IGame
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
        }

        public void Play()
        {
            _view?.View();
            _character.Enable();
            _factory.Create();
            _gameTimer.Play();
        }
    }
}
