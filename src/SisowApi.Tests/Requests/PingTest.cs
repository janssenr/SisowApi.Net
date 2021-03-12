using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Tests.Helpers;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class PingTest
    {
        [TestMethod]
        public async Task TestGet()
        {
            var sisow = SisowClientTestHelper.GetClient();
            var result = await sisow.Ping.Get();
            Assert.IsFalse(result == null);
        }
    }
}
