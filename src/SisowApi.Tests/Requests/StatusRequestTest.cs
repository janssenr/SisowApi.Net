using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Net.Resources;
using SisowApi.Net.Types;
using SisowApi.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class StatusRequestTest
    {
        [TestMethod]
        public async Task TestGet()
        {
            var request = new TransactionRequest
            {
                Payment = PaymentMethod.MISTERCASH,
                PurchaseId = "test",
                EntranceCode = "ec",
                Amount = 50,
                Description = "test description",
                ReturnUrl = new Uri("https://sisow.nl")
            };

            var sisow = SisowClientTestHelper.GetClient();
            var result = await sisow.Transactions.Create(request);

            Assert.IsInstanceOfType(result, typeof(Transaction));

            var statusResult = await sisow.Transactions.Get(result.Id);
            Assert.IsInstanceOfType(statusResult, typeof(Transaction));
            Assert.AreEqual("Open", statusResult.Status);
        }
    }
}
