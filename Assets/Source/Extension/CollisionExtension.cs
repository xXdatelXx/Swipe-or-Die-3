using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class CollisionExtension
    {
        public static Vector3 Position(this Collision collision) =>
            collision.transform.position;

        public static bool Is<T>(this Collision collision) =>
            GetComponent<T>(collision) != null;

        public static bool Is<T>(this Collision collision, out T obj) =>
            collision.transform.TryGetComponent<T>(out obj);

        public static bool IsNot<T>(this Collision collision) =>
            GetComponent<T>(collision) == null;

        public static T GetComponent<T>(this Collision collision) =>
            collision.transform.GetComponent<T>();
    }
}