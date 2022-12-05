using SwipeOrDie.Model;

namespace SwipeOrDie.Ui
{
    public interface IShopButtonAction : IButtonAction
    {
        IGood Good { get; }
    }
}