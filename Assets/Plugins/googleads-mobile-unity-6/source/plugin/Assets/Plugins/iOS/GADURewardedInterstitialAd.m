// Copyright 2020 Google Inc. All Rights Reserved.

#import "GADURewardedInterstitialAd.h"

#import <CoreGraphics/CoreGraphics.h>
#import <UIKit/UIKit.h>

#import "GADUPluginUtil.h"
#import "UnityInterface.h"

@interface GADURewardedInterstitialAd () <GADFullScreenContentDelegate>
@end

@implementation GADURewardedInterstitialAd

- (instancetype)initWithRewardedInterstitialAdClientReference:
    (GADUTypeRewardedInterstitialAdClientRef *)rewardedInterstitialAdClient {
  self = [super init];
  _rewardedInterstitialAdClient = rewardedInterstitialAdClient;
  return self;
}

- (void)loadWithAdUnitID:(NSString *)adUnit request:(GADRequest *)request {
  __weak GADURewardedInterstitialAd *weakSelf = self;

  [GADRewardedInterstitialAd
       loadWithAdUnitID:adUnit
                request:request
      completionHandler:^(GADRewardedInterstitialAd *_Nullable rewardedInterstitialAd,
                          NSError *_Nullable error) {
        GADURewardedInterstitialAd *strongSelf = weakSelf;
        if (error || !rewardedInterstitialAd) {
          if (strongSelf.adFailedToLoadCallback) {
            strongSelf.adFailedToLoadCallback(
                strongSelf.rewardedInterstitialAdClient, (__bridge GADUTypeErrorRef)error);
          }
          return;
        }
        strongSelf.rewardedInterstitialAd = rewardedInterstitialAd;
        strongSelf.rewardedInterstitialAd.fullScreenContentDelegate = strongSelf;
        strongSelf.rewardedInterstitialAd.paidEventHandler = ^void(GADAdValue *_Nonnull adValue) {
          GADURewardedInterstitialAd *strongSecondSelf = weakSelf;
          if (strongSecondSelf.paidEventCallback) {
            int64_t valueInMicros =
                [adValue.value decimalNumberByMultiplyingByPowerOf10:6].longLongValue;
            strongSecondSelf.paidEventCallback(
                strongSecondSelf.rewardedInterstitialAdClient, (int)adValue.precision,
                valueInMicros, [adValue.currencyCode cStringUsingEncoding:NSUTF8StringEncoding]);
          }
        };
        if (strongSelf.adLoadedCallback) {
          strongSelf.adLoadedCallback(self.rewardedInterstitialAdClient);
        }
      }];
}

- (void)show {
  UIViewController *unityController = [GADUPluginUtil unityGLViewController];
  __weak GADURewardedInterstitialAd *weakSelf = self;

  [self.rewardedInterstitialAd
      presentFromRootViewController:unityController
           userDidEarnRewardHandler:^void() {
             GADURewardedInterstitialAd *strongSelf = weakSelf;
             if (strongSelf.didEarnRewardCallback) {
               strongSelf.didEarnRewardCallback(
                   strongSelf.rewardedInterstitialAdClient,
                   [strongSelf.rewardedInterstitialAd.adReward.type
                       cStringUsingEncoding:NSUTF8StringEncoding],
                   strongSelf.rewardedInterstitialAd.adReward.amount.doubleValue);
             }
           }];
}

- (GADResponseInfo *)responseInfo {
  return self.rewardedInterstitialAd.responseInfo;
}

- (void)setServerSideVerificationOptions:(GADServerSideVerificationOptions *)options {
  self.rewardedInterstitialAd.serverSideVerificationOptions = options;
}

- (void)ad:(nonnull id<GADFullScreenPresentingAd>)ad
    didFailToPresentFullScreenContentWithError:(nonnull NSError *)error {
  if (self.adFailedToPresentFullScreenContentCallback) {
    self.adFailedToPresentFullScreenContentCallback(
        self.rewardedInterstitialAdClient,
        (__bridge GADUTypeErrorRef)error);
  }
}

- (void)adDidPresentFullScreenContent:(nonnull id<GADFullScreenPresentingAd>)ad {
  if (GADUPluginUtil.pauseOnBackground) {
    UnityPause(YES);
  }
  if (self.adDidPresentFullScreenContentCallback) {
    self.adDidPresentFullScreenContentCallback(self.rewardedInterstitialAdClient);
  }
}

- (void)adDidDismissFullScreenContent:(nonnull id<GADFullScreenPresentingAd>)ad {
  extern bool _didResignActive;
  if(_didResignActive) {
    // We are in the middle of the shutdown sequence, and at this point unity runtime is already destroyed.
    // We shall not call unity API, and definitely not script callbacks, so nothing to do here
    return;
  }
  if (UnityIsPaused()) {
    UnityPause(NO);
  }

  if (self.adDidDismissFullScreenContentCallback) {
    self.adDidDismissFullScreenContentCallback(self.rewardedInterstitialAdClient);
  }
}

- (void)adDidRecordImpression:(nonnull id<GADFullScreenPresentingAd>)ad {
  if (self.adDidRecordImpressionCallback) {
    self.adDidRecordImpressionCallback(self.rewardedInterstitialAdClient);
  }
}

@end
