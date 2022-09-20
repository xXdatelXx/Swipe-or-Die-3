using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class CharacterDying : SerializedMonoBehaviour, IDying
    {
        [SerializeField] private readonly IDyingView _dieView;
        [SerializeField] private readonly ILoseView _loseView;

        private void OnEnable()
        {
            if (_dieView == null)
                throw new NullReferenceException($"{nameof(_dieView)} == null");
        }

        public void Die()
        {
            _dieView.OnDie();
            _loseView.OnLose();
        }
    }
}