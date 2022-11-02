using TMPro;

namespace Source.UI.Components
{
    public class ProText : TMP_Text, IText
    {
        public void Set(string value) => 
            text = value;
    }
}