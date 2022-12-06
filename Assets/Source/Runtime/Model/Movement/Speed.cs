using System;
using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.Model
{
    [Serializable]
    public struct Speed : ISpeed
    {
        [field: SerializeField, Min(0)] public float Value { get; private set; }

        public Speed(float value) => 
            Value = value.ThrowExceptionIfValueSubZero();
    }
}