using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using SwipeOrDie.Extension;
using SwipeOrDie.GameLogic;

[Serializable]
public class AsyncTimer : IAsyncTimer
{
    [field: SerializeField] public float Time { get; }

    public AsyncTimer(float time)
    {
        Time = time.TryThrowSubZeroException();
    }

    public async UniTask Play()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(Time));
    }
}
