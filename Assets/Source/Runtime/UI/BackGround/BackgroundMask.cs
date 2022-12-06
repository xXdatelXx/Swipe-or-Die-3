using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using SwipeOrDie.Tools;

namespace SwipeOrDie.Ui
{
    [RequireComponent(typeof(Image))]
    public sealed class BackgroundMask : MonoBehaviour, IBackgroundMask, IPauseHandler
    {
        [SerializeField] private Color _endColor;
        [SerializeField, Min(0)] private float _duration;
        private Image _image;
        private Tween _tween;

        private void OnEnable()
        {
            _image = GetComponent<Image>();
            _tween = _image.DOColor(_endColor, _duration).Pause();
        }

        public void Play() => _tween.Play();

        public void Enable() => Play();

        public void Disable() => _tween.Kill();
    }
}
