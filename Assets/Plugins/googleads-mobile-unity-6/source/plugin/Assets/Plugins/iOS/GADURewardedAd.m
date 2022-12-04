// Copyright 2018 Google Inc. All Rights Reserved.

#import "GADURewardedAd.h"

#import <CoreGraphics/CoreGraphics.h>
#import <UIKit/UIKit.h>

#import "GADUPluginUtil.h"
#import "UnityInterface.h"

@interface GADURewardedAd () <GADFullScreenContentDelegate>
@end

@implementation GADURewardedAd

- (instancetype)initWithRewardedAdClientReference:(GADUTypeRewardedAdClientRef *)rewardedAdClient {
  self = [super init];
  _rewardedAdClient = rewardedAdClient;
  return self;
}

- (void)loadWithAdUnitID:(NSString *)adUnitID request:(GADRequest *)request {
  __weak GADURewardedAd *weakSelf = self;

  [GADRewardedAd loadWithAdUnitID:adUnitID
                          request:request
                completionHandler:^(GADRewardedAd *_Nullable rewardedAd, NSError *_Nullable error) {
                  GADURewardedAd *strongSelf = weakSelf;
                  if (error || !rewardedAd) {
                    if (strongSelf.adFailedToLoadCallback) {
                      strongSelf.adFailedToLoadCallback(strongSelf.rewardedAdClient,
                                                        (__bridge GADUTypeErrorRef)error);
                    }
                    return;
                  }
                  strongSelf.rewardedAd = rewardedAd;
                  rewardedAd.fullScreenContentDelegate = strongSelf;
                  rewardedAd.paidEventHandler = ^void(GADAdValue *_Nonnull adValue) {
                    GADURewardedAd *strongSecondSelf = weakSelf;
                    if (strongSecondSelf.paidEventCallback) {
                      int64_t valueInMicros =
                          [adValue.value decimalNumberByMultiplyingByPowerOf10:6].longLongValue;
                      strongSecondSelf.paidEventCallback(
                          strongSecondSelf.rewardedAdClient, (int)adValue.precision, valueInMicros,
                          [adValue.currencyCode cStringUsingEncoding:NSUTF8StringEncoding]);
                    }
                  };
                  if (strongSelf.adLoadedCallback) {
                    strongSelf.adLoadedCallback(self.rewardedAdClient);
                  }
                }];
}

- (void)show {
  UIViewController *unityController = [GADUPluginUtil unityGLViewController];
  __weak GADURewardedAd *weakSelf = self;

  [self.rewardedAd
      presentFromRootViewController:unityController
           userDidEarnRewardHandler:^void() {
             GADURewardedAd *strongSelf = weakSelf;
             if (strongSelf.didEarnRewardCallback) {
               strongSelf.didEarnRewardCallback(
                   strongSelf.rewardedAdClient,
                   [strongSelf.rewardedAd.adReward.type cStringUsingEncoding:NSUTF8StringEncoding],
                   strongSelf.rewardedAd.adReward.amount.doubleValue);
             }
           }];
}

- (GADResponseInfo *)responseInfo {
  return self.rewardedAd.responseInfo;
}

- (void)rewardedAd:(nonnull GADRewardedAd *)rewardedAd
    userDidEarnReward:(nonnull GADAdReward *)reward {
  if (self.didEarnRewardCallback) {
    // Double value used for didEarnRewardCallback callback to maintain consistency with Android
    // implementation.
    self.didEarnRewardCallback(self.rewardedAdClient,
                               [reward.type cStringUsingEncoding:NSUTF8StringEncoding],
                               reward.amount.doubleValue);
  }
}

- (void)ad:(nonnull id<GADFullScreenPresentingAd>)ad
    didFailToPresentFullScreenContentWithError:(nonnull NSError *)error {
  if (self.adFailedToPresentFullScreenContentCallback) {
    self.adFailedToPresentFullScreenContentCallback(self.rewardedAdClient,
                                                    (__bridge GADUTypeErrorRef)error);
  }
}

- (void)adDidPresentFullScreenContent:(nonnull id<GADFullScreenPresentingAd>)ad {
  if (GADUPluginUtil.pauseOnBackground) {
    UnityPause(YES);
  }
  if (self.adDidPresentFullScreenContentCallback) {
    self.adDidPresentFullScreenContentCallback(self.rewardedAdClient);
  }
}

- (void)adDidDismissFullScreenContent:(nonnull id<GADFullScreenPresentingAd>)ad {
  extern bool _didResignActive;
  if(_didResignActive) {
    // We are in the middle of the shutdown sequence, and at this point unity runtime is already
    // destroyed. We shall not call unity API, and definitely not script callbacks, so nothing to do
    // here
    return;
  }
  if (UnityIsPaused()) {
    UnityPause(NO);
  }

  if (self.adDidDismissFullScreenContentCallback) {
    self.adDidDismissFullScreenContentCallback(self.rewardedAdClient);
  }
}

- (void)adDidRecordImpression:(nonnull id<GADFullScreenPresentingAd>)ad {
  if (self.adDidRecordImpressionCallback) {
    self.adDidRecordImpressionCallback(self.rewardedAdClient);
  }
}

- (void)setServerSideVerificationOptions:(GADServerSideVerificationOptions *)options {
  self.rewardedAd.serverSideVerificationOptions = options;
}

@end
