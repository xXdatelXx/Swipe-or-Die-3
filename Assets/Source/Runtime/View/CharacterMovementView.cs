using Sirenix.OdinInspector;
using SwipeOrDie.Tools;
using UnityEngine;

namespace SwipeOrDie.View
{
    public sealed class CharacterMovementView : SerializedMonoBehaviour, IMovementView
    {
        [SerializeField, Min(0)] private float _force;
        [SerializeField, Min(0)] private float _moveDuration;
        [SerializeField] private ICameraSnaking _cameraSnaking;
        [SerializeField] private AudioSource _audio;
        private ISideScale _scale;

        private void Awake() =>
            _scale = new SideScale(_force, _moveDuration, transform);

        public void OnMove(Vector3 direction)
        {
            _scale.Scale(direction);
            _cameraSnaking.Snake(direction);
            _audio.Play();
        }

        public void OnStop() => _scale.Reset();
    }
}