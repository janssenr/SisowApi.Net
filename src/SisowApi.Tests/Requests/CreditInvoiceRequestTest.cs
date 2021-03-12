using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Net.Resources;
using SisowApi.Tests.Helpers;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class CreditInvoiceRequestTest
    {
        [TestMethod]
        public async Task TestCredit()
        {
            var sisow = SisowClientTestHelper.GetClient();

            var responseTransaction = await sisow.Transactions.Create(SisowHelper.Transaction());

            Assert.IsInstanceOfType(responseTransaction, typeof(Transaction));

            var responseInvoice = await sisow.Invoices.Create(responseTransaction.Id);

            Assert.IsInstanceOfType(responseInvoice, typeof(Invoice));

            var creditInvoice = sisow.Invoices.Credit(responseTransaction.Id);

            Assert.IsInstanceOfType(creditInvoice, typeof(Invoice));
        }
    }
}
