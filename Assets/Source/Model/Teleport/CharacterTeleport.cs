using UnityEngine;
using System.Threading.Tasks;
using System;
using Sirenix.OdinInspector;

[RequireComponent(typeof(ICharacterTeleportView))]
public class CharacterTeleport : SerializedMonoBehaviour, ICharacterTeleport
{
    [SerializeField] private ITimer _timer;
    private ICharacterTeleportView _view;

    private void Awake()
    {
        if (_timer == null)
            throw new NullReferenceException($"{nameof(_timer)} == null");

        _view = GetComponent<ICharacterTeleportView>();
    }

    public async void Teleport(Start target)
    {
        await Start();

        transform.parent = target.Parent;
        transform.localPosition = target.LocalPosition;

        OnEnd();
    }

    private async Task Start()
    {
        _view.OnStart();
        await _timer.Play();
    }

    private void OnEnd()
    {
        _view.OnEnd();
    }
}