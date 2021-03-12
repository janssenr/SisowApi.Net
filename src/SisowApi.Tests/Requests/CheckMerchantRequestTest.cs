using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Net.Resources;
using SisowApi.Tests.Helpers;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class CheckMerchantRequestTest
    {
        [TestMethod]
        public async Task TestGet()
        {
            var sisow = SisowClientTestHelper.GetClient();
            var response = await sisow.Merchants.Get();
            Assert.IsInstanceOfType(response, typeof(Merchant));
        }
    }
}
