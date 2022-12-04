using System.Collections.Generic;
using UnityEngine;

namespace SwipeOrDie.Roots
{
    public class CompositeRootOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _roots;

        private void Start() => _roots.ForEach(root => root.Compose());
    }
}