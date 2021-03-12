using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Net.Resources;
using SisowApi.Tests.Helpers;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class InvoiceRequestTest
    {
        [TestMethod]
        public async Task TestCreate()
        {
            var sisow = SisowClientTestHelper.GetClient();

            var responseTransaction = await sisow.Transactions.Create(SisowHelper.Transaction());

            Assert.IsInstanceOfType(responseTransaction, typeof(Transaction));

            var responseInvoice = await sisow.Invoices.Create(responseTransaction.Id);

            Assert.IsInstanceOfType(responseInvoice, typeof(Invoice));
        }
    }
}
