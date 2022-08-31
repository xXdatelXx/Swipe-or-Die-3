using System;
using UnityEngine;

public static class EnumExtension
{
    public static int Id<T>(this T value) where T : Enum
    {
        return Array.IndexOf(Enum.GetValues(value.GetType()), value);
    }

    public static T Next<T>(this T value, int addedIndex) where T : Enum
    {
        var values = (T[])Enum.GetValues(value.GetType());
        var index = Mathf.Clamp(Array.IndexOf<T>(values, value) + addedIndex - 1, 0, values.Length);

        return values[index];
    }
}
