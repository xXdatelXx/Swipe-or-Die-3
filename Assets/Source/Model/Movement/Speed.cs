using System;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.Model
{
    [Serializable]
    public struct Speed : ISpeed
    {
        // Если делать через Min(0) будет ошыбка
        [field: SerializeField, Range(0, 1000)] public float Value { get; private set; }

        public Speed(float value) => 
            Value = value.ThrowExceptionIfValueSubZero();
    }
}