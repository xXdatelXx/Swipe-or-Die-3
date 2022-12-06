using System;
using System.Collections;
using System.Collections.Generic;

namespace SwipeOrDie.Data
{
    public readonly struct Range
    {
        public readonly int Min;
        public readonly int Max;
        public readonly IEnumerable Values;

        public Range(int min, int max)
        {
            if (min.CompareTo(max) > 0)
                throw new ArgumentOutOfRangeException($"{nameof(min)} > {nameof(max)}");

            Min = min;
            Max = max;

            var list = new List<int>();

            for (int i = Min; i < Max; i++)
                list.Add(i);

            Values = list;
        }

        public bool InRange(int value) =>
            Min <= value && Max >= value;

        public int Clamp(int value) =>
            value < Min ? Max : value > Max ? Min : value;
    }
}