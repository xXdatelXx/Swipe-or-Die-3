using UnityEngine;
using Random = UnityEngine.Random;

namespace Source
{
    public class RandomDestroy : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private int _chance;

        private void Awake()
        {
            if (Random.Range(0, 100) > _chance)
                Destroy(gameObject);
        }
    }
}