using Source.UI.Components;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.UI
{
    [RequireComponent(typeof(IText))]
    public class BuyButtonView : MonoBehaviour, IBuyButtonView
    {
        [SerializeField] private MeshFilter _meshFilter;
        private IText _text;

        private void OnEnable()
        {
            _text = GetComponent<IText>();
            _meshFilter.TryThrowNullReferenceException();
        }

        public void OnSetGood(IGood good)
        {
            _text.Set(good.Price);
            _meshFilter.mesh = good.Skin;
        }
    }
}