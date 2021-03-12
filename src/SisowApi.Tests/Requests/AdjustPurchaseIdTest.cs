using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Net.Resources;
using SisowApi.Net.Types;
using SisowApi.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class AdjustPurchaseIdTest
    {
        [TestMethod]
        public async Task TestEdit()
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

            var transactionId = result.Id;
            var oldPurchaseId = result.PurchaseId;
            var newPurchaseId = "testnew";

            var editResult = await sisow.Transactions.Edit(transactionId, oldPurchaseId, newPurchaseId);

            Assert.IsInstanceOfType(editResult, typeof(Transaction));
            Assert.AreEqual(newPurchaseId, editResult.PurchaseId);
        }
    }
}
