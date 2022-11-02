using Source.UI.Components;
using SwipeOrDie.Extension;
using TMPro;
using UnityEngine;

namespace Source.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BuyButtonView : MonoBehaviour, IBuyButtonView
    {
        [SerializeField] private MeshFilter _meshFilter;
        private TextMeshProUGUI _text;

        private void OnEnable()
        {
            _text = GetComponent<TextMeshProUGUI>();
            Logger.Log(GetComponent<TextMeshProUGUI>() == null, GetComponent<TMP_Text>() == null, GetComponent<IText>() == null);
            _meshFilter.TryThrowNullReferenceException();
        }

        public void OnSetGood(IGood good)
        {
            //_text.Set(good.Price);
            _meshFilter.mesh = good.Skin;
        }
    }
}