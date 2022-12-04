using UnityEngine;

namespace Source.View
{
    public interface ICameraSnaking
    {
        void Snake(Vector3 direction);
        void LoseSnake();
    }
}