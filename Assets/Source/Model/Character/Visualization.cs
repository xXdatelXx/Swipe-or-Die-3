using UnityEngine;
using DG.Tweening;
using SwipeOrDie.Extension;

public class Visualization : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float _scaleTime;
    [SerializeField, Range(0, 10)] private float _rescaleTime;

    public void Visualizate(Vector3 direction)
    {
        if (direction.x == 0)
            direction.x = 1;
        if (direction.y == 0)
            direction.y = 1;
        if (direction.z == 0)
            direction.z = 1;

        transform.DOScale(transform.localScale.Multiply(direction), _scaleTime);
    }
}
