using Source;
using Source.Model.Storage;
using Source.UI;
using Source.View;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Ui;
using UnityEditor;
using UnityEngine;

namespace SwipeOrDie.Roots
{
    public sealed class GameUiRoot : CompositeRoot
    {
        [SerializeField] private IGame _game;
        [SerializeField] private SoundButton _sound;
        [SerializeField] private IView<bool> _soundView;
        [SerializeField] private TrainingButton _training;
        [SerializeField] private TrainingUi _trainingUi;
        [SerializeField] private UrlButton _telegram;
        [SerializeField] private Url _telegramUrl;
        [SerializeField] private UrlButton _rate;
        [SerializeField] private Url _rateUrl;
        [SerializeField] private SceneButton _shop;
        [SerializeField] private SceneAsset _shopScene;
        [SerializeField] private SceneAsset _gameScene;
        [SerializeField] private SceneButton _restartScene;
        [SerializeField] private OptionButton _option;
        [SerializeField] private PlayButton _play;

        public override void Compose()
        {
            _sound.Subscribe(new NegateAction(new Volume(new NegateStorage(new BinaryStorage<bool>(nameof(Volume)), _soundView))));
            _training.Subscribe(new NegateAction(_trainingUi));
            _telegram.Subscribe(new UrlButtonAction(_telegramUrl));
            _rate.Subscribe(new UrlButtonAction(_rateUrl));
            _shop.Subscribe(new SwitchSceneButtonAction(_shopScene));
            _restartScene.Subscribe(new SwitchSceneButtonAction(_gameScene));
            _option.Subscribe(new DropDawnButtonAction(false, _telegram, _sound, _training));
            _play.Subscribe(new PlayButtonAction(_game));
        }
    }
}