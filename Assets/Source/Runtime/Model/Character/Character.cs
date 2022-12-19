using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using SwipeOrDie.Input;
using SwipeOrDie.Tools;
using SwipeOrDie.View;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.Model
{
    [RequireComponent(typeof(BoxCollider)), SelectionBase]
    public sealed class Character : SerializedMonoBehaviour, ICharacter, IPauseHandler
    {
        [SerializeField] private ISpeed _speed;
        [SerializeField] private IMovementView _movementView;
        private ICharacterMovement _movement;
        private IInput _input;

        [Inject]
        public void Construct(IInput input)
        {
            _input = input;

            var radius = new Radius(GetComponent<BoxCollider>().ToCube().Radius());
            var position = new RayPosition(transform, radius);

            _movement = new CharacterMovement(new InterpolationMovement(transform, _speed), position, transform, _movementView);
        }

        private void Update() =>
            _movement.Move(_input.Direction);

        public void Enable() => _input.Enable();
        public void Disable() => _input.Disable();
    }
}