using UnityEngine;

namespace SwipeOrDie.View
{
    public interface ICameraSnaking
    {
        void Snake(Vector3 direction);
        void LoseSnake();
    }
}