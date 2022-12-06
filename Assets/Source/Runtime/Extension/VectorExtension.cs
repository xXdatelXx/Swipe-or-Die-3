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

        public static Vector3 Module(this Vector3 vector)
        {
             vector.Scale(vector);
             return vector;
        }

        /// <summary>
        /// new Vector3(0,0,360)
        /// </summary>
        public static Vector3 Circle(this Vector3 vector) => 
            new Vector3(0, 0, 360);

        /// <summary>
        /// new Vector3(0,0,180)
        /// </summary>
        public static Vector3 HalfCircle(this Vector3 vector) => 
            Circle(vector) / 2;
    }
}