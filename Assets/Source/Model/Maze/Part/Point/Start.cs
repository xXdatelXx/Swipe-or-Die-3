using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public sealed class Start : MonoBehaviour, IStartPoint
    {
        [field: SerializeField] public Transform Parent { get; private set; }
        public Vector3 Position => transform.position;
        public Vector3 EulerAngles => transform.eulerAngles;

        private void OnValidate() => 
            Parent ??= transform.parent;
    }
}