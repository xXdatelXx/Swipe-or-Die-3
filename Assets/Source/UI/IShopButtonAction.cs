namespace Source.UI
{
    public interface IShopButtonAction : IButtonAction
    {
        IGood Good { get; }
    }
}