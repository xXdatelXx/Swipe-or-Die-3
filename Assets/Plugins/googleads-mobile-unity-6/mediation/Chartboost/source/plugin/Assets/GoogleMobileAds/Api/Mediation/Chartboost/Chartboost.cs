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

using UnityEngine;

using GoogleMobileAds.Common.Mediation.Chartboost;
using GoogleMobileAds.Mediation;

namespace GoogleMobileAds.Api.Mediation.Chartboost
{
    public enum CBGDPRDataUseConsent
    {
        NonBehavioral = 0,
        Behavioral,
    }

    public enum CBCCPADataUseConsent
    {
        OptOutSale = 0,
        OptInSale,
    }

    public class Chartboost
    {
        public static readonly IChartboostClient client = GetChartboostClient();

        private static IChartboostClient GetChartboostClient()
        {
            return ChartboostClientFactory.ChartboostInstance ();
        }

        public static void AddDataUseConsent(CBGDPRDataUseConsent gdprConsent)
        {
            client.AddDataUseConsent(gdprConsent);
        }

        public static void AddDataUseConsent(CBCCPADataUseConsent ccpaConsent)
        {
            client.AddDataUseConsent(ccpaConsent);
        }

        public static void AddDataUseConsent(string customConsentName, string customConsentValue)
        {
            if (customConsentName == null || customConsentValue == null)
            {
                Debug.Log("Invalid custom consent name or value.");
                return;
            }

            client.AddDataUseConsent(customConsentName, customConsentValue);
        }
    }
}
