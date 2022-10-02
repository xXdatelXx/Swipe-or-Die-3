using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class CollisionExtension
    {
        public static Vector3 Position(this Collision collision)
        {
            return collision.transform.position;
        }
        
        public static bool Is<T>(this Collision collision)
        {
            return GetComponent<T>(collision) != null;
        }

        public static bool Is<T>(this Collision collision, out T obj)
        {
            return collision.transform.TryGetComponent<T>(out obj);
        }
        
        public static bool IsNot<T>(this Collision collision)
        {
            return GetComponent<T>(collision) == null;
        }

        public static T GetComponent<T>(this Collision collision)
        {
            return collision.transform.GetComponent<T>();
        }
    }
}