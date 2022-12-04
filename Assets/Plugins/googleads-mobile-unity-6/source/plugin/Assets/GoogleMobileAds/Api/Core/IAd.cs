namespace GoogleMobileAds.Api
{
    public interface IAd
    {
        void TryShow();
        void LoadAd(AdRequest request);
    }
}