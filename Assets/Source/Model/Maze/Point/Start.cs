using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class Start : MonoBehaviour, IStartPoint
    {
        public Transform Parent => transform.parent;
        public Vector3 Position => transform.position;
    }
}
