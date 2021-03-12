using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "invoiceresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class InvoiceResponse
    {
        [XmlElement(ElementName = "invoice")]
        public Invoice Invoice { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    [XmlRoot(ElementName = "creditinvoiceresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class CreditInvoiceResponse
    {
        [XmlElement(ElementName = "invoice")]
        public Invoice CreditInvoice { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    public class Invoice
    {
        [XmlElement(ElementName = "invoiceNo")]
        public string InvoiceNo { get; set; }

        [XmlElement(ElementName = "documentid")]
        public string DocumentId { get; set; }
    }
}
