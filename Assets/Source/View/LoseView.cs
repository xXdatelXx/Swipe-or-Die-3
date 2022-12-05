using JetBrains.Annotations;
using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using SwipeOrDie.Model;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.View
{
    public sealed class LoseView : SerializedMonoBehaviour, IView
    {
        [SerializeField] private IScoreView _scoreView;
        [SerializeField, CanBeNull] private IView _chain;
        private IScore _score;

        [Inject]
        public void Construct(IScore score) => 
            _score = score.ThrowExceptionIfArgumentNull(nameof(score));

        public void View()
        {
            _scoreView.View(_score.Value);
            _chain?.View();
        }
    }
}