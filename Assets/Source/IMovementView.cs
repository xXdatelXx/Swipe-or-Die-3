using UnityEngine;

namespace Source
{
    public interface IMovementView
    {
        void OnMove(Vector2 direction);
        void OnStop();
    }
}