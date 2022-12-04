using Sirenix.OdinInspector;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace Source.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class CharacterDyingView : SerializedMonoBehaviour, IDyingView
    {
        [SerializeField] private ICameraSnaking _snaking;
        private Animator _animator; 
        private string _dieAnimation => nameof(OnDie);

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void OnDie()
        {
            _animator.SetTrigger(_dieAnimation);
            _snaking.LoseSnake();
        }
    }
}