using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public interface IPosition
    {
        Vector3 Next(Vector2 direction);
    }
}
