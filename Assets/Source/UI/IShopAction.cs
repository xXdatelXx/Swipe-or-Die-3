namespace Source.UI
{
    public interface IShopAction
    {
        int Count { get; }
        IShopButtonAction this[int id] { get; }
    }
}