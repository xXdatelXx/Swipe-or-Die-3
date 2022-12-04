using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

namespace SwipeOrDie.Extension
{
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

        public static bool Has<T>(this IEnumerable<T> list, T item) => 
            list.Any(i => i.Equals(item));

        public static T Max<T>(this List<T> list) =>
            list[^1];

        public static T Random<T>(this IEnumerable<T> enumerable) =>
            enumerable.ElementAt(UnityEngine.Random.Range(0, enumerable.Count()));

        public static IEnumerable<T> RepeatForever<T>(this IEnumerable<T> enumerable)
        {
            while (true)
            {
                foreach (var i in enumerable)
                    yield return i;
            }
        }

        public static int ClampId<T>(this IList<T> enumerable, int id)
        {
            var count = enumerable.Count;
            return id < 0 ? count - 1 : id > count - 1 ? 0 : id;
        }

        public static IEnumerable<T> TryThrowNullReferenceForeach<T>(this IEnumerable<T> enumerable) =>
            enumerable.Select(i => i.ThrowExceptionIfNull("element is null"));
    }
}