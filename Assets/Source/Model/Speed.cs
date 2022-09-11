using System;
using UnityEngine;

namespace Source.Model
{
    [Serializable]
    public struct Speed : ISpeed
    {
        [field: Min(0)] public float Value { get; }

        public Speed(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException($"{nameof(value)} < 0");

            Value = value;
        }
    }
}