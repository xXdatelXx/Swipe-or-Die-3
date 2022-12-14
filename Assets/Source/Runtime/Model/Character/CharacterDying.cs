using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Model
{
    [RequireComponent(typeof(Animator))]
    public sealed class CharacterDying : SerializedMonoBehaviour, IDying
    {
        [SerializeField] private readonly IDyingView _dieView;
        private ILose _lose;
        private Animator _animator;
        private string DieAnimation => "Die";

        [Inject]
        public void Construct(ILose lose) => 
            _lose = lose;

        private void OnEnable()
        {
            _dieView.ThrowExceptionIfNull();
            _lose.ThrowExceptionIfNull();

            _animator = GetComponent<Animator>();
        }

        public void Die()
        {
            _animator.SetTrigger(DieAnimation);
            _dieView.OnDie();
            _lose.Lose();
        }
    }
}