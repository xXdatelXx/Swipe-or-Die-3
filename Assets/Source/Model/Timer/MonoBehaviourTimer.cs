using UnityEngine;
using Cysharp.Threading.Tasks;

namespace SwipeOrDie.GameLogic
{
    public class MonoBehaviourTimer : MonoBehaviour, ITimer
    {
        [field: SerializeField, Range(0.02f, 50)] public float Time { get; private set; }
        private ITimer _timer;

        private void Awake()
        {
            _timer = new Timer(Time);
        }

        public async UniTask Play()
        {
            await _timer.Play();
        }
    }
}