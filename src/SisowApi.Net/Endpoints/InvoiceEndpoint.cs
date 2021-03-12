using SisowApi.Net.Exceptions;
using SisowApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisowApi.Net.Endpoints
{
    public class InvoiceEndpoint : AbstractEndpoint
    {
        public InvoiceEndpoint(SisowClient client) : base(client)
        {

        }

        public async Task<Invoice> Create(string transactionId)
        {
            var data = new Dictionary<string, string>();
            data.Add("trxid", transactionId);
            data.Add("merchantid", GetMerchantId());
            data.Add("sha1", GetSHA1(transactionId + GetMerchantId() + GetMerchantKey()));
            var response = await Execute<InvoiceResponse>("InvoiceRequest", data);

            // get params
            var invoiceNo = response.Invoice.InvoiceNo;
            var documentId = response.Invoice.DocumentId;
            var sha1 = response.Signature.SHA1;

            if (sha1 != GetSHA1(invoiceNo + documentId + GetMerchantId() + GetMerchantKey()))
            {
                throw new SisowException("Invalid response!");
            }

            return response.Invoice;
        }

        public async Task<Invoice> Credit(string transactionId)
        {
            var data = new Dictionary<string, string>();
            data.Add("trxid", transactionId);
            data.Add("merchantid", GetMerchantId());
            data.Add("sha1", GetSHA1(transactionId + GetMerchantId() + GetMerchantKey()));
            var response = await Execute<CreditInvoiceResponse>("CreditInvoiceRequest", data);

            // get params
            var invoiceNo = response.CreditInvoice.InvoiceNo;
            var documentId = response.CreditInvoice.DocumentId;
            var sha1 = response.Signature.SHA1;

            if (sha1 != GetSHA1(invoiceNo + documentId + GetMerchantId() + GetMerchantKey()))
            {
                throw new SisowException("Invalid response!");
            }

            return response.CreditInvoice;
        }
    }
}
