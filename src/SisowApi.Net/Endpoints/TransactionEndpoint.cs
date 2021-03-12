using SisowApi.Net.Exceptions;
using SisowApi.Net.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisowApi.Net.Endpoints
{
    public class TransactionEndpoint : AbstractEndpoint
    {
        public TransactionEndpoint(SisowClient client) : base(client) { }

        public async Task<Transaction> Get(string transactionId)
        {
            var data = new Dictionary<string, string>();
            data.Add("trxid", transactionId);
            data.Add("shopid", GetShopId());
            data.Add("merchantid", GetMerchantId());
            data.Add("sha1", GetSHA1(transactionId + GetShopId() + GetMerchantId() + GetMerchantKey()));
            var response = await Execute<StatusResponse>("StatusRequest", data);

            var trxId = response.Transaction.Id;
            var status = response.Transaction.Status;
            var amount = response.Transaction.Amount;
            var purchaseId = response.Transaction.PurchaseId;
            var ec = response.Transaction.EntranceCode;
            var consumerAccount = response.Transaction.ConsumerAccount;
            var sha1 = response.Signature.SHA1;

            if (sha1 != GetSHA1($"{trxId}{status}{amount}{purchaseId}{ec}{consumerAccount}{GetMerchantId()}{GetMerchantKey()}"))
            {
                throw new SisowException("Invalid response!");
            }
            return response.Transaction;
        }

        public async Task<Transaction> Create(TransactionRequest transaction)
        {
            // do we have a purchase ID?
            if (string.IsNullOrEmpty(transaction.PurchaseId))
            {
                throw new SisowException("TransactionRequest: no purchase ID");
            }

            // do we have a entrance code?
            if (string.IsNullOrEmpty(transaction.EntranceCode))
            {
                transaction.EntranceCode = transaction.PurchaseId;
            }

            // do we have an amount?
            if (transaction.Amount == default(int))
            {
                throw new SisowException("TransactionRequest: no amount");
            }

            var data = new Dictionary<string, string>();
            data.Add("merchantid", GetMerchantId());
            data.Add("shopid", GetShopId());
            data.Add("payment", $"{transaction.Payment}");
            data.Add("purchaseid", $"{transaction.PurchaseId}");
            data.Add("entrancecode", $"{transaction.EntranceCode}");
            data.Add("amount", $"{transaction.Amount}");
            data.Add("description", $"{transaction.Description}");
            data.Add("testmode", $"{transaction.TestMode}");
            data.Add("returnurl", $"{transaction.ReturnUrl}");
            data.Add("cancelurl", $"{transaction.CancelUrl}");
            data.Add("notifyurl", $"{transaction.NotifyUrl}");
            data.Add("callbackurl", $"{transaction.CallbackUrl}");
            data.Add("sha1", GetSHA1($"{transaction.PurchaseId}{transaction.EntranceCode}{transaction.Amount}{GetShopId()}{GetMerchantId()}{GetMerchantKey()}"));
            data.Add("issuerid", $"{transaction.IssuerId}");
            data.Add("customer", $"{transaction.Customer}");
            data.Add("currency", $"{transaction.Currency}");
            data.Add("ipaddress", $"{transaction.IpAddress}");
            data.Add("bic", $"{transaction.BIC}");
            data.Add("iban", $"{transaction.IBAN}");
            data.Add("gender", $"{transaction.Gender}");
            data.Add("birthdate", $"{transaction.BirthDate.ToString("ddMMyyyy")}");
            data.Add("including", $"{transaction.Including}");
            data.Add("locale", $"{transaction.Locale}");
            data.Add("days", $"{transaction.Days}");
            if (transaction.BillingAddress != null)
            {
                data.Add("billing_firstname", $"{transaction.BillingAddress.FirstName}");
                data.Add("billing_lastname", $"{transaction.BillingAddress.LastName}");
                data.Add("billing_mail", $"{transaction.BillingAddress.Email}");
                data.Add("billing_company", $"{transaction.BillingAddress.Company}");
                data.Add("billing_coc", $"{transaction.BillingAddress.ChamberOfCommerceNumber}");
                data.Add("billing_address1", $"{transaction.BillingAddress.Address1}");
                data.Add("billing_address2", $"{transaction.BillingAddress.Address2}");
                data.Add("billing_zip", $"{transaction.BillingAddress.Zip}");
                data.Add("billing_city", $"{transaction.BillingAddress.City}");
                data.Add("billing_country", $"{transaction.BillingAddress.Country}");
                data.Add("billing_countrycode", $"{transaction.BillingAddress.CountryCode}");
                data.Add("billing_phone", $"{transaction.BillingAddress.Phone}");
            }
            if (transaction.ShippingAddress != null)
            {
                data.Add("shipping_firstname", $"{transaction.ShippingAddress.FirstName}");
                data.Add("shipping_lastname", $"{transaction.ShippingAddress.LastName}");
                data.Add("shipping_mail", $"{transaction.ShippingAddress.Email}");
                data.Add("shipping_company", $"{transaction.ShippingAddress.Company}");
                data.Add("shipping_address1", $"{transaction.ShippingAddress.Address1}");
                data.Add("shipping_address2", $"{transaction.ShippingAddress.Address2}");
                data.Add("shipping_zip", $"{transaction.ShippingAddress.Zip}");
                data.Add("shipping_city", $"{transaction.ShippingAddress.City}");
                data.Add("shipping_country", $"{transaction.ShippingAddress.Country}");
                data.Add("shipping_countrycode", $"{transaction.ShippingAddress.CountryCode}");
                data.Add("shipping_phone", $"{transaction.ShippingAddress.Phone}");
            }
            if (transaction.Products != null)
            {

                for (int i = 1; i <= transaction.Products.Count; i++)
                {
                    var product = transaction.Products[i - 1];
                    data.Add($"product_id_{i}", $"{product.Id}");
                    data.Add($"product_description_{i}", $"{product.Description}");
                    data.Add($"product_quantity_{i}", $"{product.Quantity}");
                    data.Add($"product_netprice_{i}", $"{product.NetPrice}");
                    data.Add($"product_total_{i}", $"{product.Total}");
                    data.Add($"product_nettotal_{i}", $"{product.NetTotal}");
                    data.Add($"product_tax_{i}", $"{product.Tax}");
                    data.Add($"product_taxrate_{i}", $"{product.TaxRate}");
                    data.Add($"product_type_{i}", $"{product.Type}");
                }
            }
            data.Add("qrcode", $"{transaction.QRCode}");
            data.Add("qrone", $"{transaction.QROne}");
            data.Add("qrvalid", $"{transaction.QRValid}");
            data.Add("qrchange", $"{transaction.QRChange}");
            data.Add("qrmin", $"{transaction.QRMin}");
            data.Add("qrmax", $"{transaction.QRMax}");
            data.Add("qrimage", $"{transaction.QRImage}");

            var response = await Execute<TransactionResponse>("TransactionRequest", data);

            var trxId = response.Transaction.Id;
            var issuerUrl = response.Transaction.IssuerUrl;
            var invoiceNo = response.Transaction.InvoiceNo;
            var documentId = response.Transaction.DocumentId;
            var documentUrl = response.Transaction.DocumentUrl;
            var sha1 = response.Signature.SHA1;

            // validate signature
            if (
                sha1 != GetSHA1($"{trxId}{issuerUrl}{GetMerchantId()}{GetMerchantKey()}") &&
                sha1 != GetSHA1($"{trxId}{invoiceNo}{documentId}{GetMerchantId()}{GetMerchantKey()}") &&
                sha1 != GetSHA1($"{trxId}{documentId}{GetMerchantId()}{GetMerchantKey()}")
                )
            {
                throw new SisowException("Invalid response!");
            }


            // generate result
            var transactionResponse = new Transaction();
            if (!string.IsNullOrEmpty(trxId))
            {
                transactionResponse = await Get(trxId);
            }

            transactionResponse.DocumentId = documentId;
            transactionResponse.DocumentUrl = documentUrl;
            transactionResponse.IssuerUrl = Uri.UnescapeDataString(issuerUrl);
            transactionResponse.InvoiceNo = invoiceNo;

            return transactionResponse;
        }

        public async Task<Transaction> Edit(string transactionId, string oldPurchaseId, string newPurchaseId)
        {
            // get merchant info
            var merchantId = GetMerchantId();
            var merchantKey = GetMerchantKey();

            // make request to Sisow
            var data = new Dictionary<string, string>();
            data.Add("trxid", transactionId);
            data.Add("old", oldPurchaseId);
            data.Add("new", newPurchaseId);
            data.Add("merchantid", merchantId);
            data.Add("sha1", GetSHA1(transactionId + oldPurchaseId + newPurchaseId + merchantId + merchantKey));
            var response = await Execute<AdjustPurchaseResponse>("AdjustPurchaseId", data);

            // validate request
            if (string.IsNullOrEmpty(response.Purchase.Id) || response.Signature.SHA1 != GetSHA1(newPurchaseId + merchantId + merchantKey))
            {
                throw new SisowException("Invalid Sisow response");
            }

            return await Get(transactionId);
        }

        public async Task<Transaction> Cancel(string transactionId)
        {
            // validate transaction ID
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new SisowException("No Transaction Id");
            }

            // load merchant information
            var merchantId = GetMerchantId();
            var merchantKey = GetMerchantKey();

            // do request
            var data = new Dictionary<string, string>();
            data.Add("trxid", transactionId);
            data.Add("merchantid", merchantId);
            data.Add("sha1", GetSHA1(transactionId + merchantId + merchantKey));
            var response = await Execute<TransactionResponse>("CancelReservationRequest", data);

            if (response.Transaction.Status != "Cancelled" || response.Signature.SHA1 != GetSHA1(transactionId + merchantId + merchantKey))
            {
                throw new SisowException("Sisow invalid response");
            }

            return await Get(transactionId);
        }

        public async Task<Refund> Refund(string transactionId, int amount)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new SisowException("No Transaction ID");
            }

            if (amount == default(int))
            {
                throw new SisowException("No amount");
            }

            // get merchant info
            var merchantId = GetMerchantId();
            var merchantKey = GetMerchantKey();

            // get response
            var data = new Dictionary<string, string>();
            data.Add("trxid", transactionId);
            data.Add("amount", $"{amount}");
            data.Add("merchantid", merchantId);
            data.Add("sha1", GetSHA1(transactionId + merchantId + merchantKey));
            var response = await Execute<RefundResponse>("RefundRequest", data);

            // get refund ID
            var refundId = response.Refund.Id;

            // validate response
            if (string.IsNullOrEmpty(refundId) || response.Signature.SHA1 != GetSHA1(refundId + merchantId + merchantKey))
            {
                throw new SisowException("Invalid Sisow response");
            }

            return response.Refund;
        }
    }
}
