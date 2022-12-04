using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    [RequireComponent(typeof(Image))]
    public sealed class SwitchSpriteView : MonoBehaviour, IView<bool>
    {
        [SerializeField] private Sprite _on;
        [SerializeField] private Sprite _of;
        private Image _image;

        private void Awake() => _image = GetComponent<Image>();

        public void View(bool value) => _image.sprite = value ? _on : _of;
    }
}