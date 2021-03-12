using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Net.Resources;
using SisowApi.Net.Types;
using SisowApi.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class RefundRequestTest
    {
        [TestMethod]
        public async Task TestRefund()
        {
            var request = new TransactionRequest
            {
                Payment = PaymentMethod.IDEAL,
                PurchaseId = "orderID",
                Amount = 100, // amount is in cents (100 equals 1,00)
                Description = "Webshop Order #", // description for consumer bank statement
                ReturnUrl = new Uri("https://mywebshop.com")
            };

            var sisow = SisowClientTestHelper.GetClient();
            var result = await sisow.Transactions.Create(request);

            Assert.IsInstanceOfType(result, typeof(Transaction));

            var trxId = result.Id;

            var refundResult = await sisow.Transactions.Refund(trxId, 10);

            Assert.IsFalse(refundResult == null);
        }
    }
}
