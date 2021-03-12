using SisowApi.Net;
using System.Configuration;

namespace SisowApi.Tests.Helpers
{
    public static class SisowClientTestHelper
    {
        public static SisowClient GetClient()
        {
            var merchantId = ConfigurationManager.AppSettings["MerchantId"];
            var merchantKey = ConfigurationManager.AppSettings["MerchantKey"];

            var sisow = new SisowClient();
            sisow.SetApiKey(merchantId, merchantKey);
            return sisow;
        }
    }
}
