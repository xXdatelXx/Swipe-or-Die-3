using UnityEngine;

namespace SwipeOrDie.Input
{
    public interface IInput
    {
        Vector2 Direction { get; }

        void Enable();
        void Disable();
    }
}