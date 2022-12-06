using UnityEngine.UI;

namespace SwipeOrDie.Ui
{
    public sealed class MonoBehaviourText : Text, IText
    {
        public void Set(string value) => 
            text = value;
    }
}