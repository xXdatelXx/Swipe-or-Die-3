using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    public class Finish : MonoBehaviour, IFinishPoint
    {
        [SerializeField] private List<int> _collisionAngles = new() { 0, 90, -90, 180 };
        private LevelCreator _levelCreator;

        [Inject]
        public void Init(LevelCreator levelCreator)
        {
            Debug.Log("bomjara");
            _levelCreator = levelCreator.TryThrowNullReferenceException();;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.IsNot<ICharacter>())
                return;

            var collisionAngle = Vector3.Angle(collision.Position() - transform.position, transform.forward);
            var trueAngle = _collisionAngles.Any(angle => angle == collisionAngle);

            if (trueAngle)
                _levelCreator.Create();
        }
    }
}