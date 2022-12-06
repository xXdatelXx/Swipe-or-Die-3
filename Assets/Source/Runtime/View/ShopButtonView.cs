using SwipeOrDie.Extension;
using SwipeOrDie.Ui;
using UnityEngine;

namespace SwipeOrDie.View
{
    [RequireComponent(typeof(IText))]
    public sealed class ShopButtonView : MonoBehaviour, IShopButtonView
    {
        [SerializeField] private MeshFilter _meshFilter;
        private const string SelectText = "Select";
        private IText _text;
        
        private void OnEnable()
        {
            _text = GetComponent<IText>();
            _meshFilter.ThrowExceptionIfNull();
        }

        public void OnSetAction(IShopButtonAction action)
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