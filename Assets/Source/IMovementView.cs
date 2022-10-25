using UnityEngine;

public interface IMovementView
{
    void OnMove(Vector3 direction);
    void OnStop();
}