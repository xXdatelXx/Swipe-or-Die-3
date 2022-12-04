// Copyright 2014 Google Inc. All Rights Reserved.

#import "GADUInterstitial.h"

#import <CoreGraphics/CoreGraphics.h>
#import <UIKit/UIKit.h>

#import "GADUPluginUtil.h"
#import "UnityInterface.h"


@interface GADUInterstitial () <GADFullScreenContentDelegate>
@end

@implementation GADUInterstitial

- (id)initWithInterstitialClientReference:(GADUTypeInterstitialClientRef *)interstitialClient {
  self = [super init];
  _interstitialClient = interstitialClient;
  return self;
}

- (void)loadWithAdUnitID:(NSString *)adUnitID request:(GADRequest *)request {
  __weak GADUInterstitial *weakSelf = self;

  [GADInterstitialAd
       loadWithAdUnitID:adUnitID
                request:request
      completionHandler:^(GADInterstitialAd *_Nullable interstitialAd, NSError *_Nullable error) {
        GADUInterstitial *strongSelf = weakSelf;
        if (error || !interstitialAd) {
          if (strongSelf.adFailedToLoadCallback) {
            strongSelf.adFailedToLoadCallback(strongSelf.interstitialClient,
                                              (__bridge GADUTypeErrorRef)error);
          }
          return;
        }
        strongSelf.interstitialAd = interstitialAd;
        strongSelf.interstitialAd.fullScreenContentDelegate = strongSelf;
        strongSelf.interstitialAd.paidEventHandler = ^void(GADAdValue *_Nonnull adValue) {
          GADUInterstitial *strongSecondSelf = weakSelf;
          if (strongSecondSelf.paidEventCallback) {
            int64_t valueInMicros =
                [adValue.value decimalNumberByMultiplyingByPowerOf10:6].longLongValue;
            strongSecondSelf.paidEventCallback(
                strongSecondSelf.interstitialClient, (int)adValue.precision, valueInMicros,
                [adValue.currencyCode cStringUsingEncoding:NSUTF8StringEncoding]);
          }
        };
        if (strongSelf.adLoadedCallback) {
          strongSelf.adLoadedCallback(self.interstitialClient);
        }
      }];
}

- (void)show {
  UIViewController *unityController = [GADUPluginUtil unityGLViewController];
  [self.interstitialAd presentFromRootViewController:unityController];
}

- (GADResponseInfo *)responseInfo {
  return self.interstitialAd.responseInfo;
}

#pragma mark GADFullScreenContentDelegate implementation

- (void)ad:(nonnull id<GADFullScreenPresentingAd>)ad
    didFailToPresentFullScreenContentWithError:(nonnull NSError *)error {
  if (self.adFailedToPresentFullScreenContentCallback) {
    self.adFailedToPresentFullScreenContentCallback(self.interstitialClient,
                                                    (__bridge GADUTypeErrorRef)error);
  }
}

- (void)adDidPresentFullScreenContent:(nonnull id<GADFullScreenPresentingAd>)ad {
  if (GADUPluginUtil.pauseOnBackground) {
    UnityPause(YES);
  }
  if (self.adDidPresentFullScreenContentCallback) {
    self.adDidPresentFullScreenContentCallback(self.interstitialClient);
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
    self.adDidDismissFullScreenContentCallback(self.interstitialClient);
  }
}

- (void)adDidRecordImpression:(nonnull id<GADFullScreenPresentingAd>)ad {
  if (self.adDidRecordImpressionCallback) {
    self.adDidRecordImpressionCallback(self.interstitialClient);
  }
}

@end
