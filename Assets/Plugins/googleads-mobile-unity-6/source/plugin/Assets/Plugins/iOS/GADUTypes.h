// Copyright 2014 Google Inc. All Rights Reserved.
#import <Foundation/Foundation.h>

/// Positions to place an ad.
typedef NS_ENUM(NSInteger, GADAdPosition) {
  kGADAdPositionCustom = -1,              ///< Custom ad position.
  kGADAdPositionTopOfScreen = 0,          ///< Top of screen.
  kGADAdPositionBottomOfScreen = 1,       ///< Bottom of screen.
  kGADAdPositionTopLeftOfScreen = 2,      ///< Top left of screen.
  kGADAdPositionTopRightOfScreen = 3,     ///< Top right of screen.
  kGADAdPositionBottomLeftOfScreen = 4,   ///< Bottom left of screen.
  kGADAdPositionBottomRightOfScreen = 5,  ///< Bottom right of screen.
  kGADAdPositionCenterOfScreen = 6        ///< Bottom right of screen.
};

/// Orientation for an adaptive banner.
typedef NS_ENUM(NSUInteger, GADUBannerOrientation) {
  kGADUBannerOrientationCurrent = 0,    ///< Current Orientation.
  kGADUBannerOrientationLandscape = 1,  ///< Landscape.
  kGADUBannerOrientationPortrait = 2,   ///< Portrait.
};

typedef NS_ENUM(NSInteger, GADUAdSize) { kGADUAdSizeUseFullWidth = -1 };

/// Base type representing a GADU* pointer.
typedef const void *GADUTypeRef;

typedef const void *GADUTypeMobileAdsClientRef;

typedef const void *GADUTypeInitializationStatusRef;

typedef void (*GADUInitializationCompleteCallback)(GADUTypeMobileAdsClientRef *clientRef,
                                                   GADUTypeInitializationStatusRef statusRef);

/// Type representing a Unity banner client.
typedef const void *GADUTypeBannerClientRef;

/// Type representing a Unity interstitial client.
typedef const void *GADUTypeInterstitialClientRef;

/// Type representing a Unity rewarded ad client.
typedef const void *GADUTypeRewardedAdClientRef;

/// Type representing a GADURewardedInterstitialAd.
typedef const void *GADUTypeRewardedInterstitialAdRef;

/// Type representing a Unity rewarded interstitial ad client.
typedef const void *GADUTypeRewardedInterstitialAdClientRef;

/// Type representing a GADUBanner.
typedef const void *GADUTypeBannerRef;

/// Type representing a GADUInterstitial.
typedef const void *GADUTypeInterstitialRef;

/// Type representing a GADURewardedAd.
typedef const void *GADUTypeRewardedAdRef;

/// Type representing a GADURequest.
typedef const void *GADUTypeRequestRef;

/// Type representing a GADUTypeRequestConfigurationRef
typedef const void *GADUTypeRequestConfigurationRef;

/// Type representing a GADUTypeResponseInfoRef
typedef const void *GADUTypeResponseInfoRef;

/// Type representing a AdError type
typedef const void *GADUTypeErrorRef;

/// Type representing a NSMutableDictionary of extras.
typedef const void *GADUTypeMutableDictionaryRef;

/// Type representing a GADUAdNetworkExtras.
typedef const void *GADUTypeAdNetworkExtrasRef;

/// Type representing a GADUServerSideVerificationOptions.
typedef const void *GADUTypeServerSideVerificationOptionsRef;

/// Callback for when a banner ad request was successfully loaded.
typedef void (*GADUAdViewDidReceiveAdCallback)(GADUTypeBannerClientRef *bannerClient);

/// Callback for when a banner ad request failed.
typedef void (*GADUAdViewDidFailToReceiveAdWithErrorCallback)(GADUTypeBannerClientRef *bannerClient,
                                                              const char *error);

/// Callback for when a full screen view is about to be presented as a result of a banner click.
typedef void (*GADUAdViewWillPresentScreenCallback)(GADUTypeBannerClientRef *bannerClient);

/// Callback for when a full screen view is about to be dismissed.
typedef void (*GADUAdViewWillDismissScreenCallback)(GADUTypeBannerClientRef *bannerClient);

/// Callback for when a full screen view has just been dismissed.
typedef void (*GADUAdViewDidDismissScreenCallback)(GADUTypeBannerClientRef *bannerClient);

/// Callback for when an application will background or terminate as a result of a banner click.
typedef void (*GADUAdViewWillLeaveApplicationCallback)(GADUTypeBannerClientRef *bannerClient);

/// Callback for when an ad is estimated to have earned money.
typedef void (*GADUAdViewPaidEventCallback)(GADUTypeBannerClientRef *bannerClient, int precision,
                                            int64_t value, const char *currencyCode);

// MARK: - GADUInterstitial

/// Callback for when a interstitial ad request was successfully loaded.
typedef void (*GADUInterstitialAdLoadedCallback)(GADUTypeInterstitialClientRef *interstitialClient);

