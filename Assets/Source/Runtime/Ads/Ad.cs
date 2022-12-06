using GoogleMobileAds.Api;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Ads
{
    public sealed class Ad : IAd
    {
        private readonly IAd _ad;
        private readonly IAdShowStrategy _showStrategy;

        public Ad(IAd ad, IAdShowStrategy showStrategy)
        {
            _ad = ad.ThrowExceptionIfArgumentNull(nameof(ad));
            _showStrategy = showStrategy.ThrowExceptionIfArgumentNull(nameof(showStrategy));
        }

        public void TryShow()
        {
            if (_showStrategy.CanShow())
                _ad.TryShow();
        }

        public void LoadAd(AdRequest request) => _ad.LoadAd(request);
    }
}