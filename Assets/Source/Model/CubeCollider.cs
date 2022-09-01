using UnityEngine;

public class CubeCollider : BoxCollider
{
    public float Radius => size.x;

    private void OnValidate()
    {
        size = new Vector3(size.x, size.y, size.z);
    }
}