using DG.Tweening;
using UnityEngine;

namespace Source
{
    [RequireComponent((typeof(Mesh)))]
    public class CharacterMovementView : MonoBehaviour, IMovementView
    {
        [SerializeField, Min(0)] private float _stopForce;
        [SerializeField, Min(0)] private float _stopTime;
        private Mesh _mesh;
        private Vector3 _standartScale;

        private void Awake()
        {
            _mesh = GetComponent<Mesh>();
            _standartScale = transform.localScale;
        }

        public void OnMove(Vector2 direction)
        {
            transform.DOScaleX();   
        }

        public void OnStop()
        {
            DOTween.Sequence()
                .Append(transform.DOScale(_standartScale / _stopForce, _stopTime))
                .Append(transform.DOScale(_standartScale,));
        }
    }
}