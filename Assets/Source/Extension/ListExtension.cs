using System.Collections.Generic;
using System.Linq;

public static class ListExtension
{
    public static void SetCount<T>(this List<T> list, int count)
    {
        while (list.Count != count)
        {
            if (list.Count < count)
                list.Add(default(T));
            if (list.Count > count)
                list.RemoveAt(list.Count - 1);
        }
    }

    public static void SortHerringbone(this List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i + 1] <= list[i])
                list[i + 1] = list[i] + 1;
        }
    }

    public static bool Has<T>(this List<T> list, T item)  
    {
        return list.Any(i => i.Equals(item));
    }
}