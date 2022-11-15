using UnityEngine.UI;

namespace Source.UI.Components
{
    public sealed class MonoBehaviourText : Text, IText
    {
        public void Set(string value) => 
            text = value;
    }
}