using UnityEngine;
using System.Threading.Tasks;
using FluentValidation;
using Sirenix.OdinInspector;

namespace SwipeOrDie.GameLogic
{
    [RequireComponent(typeof(ICharacterTeleportView), typeof(ICharacter))]
    public sealed class CharacterTeleport : SerializedMonoBehaviour, ICharacterTeleport
    {
        [SerializeField] private IAsyncTimer _timer;
        private ICharacter _character;
        private ICharacterTeleportView _view;

        private void Awake()
        {
            _character = GetComponent<ICharacter>();
            _view = GetComponent<ICharacterTeleportView>();

            new Validator().ValidateAndThrow(this);
        }

        public async void Teleport(IStartPoint target)
        {
            await Begin();

            transform.position = target.Position;
            transform.eulerAngles = target.EulerAngles;
            transform.parent = target.Parent;

            OnEnd();
        }

        private async Task Begin()
        {
            _character.Disable();
            _view.OnStart();

            await _timer.Play();
        }

        private void OnEnd()
        {
            _character.Enable();
            _view.OnEnd();
        }

        private class Validator : AbstractValidator<CharacterTeleport>
        {
            public Validator()
            {
                RuleFor(teleport => teleport._timer).NotNull();
                RuleFor(teleport => teleport._character).NotNull();
                RuleFor(teleport => teleport._view).NotNull();
            }
        }
    }
}