using UnityEngine;

namespace SwipeOrDie.Model
{
    public interface IPosition
    {
        Vector3 Next(Vector2 direction);
    }
}
