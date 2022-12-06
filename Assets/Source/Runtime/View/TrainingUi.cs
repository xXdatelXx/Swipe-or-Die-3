using Sirenix.OdinInspector;
using SwipeOrDie.Storage;
using UnityEngine;

namespace SwipeOrDie.View
{
    public sealed class TrainingUi : SerializedMonoBehaviour, INegateStorage
    {
        [SerializeField] private IView<bool> _view;
        private INegateStorage _storage;
        public bool Value => _storage.Value;

        private void Start()
        {
            _storage = new NegateStorage(new BinaryStorage<bool>(nameof(TrainingUi)), _view);
            gameObject.SetActive(Value);
        }

        public void Negate()
        {
            _storage.Negate();
            gameObject.SetActive(Value);
        }
    }
}