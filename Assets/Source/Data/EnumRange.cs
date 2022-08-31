using System;

public struct EnumRange<T> where T : Enum
{
    public readonly T Min;
    public readonly T Max;

    public EnumRange(T min, T max)
    {
        if (min.Id() > max.Id())
            throw new ArgumentOutOfRangeException($"id {nameof(min)} > id {nameof(max)}");

        Min = min;
        Max = max;
    }
}
