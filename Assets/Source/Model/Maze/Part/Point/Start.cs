using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class Start : MonoBehaviour, IStartPoint
    {
        public Vector3 Position => transform.position;
        public Vector3 EulerAngles => transform.eulerAngles;
        [field: SerializeField] public Transform Parent { get; private set; }

        private void OnValidate() => 
            Parent ??= transform.parent;
    }
}