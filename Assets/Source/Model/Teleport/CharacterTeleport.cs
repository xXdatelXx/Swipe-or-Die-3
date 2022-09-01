using UnityEngine;
using Zenject;
using System;
using System.Threading.Tasks;

[RequireComponent(typeof(ICharacterTeleportView))]
public class CharacterTeleport : MonoBehaviour, ICharacterTeleport
{
    [SerializeField, Range(0, 10)] private float _time;
    private Timer _timer;
    private ICharacterTeleportView _view;

    [Inject]
    public void Construct(Timer timer)
    {
        _timer = timer;
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
        _timer.Restart();

        await _timer.AweitEnd();
    }

    private void OnEnd()
    {
        _view.OnEnd();
        _timer.Stop();
    }
}