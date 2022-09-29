using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace SwipeOrDie.View
{
    [RequireComponent(typeof(Animator))]
    public class TimerView : MonoBehaviour, ITimerView
    {
        [SerializeField] private Slider _slider;
        [SerializeField, Range(0, 10)] private float _appendTime;
        private Animator _animator;
        private string _onEnd => nameof(_onEnd);

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnSetTime(float percent, float time)
        {
            // percent / 100 так как slider принимает значение от 0 до 1
            DOTween.Sequence()
                .Append(_slider.DOValue(percent / 100, _appendTime))
                .Append(_slider.DOValue(0, time));
        }

        public void OnEndTime()
        {
            _animator.SetTrigger(_onEnd);
        }
    }
}