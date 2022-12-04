// Copyright 2018 Google LLC
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

#if UNITY_IOS

using UnityEngine;

using GoogleMobileAds.Common.Mediation.MyTarget;

namespace GoogleMobileAds.iOS.Mediation.MyTarget
{
    public class MyTargetClient : IMyTargetClient
    {
        private static MyTargetClient instance = new MyTargetClient();
        private MyTargetClient() {}

        public static MyTargetClient Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetUserConsent(bool userConsent)
        {
            Externs.GADUMMyTargetSetUserConsent (userConsent);
        }

        public void SetUserAgeRestricted(bool userAgeRestricted)
        {
            Externs.GADUMMyTargetSetUserAgeRestricted (userAgeRestricted);
        }

        public bool IsConsent()
        {
            return Externs.GADUMMyTargetIsConsent ();
        }

        public bool IsUserAgeRestricted()
        {
            return Externs.GADUMMyTargetIsUserAgeRestricted ();
        }
    }
}

#endif
