using System.Collections.Generic;
using System.Linq;
using Source;
using UnityEngine;

public sealed class CollisionEffectsParent : MonoBehaviour, ICollisionEffectsParent
{
    private Stack<CollisionEffect> _objects;
    public Transform Transform => transform;
    
    public Stack<CollisionEffect> Objects(CollisionEffect type) => 
        _objects ?? new Stack<CollisionEffect>(
                GetComponentsInChildren<CollisionEffect>().Where(i => i.Type == type.Type));
}