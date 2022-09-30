using Source.Model;
using Source.View.Interfaces;
using SwipeOrDie.Extension;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.View
{
    [RequireComponent(typeof(Text), typeof(IScoreView))]
    public class MaxScoreText : MonoBehaviour
    {
        private IMaxScore _maxScore;
        private Text _text;
        private IScoreView _view;
        private int _score;

        [Inject]
        public void Construct(IMaxScore maxScore)
        {
            _maxScore = maxScore;
            _text = GetComponent<Text>();
            _view = GetComponent<IScoreView>();
            _score = int.Parse(_text.text);
        }

        private void Awake()
        {
            Set();
        }

        private void Set()
        {
            if(!_maxScore.Exists())
                return;

            int maxScore = _maxScore.Load().Value;

            if (_score < maxScore)
            {
                _text.Set(maxScore);
                _view.OnSetScore(maxScore);
            }
        }
    }
} 