using System;
using Source.Model;
using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class TransformExtension
    {
        public static float Distance(this Transform transform, Transform to)
        {
            if (to == null)
                throw new ArgumentNullException(nameof(to));

            return Distance(transform, to.localPosition);
        }

        public static float Distance(this Transform position, Vector3 to) => 
            Vector3.Distance(position.localPosition, to);

        public static float Time(this Transform transform, Transform to, ISpeed speed) => 
            Time(transform, to.localPosition, speed);

        public static float Time(this Transform transform, Vector3 to, ISpeed speed) => 
            Distance(transform, to) / speed.Value;

        public static Vector3 LocalPosition(this Transform transform, Vector3 worldPosition)
        {
            if (transform == null)
                return worldPosition;

            return transform.InverseTransformPoint(worldPosition);
        }
    }
}