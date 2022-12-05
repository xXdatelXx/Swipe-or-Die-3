using GoogleMobileAds.Api;
using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.Ads
{
    public sealed class SceneAd : MonoBehaviour, IAdUser
    {
        private IAd _ad;

        public void Init(IAd ad) => _ad = ad.ThrowExceptionIfArgumentNull(nameof(ad));

        private void Start() => _ad?.TryShow();
    }
}