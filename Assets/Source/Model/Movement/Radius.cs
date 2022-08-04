using UnityEngine;

public class Radius : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float _radius;

    public Vector3 Indent(Vector3 movementDirection)
    {
        return movementDirection switch
        {
            var v when v == Vector3.up => new Vector3(0, -_radius),
            var v when v == Vector3.down => new Vector3(0, _radius),
            var v when v == Vector3.right => new Vector3(-_radius, 0),
            var v when v == Vector3.left => new Vector3(_radius, 0),
            _ => Vector3.zero
        };
    }
}
