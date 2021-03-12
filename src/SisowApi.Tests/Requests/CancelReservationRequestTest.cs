using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisowApi.Net.Resources;
using SisowApi.Tests.Helpers;
using System.Threading.Tasks;

namespace SisowApi.Tests.Requests
{
    [TestClass]
    public class CancelReservationRequestTest
    {
        public async Task TestCreate()
        {
            var sisow = SisowClientTestHelper.GetClient();

            // create transaction
            var responseCreate = await sisow.Transactions.Create(SisowHelper.Transaction());

            // valid response?
            Assert.IsInstanceOfType(responseCreate, typeof(Transaction));
            Assert.AreEqual("Reservation", responseCreate.Status);

            // cancel transaction
            var responseCancel = await sisow.Transactions.Cancel(responseCreate.Id);

            // validate response
            Assert.IsInstanceOfType(responseCancel, typeof(Transaction));
            Assert.AreEqual("Cancelled", responseCancel.Status);
        }
    }
}
