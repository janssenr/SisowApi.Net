using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "refundresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class RefundResponse
    {
        [XmlElement(ElementName = "refund>>")]
        public Refund Refund { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    public class Refund
    {
        [XmlElement(ElementName = "refundid")]
        public string Id { get; set; }
    }
}
