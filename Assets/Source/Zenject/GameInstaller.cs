using Source;
using Source.Model;
using Source.Model.Storage;
using Source.Model.Timer;
using Source.View;
using SwipeOrDie.Factory;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Input;
using SwipeOrDie.View;
using Zenject;
using SwipeOrDie.Data;
using UnityEngine;

// (⊙_⊙)  ¯\_(ツ)_/¯
public class GameInstaller : MonoInstaller
{
    [SerializeField] private CharacterTeleport _characterTeleport;
    [SerializeField] private MazeFactory _mazeFactory;
    [SerializeField] private LoseView _loseView;
    [SerializeField] private TimerView _gameTimerView;
    [SerializeField] private TimeBalance _balance;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private Updatebles _updatebles;
    [SerializeField] private WalletView _walletView;

    public override void InstallBindings()
    {
        var pause = new GamePause();
        var score = new Score(_scoreView);
        var maxScore = new MaxScoreStorage(new PlayerPrefsStorage<int>(nameof(MaxScoreStorage)), score);
        var lose = new Losing(_loseView, pause, maxScore);
        var gameTimer = new GameTimer(lose, _gameTimerView, _balance, new TimerFactory(_updatebles));

        Container.BindInterfacesAndSelfTo<CharacterInput>().FromNew().AsSingle();
        Container.BindInstance((ILevelCreator)new LevelCreator(_mazeFactory, score, _characterTeleport, gameTimer));
        Container.BindInstance((IMazeFactory)_mazeFactory);
        Container.BindInstance((ILose)lose);
        Container.BindInstance((IGameTimer)gameTimer);
        Container.BindInstance((IPause)pause);
        Container.BindInstance((IMaxScore)maxScore);
        Container.BindInstance((IWallet)new Wallet(new PlayerPrefsStorage<int>(nameof(Wallet)), _walletView));
    }
}