using TMPro;

namespace SwipeOrDie.Ui
{
    public sealed class ProText : TextMeshProUGUI, IText
    {
        public void Set(string value) => 
            text = value;
    }
}