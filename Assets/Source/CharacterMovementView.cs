using Sirenix.OdinInspector;
using Source;
using Source.View;
using UnityEngine;

public sealed class CharacterMovementView : SerializedMonoBehaviour, IMovementView
{
    [SerializeField, Min(0)] private float _force;
    [SerializeField, Min(0)] private float _moveDuration;
    [SerializeField] private ISnaking _cameraSnaking;
    private ISideScale _scale;

    private void Awake() =>
        _scale = new SideScale(_force, _moveDuration, transform);

    public void OnMove(Vector3 direction)
    {
        _scale.Scale(direction);
        _cameraSnaking.Snake(direction);
    }

    public void OnStop() => _scale.Reset();
}