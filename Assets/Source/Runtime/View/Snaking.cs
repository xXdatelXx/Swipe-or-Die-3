using DG.Tweening;
using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.View
{
    [RequireComponent(typeof(Camera))]
    public sealed class Snaking : MonoBehaviour, ICameraSnaking
    {
        [SerializeField] private float _force;
        [SerializeField, Min(0)] private float _duration;
        [SerializeField] private float _loseForce;
        [SerializeField, Min(0)] private float _loseDuration;
        private Camera _camera;
        private Vector3 _standardPosition;

        private void OnEnable()
        {
            _camera = GetComponent<Camera>();
            _standardPosition = transform.position;
        }

        public void Snake(Vector3 direction) =>
            transform.DOYOYOMove(_standardPosition, direction * _force, _duration);

        public void LoseSnake()
        {
            DOTween.Sequence()
                .Append(_camera.DOFieldOfView(_camera.fieldOfView + _loseForce, _loseDuration))
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }
    }
}