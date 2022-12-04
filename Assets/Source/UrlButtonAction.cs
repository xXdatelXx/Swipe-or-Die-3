using Source.UI;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Ui
{
    public sealed class UrlButtonAction : IButtonAction
    {
        private readonly Url _url;

        public UrlButtonAction(Url url) => 
            _url = url.ThrowExceptionIfArgumentNull(nameof(url));

        public void OnClick() => _url.Open();
    }
}