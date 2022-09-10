using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class CollisionExtension
    {
        public static bool Is<T>(this Collision collision)
        {
            return collision.transform.GetComponent<T>() != null;
        }

        public static bool Is<T>(this Collision collision, out T obj)
        {
            return collision.transform.TryGetComponent<T>(out obj);
        }
    }
}