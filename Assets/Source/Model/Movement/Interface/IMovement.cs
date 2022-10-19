using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Source.Model.Movement.Interface
{
    public interface IMovement
    {
        UniTask Move(Vector3 nextPosition);
    }
}