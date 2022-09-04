using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class MonoBehaviourTimer : MonoBehaviour, ITimer
{
    [SerializeField, Range(0, 50)] private float _time;
    private ITimer _timer;

    private void Awake()
    {
        _timer = new Timer(_time);
    }

    public async UniTask Play()
    {
        await _timer.Play();
    }
}
