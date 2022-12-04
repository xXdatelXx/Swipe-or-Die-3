﻿// Copyright 2019 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if UNITY_ANDROID

using UnityEngine;
using GoogleMobileAds.Common.Mediation.Fyber;

namespace GoogleMobileAds.Android.Mediation.Fyber
{
    public class FyberClient : IFyberClient
    {
        private const string INNERACTIVE_AD_MANAGER_CLASS = "com.fyber.inneractive.sdk.external.InneractiveAdManager";

        private static readonly FyberClient instance = new FyberClient();
        private FyberClient() { }

        public static FyberClient Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetGDPRConsent(bool consent)
        {
            AndroidJavaClass inneractiveAdManager = new AndroidJavaClass(INNERACTIVE_AD_MANAGER_CLASS);
            inneractiveAdManager.CallStatic("setGdprConsent", consent);
        }

        public void SetGDPRConsentString(string consentString)
        {
            AndroidJavaClass inneractiveAdManager = new AndroidJavaClass(INNERACTIVE_AD_MANAGER_CLASS);
            inneractiveAdManager.CallStatic("setGdprConsentString", consentString);
        }

        public void ClearGDPRConsentData()
        {
            AndroidJavaClass inneractiveAdManager = new AndroidJavaClass(INNERACTIVE_AD_MANAGER_CLASS);
            inneractiveAdManager.CallStatic("clearGdprConsentData");
        }
    }
}

#endif
