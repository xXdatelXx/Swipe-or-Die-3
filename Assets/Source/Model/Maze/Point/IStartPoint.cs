using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public interface IStartPoint
    {
        Transform Parent { get; }
        Vector3 LocalPosition { get; }
    }
}