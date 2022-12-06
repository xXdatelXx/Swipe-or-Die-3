using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using SwipeOrDie.Extension;
using SwipeOrDie.Model;

namespace SwipeOrDie.Tools
{
    [Serializable]
    public sealed class AsyncTimer : IAsyncTimer
    {
        [field: SerializeField] public float Time { get; }

        public AsyncTimer(float time) => 
            Time = time.ThrowExceptionIfValueSubZero();

        public async UniTask Play() => 
            await UniTask.Delay(TimeSpan.FromSeconds(Time));
    }
}