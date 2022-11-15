using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    [RequireComponent(typeof(Animator))]
    public sealed class CharacterTeleportView : MonoBehaviour, ICharacterTeleportView
    {
        private Animator _animator;
        private string _startAnimation => "TeleportStart";
        private string _endAnimation => "TeleportEnd";

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void OnStart() => 
            _animator.SetTrigger(_startAnimation);

        public void OnEnd() => 
            _animator.SetTrigger(_endAnimation);
    }
}