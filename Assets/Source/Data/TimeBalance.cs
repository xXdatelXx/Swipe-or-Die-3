using UnityEngine;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(fileName = nameof(TimeBalance))]
    public class TimeBalance : ScriptableObject, ITimeBalance
    {
        [field: SerializeField, Range(0, 100)] public int All { get; private set; }
        [field: SerializeField, Range(0, 100)] public int OnAdd { get; private set; }

        private void OnValidate()
        {
            All.ThrowExceptionIfValueSubZero();
            OnAdd.ThrowExceptionIfValueSubZero();
        }
    }
}