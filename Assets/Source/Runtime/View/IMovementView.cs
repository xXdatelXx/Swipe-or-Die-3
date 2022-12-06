using UnityEngine;

namespace SwipeOrDie.View
{
    public interface IMovementView
    {
        void OnMove(Vector3 direction);
        void OnStop();
    }
}