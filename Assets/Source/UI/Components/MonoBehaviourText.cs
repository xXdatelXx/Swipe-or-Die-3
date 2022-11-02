using UnityEngine.UI;

namespace Source.UI.Components
{
    public class MonoBehaviourText : Text, IText
    {
        public void Set(string value) => 
            text = value;
    }
}