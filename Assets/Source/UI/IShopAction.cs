namespace Source.UI
{
    public interface IShopAction
    {
        int Count { get; }
        int Last { get; }
        IShopButtonAction this[int id] { get; }
    }
}