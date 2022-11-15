using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    [Serializable]
    public sealed class Timer : ITimer, IUpdateble
    {
        [field: SerializeField] public float Time { get; private set; }
        public float AccumulatedTime { get; private set; }
        private bool _end => AccumulatedTime == Time;
        private bool _enabled;
        private bool _canUpdate => !_end && _enabled;

        public Timer(float time) => 
            Time = time.ThrowExceptionIfValueSubZero();

        public async UniTask Play()
        {
            _enabled = true;
            await UniTask.WaitUntil(() => _end);
        }

        public void Effect(float effect) => 
            AccumulatedTime = Math.Clamp(AccumulatedTime + effect, 0, Time);

        public void Update(float deltaTime)
        {
            if (!_canUpdate)
                return;

            AccumulatedTime = Math.Min(AccumulatedTime + deltaTime, Time);
        }
    }
}