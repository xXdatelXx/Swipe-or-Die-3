using Sirenix.OdinInspector;
using Source.Model;
using SwipeOrDie.Extension;
using SwipeOrDie.Input;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public class Character : SerializedMonoBehaviour, ICharacter, IPauseHandler
    {
        [SerializeField] private ISpeed _speed;
        private ICharacterMovement _movement;
        private IInput _input;

        [Inject]
        public void Construct(IInput input)
        {
            _input = input;

            var radius = new Radius(GetComponent<BoxCollider>().ToCube().Radius());
            var position = new RayPosition(transform, radius);

            _movement = new CharacterMovement(transform, _speed, position);

            Enable();
        }

        private void Update()
        {
            _movement.Move(_input.Direction);
        }

        public void Enable() => _input.Enable();

        public void Disable() => _input.Disable();

        public void OnPause() => Disable();
        
        public void OnPlay() => Enable();
    }
}