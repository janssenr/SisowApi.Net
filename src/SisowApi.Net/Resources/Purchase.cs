using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "adjustpurchaseidresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class AdjustPurchaseResponse
    {
        [XmlElement(ElementName = "adjustpurchaseid")]
        public Purchase Purchase { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    public class Purchase
    {
        [XmlElement(ElementName = "purchaseid")]
        public string Id { get; set; }
    }
}
