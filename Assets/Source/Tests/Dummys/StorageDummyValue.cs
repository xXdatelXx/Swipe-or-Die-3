using System;

namespace Source.Tests.Dummys
{
    [Serializable]
    public struct StorageDummyValue
    {
        public int Count;

        public StorageDummyValue(int count) => Count = count;

        public override bool Equals(object obj)
        {
            if (obj is StorageDummyValue value)
                return Count == value.Count;
                
            return base.Equals(obj);
        }
    }
}