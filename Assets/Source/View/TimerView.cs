using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace SwipeOrDie.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class TimerView : MonoBehaviour, ITimerView
    {
        [SerializeField] private Image _slider;
        [SerializeField, Range(0, 10)] private float _appendTime;
        private Animator _animator;
        private string _onEndTime => nameof(_onEndTime);
        private string _onPlayerLose => nameof(_onPlayerLose);

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnSetTime(float time, float percent = 100)
        {
            DOTween.Sequence()
                .Append(_slider.DOFillAmount(percent / 100, _appendTime))
                .Append(_slider.DOFillAmount(0, time - _appendTime));
        }

        public void OnEndTime() => 
            _animator.SetTrigger(_onEndTime);

        public void Stop() => 
            _animator.SetTrigger(_onPlayerLose);
    }
}