/// Callback for when an interstitial ad request failed.
typedef void (*GADUInterstitialAdFailedToLoadCallback)(
    GADUTypeInterstitialClientRef *interstitialClient, const char *error);

/// Callback when an interstitial ad failed to present full screen content.
typedef void (*GADUInterstitialAdFailedToPresentFullScreenContentCallback)(
    GADUTypeInterstitialRef *interstitialClient, const char *error);

/// Callback when an interstitial ad presented full screen content.
typedef void (*GADUInterstitialAdDidPresentFullScreenContentCallback)(
    GADUTypeInterstitialRef *interstitialClient);

/// Callback when an interstitial ad dismissed full screen content.
typedef void (*GADUInterstitialAdDidDismissFullScreenContentCallback)(
    GADUTypeInterstitialRef *interstitialClient);

/// Callback when an interstitial ad has made an impression.
typedef void (*GADUInterstitialAdDidRecordImpressionCallback)(
    GADUTypeInterstitialRef *interstitialClient);

/// Callback when an interstitial ad is estimated to have earned money.
typedef void (*GADUInterstitialPaidEventCallback)(GADUTypeInterstitialClientRef *interstitialClient,
                                                  int precision, int64_t value,
                                                  const char *currencyCode);
// MARK: - GADURewarded

/// Callback for when a rewarded ad request was successfully loaded.
typedef void (*GADURewardedAdLoadedCallback)(GADUTypeRewardedAdClientRef *rewardedAdClient);

/// Callback for when a rewarded ad request failed.
typedef void (*GADURewardedAdFailedToLoadCallback)(GADUTypeRewardedAdClientRef *rewardedAdClient,
                                                   const char *error);

/// Callback when a rewarded ad failed to present full screen content.
typedef void (*GADURewardedAdFailedToPresentFullScreenContentCallback)(
    GADUTypeRewardedAdRef *rewardedAdClient, const char *error);

/// Callback when a rewarded ad presented full screen content.
typedef void (*GADURewardedAdDidPresentFullScreenContentCallback)(
    GADUTypeRewardedAdRef *rewardedAdClient);

/// Callback when a rewarded ad dismissed full screen content.
typedef void (*GADURewardedAdDidDismissFullScreenContentCallback)(
    GADUTypeRewardedAdRef *rewardedAdClient);

/// Callback when a rewarded ad has made an impression.
typedef void (*GADURewardedAdDidRecordImpressionCallback)(GADUTypeRewardedAdRef *rewardedAdClient);

/// Callback for when a user earned a reward.
typedef void (*GADURewardedAdUserEarnedRewardCallback)(
    GADUTypeRewardedAdClientRef *rewardBasedVideoClient, const char *rewardType,
    double rewardAmount);

/// Callback for when a rewarded ad is estimated to have earned money.
typedef void (*GADURewardedAdPaidEventCallback)(GADUTypeRewardedAdClientRef *rewardedAdClient,
                                                int precision, int64_t value,
                                                const char *currencyCode);
// MARK: - GADRewardedInterstitial

/// Callback for when a rewarded interstitial ad is loaded.
typedef void (*GADURewardedInterstitialAdLoadedCallback)(
    GADUTypeRewardedInterstitialAdClientRef *rewardedInterstitialAdClient);

/// Callback for when a rewarded interstitial ad request failed to load.
typedef void (*GADURewardedInterstitialAdFailedToLoadCallback)(
    GADUTypeRewardedInterstitialAdClientRef *rewardedAdClient, const char *error);

/// Callback for when a user earned a reward.
typedef void (*GADURewardedInterstitialAdUserEarnedRewardCallback)(
    GADUTypeRewardedInterstitialAdClientRef *rewardedInterstitialAdClient, const char *rewardType,
    double rewardAmount);

/// Callback for when a rewarded interstitial ad is estimated to have earned money.
typedef void (*GADURewardedInterstitialAdPaidEventCallback)(
    GADUTypeRewardedInterstitialAdClientRef *rewardedInterstitialAdClient, int precision,
    int64_t value, const char *currencyCode);

/// Callback when a rewarded interstitial ad failed to present full screen content.
typedef void (*GADURewardedInterstitialAdFailedToPresentFullScreenContentCallback)(
    GADUTypeRewardedInterstitialAdRef *rewardedInterstitialAdClient, const char *error);

/// Callback when a rewarded interstitial ad presented full screen content.
typedef void (*GADURewardedInterstitialAdDidPresentFullScreenContentCallback)(
    GADUTypeRewardedInterstitialAdRef *rewardedInterstitialAdClient);

/// Callback when a rewarded interstitial ad dismissed full screen content.
typedef void (*GADURewardedInterstitialAdDidDismissFullScreenContentCallback)(
    GADUTypeRewardedInterstitialAdRef *rewardedInterstitialAdClient);

/// Callback when a rewarded interstitial ad has made an impression.
typedef void (*GADURewardedInterstitialAdDidRecordImpressionCallback)(
    GADUTypeRewardedInterstitialAdRef *rewardedInterstitialAdClient);
