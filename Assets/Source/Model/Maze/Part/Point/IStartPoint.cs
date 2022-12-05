using UnityEngine;

namespace SwipeOrDie.Model
{
    public interface IStartPoint
    {
        Transform Parent { get; }
        Vector3 Position { get; }
        Vector3 EulerAngles { get; }
    }
}