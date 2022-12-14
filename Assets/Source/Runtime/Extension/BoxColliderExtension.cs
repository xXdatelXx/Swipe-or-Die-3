using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class ColliderExtension
    {
        public static BoxCollider ToCube(this BoxCollider collider)
        {
            var radius = Diameter(collider);
            collider.size = new Vector3(radius, radius, radius);

            return collider;
        }

        public static float Diameter(this BoxCollider collider) =>
             collider.size.x;

        public static float Radius(this BoxCollider collider) =>
             Diameter(collider) / 2;
    }
}