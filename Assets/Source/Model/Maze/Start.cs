using UnityEngine;

public class Start : MonoBehaviour
{
    public Transform Parent => transform.parent;
    public Vector3 LocalPosition => transform.localPosition;
}
