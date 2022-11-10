using SwipeOrDie.Extension;

namespace Source.UI
{
    public class UseButtonAction: IShopButtonAction
    {
        public IGood Good { get; }

        public UseButtonAction(IGood good) => 
            Good = good.ThrowExceptionIfArgumentNull(nameof(good));
        
        public void OnClick() => 
            Good.Use();
    }
}