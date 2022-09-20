using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class VectorExtension
    {
        public static bool IsDirection(this Vector3 vector)
        {
            return
                vector == Vector3.up || vector == Vector3.down ||
                vector == Vector3.right || vector == Vector3.left;
        }

        public static Vector3 Multiply(this Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vector3 Circle(this Vector3 vector)
        {
            return new Vector3(0, 0, 360);
        }

        public static Vector3 HalfCircle(this Vector3 vector)
        {
            return Circle(vector) / 2;
        }
    }
}