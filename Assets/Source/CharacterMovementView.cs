using DG.Tweening;
using SwipeOrDie.Extension;
using UnityEngine;

[RequireComponent((typeof(Mesh)))]
public class CharacterMovementView : MonoBehaviour, IMovementView
{
    [SerializeField, Min(0)] private float _force;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _stopDuration;
    private Vector3 _standardScale;
    private Vector3 _standardPosition;

    private void Awake()
    {
        _standardScale = transform.localScale;
        _standardPosition = transform.localPosition;
    }

    public void OnMove(Vector3 direction)
    {
        //transform.DOScale(_standardScale + direction.Module() * _force, _moveDuration);
        //transform.DOLocalMove(_standardPosition + direction * _force / 2, _moveDuration);
    }

    public void OnStop()
    {
        //transform.DOScale(_standardScale, _stopDuration);
        //transform.DOLocalMove(_standardPosition, _stopDuration);
    }
}