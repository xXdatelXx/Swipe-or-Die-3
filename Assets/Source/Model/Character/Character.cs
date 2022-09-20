using Sirenix.OdinInspector;
using Source.Model;
using SwipeOrDie.Extension;
using SwipeOrDie.Input;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public class Character : SerializedMonoBehaviour, ICharacter
    {
        [SerializeField] private ISpeed _speed;
        private ICharacterMovement _movement;
        private IInput _input;

        [Inject]
        public void Construct(IInput input)
        {
            _input = input;

            var radius = new Radius(GetComponent<BoxCollider>().ToCube().Radius());
            var position = new Position(transform, radius);

            _movement = new CharacterMovement(transform, _speed, position);
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Update()
        {
            _movement.Move(_input.Direction);
        }
    }
}