using UnityEngine;

public static class ColliderExtension
{
    public static BoxCollider ToCube(this BoxCollider collider)
    {
        var radius = Diameter(collider);
        collider.size = new Vector3(radius, radius, radius);

        return collider;
    }

    public static float Diameter(this BoxCollider collider)
    {
        return collider.size.x;
    }

    public static float Radius(this BoxCollider collider)
    {
        return Diameter(collider) / 2;
    }
}