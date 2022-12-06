using SwipeOrDie.Ui;

namespace SwipeOrDie.Extension
{
    public static class TextExtension
    {
        public static void Set(this IText text, int value)
            => text.Set(value.ToString());
    }
}