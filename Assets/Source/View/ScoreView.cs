using Source.View.Interfaces;
using SwipeOrDie.Extension;
using UnityEngine;
using UnityEngine.UI;

namespace Source.View
{
    [RequireComponent(typeof(Text), typeof(Animator))]
    public class ScoreView : MonoBehaviour, IScoreView
    {
        private Text _text;
        private Animator _animator;
        private string _animation => "Set"; 

        private void Awake()
        {
            _text = GetComponent<Text>();
            _animator = GetComponent<Animator>();
        }

        public void OnSetScore(int score)
        {
            _text.Set(score);
            _animator.SetTrigger(_animation);
        }
    }
}