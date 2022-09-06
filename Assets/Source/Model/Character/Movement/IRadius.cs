using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public interface IRadius
    {
        Vector3 Indent(Vector3 movementDirection);
    }
}