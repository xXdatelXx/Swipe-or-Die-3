using JetBrains.Annotations;
using Sirenix.OdinInspector;
using SwipeOrDie.Ui;
using UnityEngine;

namespace SwipeOrDie.View
{
    public sealed class ScoreView : SerializedMonoBehaviour, IScoreView
    {
        [SerializeField] private string _prefix;
        [SerializeField] private IText _text;
        [SerializeField, HideIf("_animator", null)] private bool _animate = true;
        [SerializeField, CanBeNull, ShowIf("_animate")] private Animator _animator;
        private string _animation => "Set";

        public void View(int score)
        {
            _text.Set(_prefix + score);
            if(_animator != null)
                _animator.SetTrigger(_animation);
        }
    }
}