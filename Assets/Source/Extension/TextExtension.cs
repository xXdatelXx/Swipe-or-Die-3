using Source.UI.Components;

namespace SwipeOrDie.Extension
{
    public static class TextExtension
    {
        public static void Set(this IText text, int value)
            => text.Set(value.ToString());
    }
}