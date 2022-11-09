using Source.UI.Components;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.UI
{
    [RequireComponent(typeof(IText))]
    public class ShopButtonView : MonoBehaviour, IShopButtonView
    {
        [SerializeField] private MeshFilter _meshFilter;
        private const string SelectText = "Select";
        private IText _text;

        private void OnEnable()
        {
            _text = GetComponent<IText>();
            _meshFilter.ThrowIfNull();
        }

        public void OnSetGood(IShopButtonAction action)
        {
            UpdateText((dynamic)action);
            _meshFilter.mesh = action.Good.Skin;
        }
        
        private void UpdateText(BuyButtonAction action) => 
            _text.Set(action.Good.Price);

        private void UpdateText(UseButtonAction action) => 
            _text.Set(SelectText);
    }
}