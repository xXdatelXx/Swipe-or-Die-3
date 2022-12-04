using System;
using System.Collections.Generic;
using Source;
using UnityEngine;

public interface ICollisionEffectsParent
{
    Transform Transform { get; }
    Stack<CollisionEffect> Objects(CollisionEffect type);
}