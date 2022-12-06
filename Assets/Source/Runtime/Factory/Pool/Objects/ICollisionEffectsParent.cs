using System.Collections.Generic;
using UnityEngine;

namespace SwipeOrDie.Storage
{
    public interface ICollisionEffectsParent
    {
        Transform Transform { get; }
        Stack<CollisionEffect> Objects(CollisionEffect type);
    }
}