using UnityEngine;
using Cysharp.Threading.Tasks;

namespace SwipeOrDie.Model
{
    public interface IMovement
    {
        UniTask Move(Vector3 nextPosition);
    }
}