namespace SwipeOrDie.Ui
{
    public interface IShopAction
    {
        int Count { get; }
        int Last { get; }
        IShopButtonAction this[int id] { get; }
    }
}