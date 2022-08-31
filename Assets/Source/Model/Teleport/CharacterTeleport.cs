using UnityEngine;
using Zenject;
using System;
using System.Threading.Tasks;

[RequireComponent(typeof(ICharacterTeleportView))]
public class CharacterTeleport : MonoBehaviour, ICharacterTeleport
{
    [SerializeField, Range(0, 10)] private float _time;
    private Timer _timer;
    private IITickables _tickable;
    private ICharacterTeleportView _view;

    [Inject]
    public void Construct(IITickables tickable)
    {
        _timer = new Timer(_time);
        _tickable = tickable;
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
        _tickable.Run(_timer);

        await _timer.AweitEnd();
    }

    private void OnEnd()
    {
        _view.OnEnd();
        _tickable.Stop(_timer);
    }

    private void OnDestroy()
    {
        _tickable.Stop(_timer);
    }
}