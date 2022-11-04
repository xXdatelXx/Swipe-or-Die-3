using System;

namespace Source.Model.Storage
{
    [Serializable]
    public struct SerializableInt
    {
        public readonly int Value;
        public SerializableInt(int value) => Value = value;
    }
}