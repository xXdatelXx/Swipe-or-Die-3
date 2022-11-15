using Source.Model;
using Source.UI.Components;
using Source.View.Interfaces;
using SwipeOrDie.Extension;
using UnityEngine;
using Zenject;

namespace Source.View
{
    [RequireComponent(typeof(IText), typeof(IScoreView))]
    public sealed class MaxScoreText : MonoBehaviour
    {
        private IMaxScore _maxScore;
        private IText _text;
        private IScoreView _view;
        private int _score;

        [Inject]
        public void Construct(IMaxScore maxScore)
        {
            _maxScore = maxScore;
            _text = GetComponent<IText>();
            _view = GetComponent<IScoreView>();
        }

        private void Awake() => Set();

        private void Set()
        {
            var maxScore = _maxScore.Load();
            if (_score < maxScore)
            {
                _text.Set(maxScore);
                _view.OnSetScore(maxScore);
            }
        }
    }
} 