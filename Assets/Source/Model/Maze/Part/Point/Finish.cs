using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using SwipeOrDie.Extension;
using SwipeOrDie.View;

namespace SwipeOrDie.Model
{
    public sealed class Finish : SerializedMonoBehaviour, IFinishPoint
    {
        [SerializeField] private IView _view;
        [SerializeField] private ISideCollision _collision;
        private ILevelCreator _levelCreator; 

        [Inject]
        public void Init(ILevelCreator levelCreator) => 
            _levelCreator = levelCreator.ThrowExceptionIfNull();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.IsNot<ICharacter>())
                return;

            if (_collision.TrueAngle(collision))
                OnFinish();
        }

        private void OnFinish()
        {
            _levelCreator.Create();
            _view.View();
        }
    }
}