using SwipeOrDie.Storage;
using SwipeOrDie.Factory;
using SwipeOrDie.Model;
using SwipeOrDie.Input;
using Zenject;
using SwipeOrDie.Data;
using SwipeOrDie.Tools;
using SwipeOrDie.View;
using UnityEngine;

// (⊙_⊙)  ¯\_(ツ)_/¯
namespace SwipeOrDie.Zenject
{
    public sealed class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private CharacterTeleport _characterTeleport;
        [SerializeField] private MazeFactory _mazeFactory;
        [SerializeField] private LoseView _loseView;
        [SerializeField] private TimerView _gameTimerView;
        [SerializeField] private TimeBalance _balance;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private Updatebles _updatebles;
        [SerializeField] private Level _level;
        [SerializeField] private CollisionEffectsParent _collisionEffectsParent;
        [SerializeField] private ScoreView _maxScoreView;
        [SerializeField] private ScoreView _loseMaxScoreView;
        [SerializeField] private ScoreView _playedGamesView;
        [SerializeField] private float _inputSensitivity;

        public override void InstallBindings()
        {
            var pause = new GamePause();
            var score = new Score(_scoreView);
            var maxScore =
                new MaxScoreStorage(new BinaryStorage<int>(nameof(MaxScoreStorage)), score, _loseMaxScoreView);
            var lose = new Losing(pause, maxScore, new PlayedGames(_playedGamesView), _loseView);
            var gameTimer = new GameTimer(lose, _gameTimerView, _balance, new TimerFactory(_updatebles));
            pause.Add(gameTimer);
            _level.Init(score);
            _maxScoreView.View(maxScore.Load());

#if UNITY_ANDROID && !UNITY_EDITOR
            Container.BindInstance((IInput)new PhoneInput(_inputSensitivity)).AsSingle();
#else
            Container.BindInstance((IInput)new ComputerInput()).AsSingle();
#endif
            Container.BindInstance((ILevelCreator)new LevelCreator(_mazeFactory, score, _characterTeleport, gameTimer))
                .AsSingle();
            Container.BindInstance((IMazeFactory)_mazeFactory).AsSingle();
            Container.BindInstance((ILose)lose).AsSingle();
            Container.BindInstance((IScore)score).AsSingle();
            Container.BindInstance((IPause)pause).AsSingle();
            Container.BindInstance((IMaxScore)maxScore).AsSingle();
            Container.BindInstance((IGameTimer)gameTimer).AsSingle();
            Container.BindInstance((IWallet)new Wallet(new BinaryStorage<int>(nameof(Wallet)))).AsSingle();
            Container.BindInstance((IStorage<Mesh>)new MeshStorage(nameof(CharacterSkin))).AsSingle();
            Container.BindInstance((ICollisionEffectsParent)_collisionEffectsParent).AsSingle();
        }
    }
}