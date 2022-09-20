using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace Source.Model.Movement.Interface
{
    public interface IMovement
    {
        Task Move(Vector2 nextPosition);
    }
}