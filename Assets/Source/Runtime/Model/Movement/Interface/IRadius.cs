using UnityEngine;

namespace SwipeOrDie.Model
{
    public interface IRadius
    {
        Vector3 Indent(Vector3 movementDirection);
    }
}