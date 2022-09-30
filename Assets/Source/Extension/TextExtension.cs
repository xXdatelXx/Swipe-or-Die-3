using UnityEngine.UI;

namespace SwipeOrDie.Extension
{
    public static class TextExtension
    {
        public static void Set(this Text text, int value)
        {
            Set(text, value.ToString());
        }

        public static void Set(this Text text, string value)
        {
            text.text = value;
        }
    }
}