using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "transactionrequest", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class TransactionResponse
    {
        [XmlElement(ElementName = "transaction")]
        public Transaction Transaction { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    [XmlRoot(ElementName = "statusresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class StatusResponse
    {
        [XmlElement(ElementName = "transaction")]
        public Transaction Transaction { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    public class Transaction
    {
        [XmlElement(ElementName = "trxid")]
        public string Id { get; set; }

        [XmlElement(ElementName = "issuerurl")]
        public string IssuerUrl { get; set; }

        [XmlElement(ElementName = "invoiceno")]
        public string InvoiceNo { get; set; }

        [XmlElement(ElementName = "documentid")]
        public string DocumentId { get; set; }

        [XmlElement(ElementName = "documenturl")]
        public string DocumentUrl { get; set; }

        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "amount")]
        public string Amount { get; set; }

        [XmlElement(ElementName = "purchaseid")]
        public string PurchaseId { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "entrancecode")]
        public string EntranceCode { get; set; }

        [XmlElement(ElementName = "issuerid")]
        public string IssuerId { get; set; }

        [XmlElement(ElementName = "timestamp")]
        public string Timestamp { get; set; }

        [XmlElement(ElementName = "consumername")]
        public string ConsumerName { get; set; }

        [XmlElement(ElementName = "consumeraccount")]
        public string ConsumerAccount { get; set; }

        [XmlElement(ElementName = "consumercity")]
        public string ConsumerCity { get; set; }

        [XmlElement(ElementName = "consumeriban")]
        public string ConsumerIban { get; set; }

        [XmlElement(ElementName = "consumerbic")]
        public string ConsumerBic { get; set; }
    }

    public class TransactionRequest
    {
        /// <summary>
        /// The payment method option (initially empty so by default iDEAL will be selected).
        /// </summary>
        public string Payment { get; set; }

        /// <summary>
        /// The payment reference with a maximum of 16 characters.
        /// </summary>
        public string PurchaseId { get; set; }

        /// <summary>
        /// The entrancecode will also be returned in the returnurl for internal control purposes with a maximum of 40 characters, strict alphanumerical (only characters and numbers are allowed; [A-Za-z0-9]). If not supplied, the purchaseid will be used (if possible because spaces are allowed for the purchaseid but not for the entrancecode)
        /// </summary>
        public string EntranceCode { get; set; }

        /// <summary>
        /// The amount in cents.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// A description of the purchase with a maximum of 32 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// If supplied with a value of “true” then test/simulation transactions van be performed. This requires the option “Testen met behulp van simulator (toestaan)” to be activated in the Sisow account at ‘Mijn Profiel – page Geavanceerd’
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// The URL to which is returned after a “normal” transaction process.
        /// </summary>
        public Uri ReturnUrl { get; set; }

        /// <summary>
        /// The URL to which is returned after the transaction is cancelled. If not supplied then the returnurl is used
        /// </summary>
        public Uri CancelUrl { get; set; }

        /// <summary>
        /// This URL is used to report the status of a transaction.
        /// </summary>
        public Uri NotifyUrl { get; set; }

        /// <summary>
        /// This URL is used to report the status of a transaction.
        /// </summary>
        public Uri CallbackUrl { get; set; }

        /// <summary>
        /// The calculated SHA1 value of the following parameters, these should be stuck together as a long string. You can then calculate the SHA1 value. purchaseid/entrancecode/amount/shopid/merchantid/merchantkey
        /// If the entrance code is not used, the purchaseid must be included twice.
        /// purchaseid/purchaseid/amount/shopid/merchantid/merchantkey
        /// If the shopid is not used, you can leave it out of the calculation.
        /// </summary>
        public string SHA1 { get; set; }

        /// <summary>
        /// ID of the selected iDEAL bank, see DirectoryRequest.
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// The customer code.
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// The currency of the payment (Default is ‘EUR’).
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// IP address of the customer.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// BIC of the customer.
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// IBAN of the customer.
        /// </summary>
        public string IBAN { get; set; }

        /// <summary>
        /// Gender of the customer ‘m’ is male ‘f’ is female.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Date of birth of the customer
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Include an iDEAL payment link in the e-mail regarding the transfer to the customer (“true”/”false”).
        /// </summary>
        public bool Including { get; set; }

        /// <summary>
        /// The language of the payment page.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// The amount of days the bank transfer is valid.
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Billing address
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Shipping address
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Products
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Transaction request is iDEAL QR
        /// </summary>
        public bool QRCode { get; set; }

        /// <summary>
        /// QR-code can only be used once
        /// </summary>
        public bool QROne { get; set; }

        /// <summary>
        /// QR-code expire date
        /// </summary>
        public DateTime QRValid { get; set; }

        /// <summary>
        /// The amount can be changed
        /// </summary>
        public bool QRChange { get; set; }

        /// <summary>
        /// Minimum amount for the transaction in cents
        /// </summary>
        public int QRMin { get; set; }

        /// <summary>
        /// Maximum amount for the transaction in cents
        /// </summary>
        public int QRMax { get; set; }

        /// <summary>
        /// Receive URL to the QR-code instead of the Sisow payment screen.
        /// </summary>
        public bool QRImage { get; set; }
    }
}
