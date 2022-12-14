using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class RaycastExtension
    {
        public static bool Is<T>(this RaycastHit hit) => 
            hit.collider.GetComponent<T>() != null;
    }
}