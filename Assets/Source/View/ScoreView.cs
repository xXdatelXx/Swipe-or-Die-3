using Source.UI.Components;
using Source.View.Interfaces;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.View
{
    [RequireComponent(typeof(IText), typeof(Animator))]
    public sealed class ScoreView : MonoBehaviour, IScoreView
    {
        private IText _text;
        private Animator _animator;
        private string _animation => "Set"; 

        private void Awake()
        {
            _text = GetComponent<IText>();
            _animator = GetComponent<Animator>();
        }

        public void OnSetScore(int score)
        {
            _text.Set(score);
            _animator.SetTrigger(_animation);
        }
    }
}