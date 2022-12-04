using Source;
using Source.UI;
using SwipeOrDie.Extension;
using SwipeOrDie.Roots;

namespace SwipeOrDie.Ui
{
    public sealed class NegateAction : IButtonAction
    {
        private readonly INegateStorage _storage;

        public NegateAction(INegateStorage storage) => 
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));

        public void OnClick() => _storage.Negate();
    }
}