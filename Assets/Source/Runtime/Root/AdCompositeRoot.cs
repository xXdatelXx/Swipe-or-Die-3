using FluentValidation;
using GoogleMobileAds.Api;
using Sirenix.Utilities;
using SwipeOrDie.Ads;
using UnityEngine;

namespace SwipeOrDie.Roots
{
    public sealed class AdCompositeRoot : CompositeRoot
    {
        [SerializeField] private IAdUser[] _users;
        [SerializeField] private IAdShowStrategy _showStrategy;
        private string _adId => "ca-app-pub-9246991752552061~4508816606";
        private IAd _ad;

        private void Awake()
        {
            InstallAd();

            new Validator().ValidateAndThrow(this);
            DontDestroyOnLoad(this);
        }

        private void InstallAd()
        {
            MobileAds.Initialize(_ => { });

            _ad = new Ad(new InterstitialAd(_adId), _showStrategy);
            _ad.LoadAd(new AdRequest.Builder().Build());
        }

        public override void Compose() =>
            _users.ForEach(i => i.Init(_ad));

        private class Validator : AbstractValidator<AdCompositeRoot>
        {
            public Validator()
            {
                RuleForEach(root => root._users).NotNull();
                RuleFor(root => root._showStrategy).NotNull();
                RuleFor(root => root._ad).NotNull();
            }
        }
    }
}