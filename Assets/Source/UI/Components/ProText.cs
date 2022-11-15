using TMPro;

namespace Source.UI.Components
{
    public sealed class ProText : TextMeshProUGUI, IText
    {
        public void Set(string value) => 
            text = value;
    }
}