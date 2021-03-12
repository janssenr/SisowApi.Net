using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Tests.Helpers;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class IssuerRequestTest
    {
        [TestMethod]
        public async Task TestGet()
        {
            var sisow = SisowClientTestHelper.GetClient();
            var issuers = await sisow.Issuers.Get();
            Assert.IsTrue(issuers.Count > 1);
        }
    }
}
