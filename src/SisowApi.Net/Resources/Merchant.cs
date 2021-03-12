using System.Collections.Generic;
using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "checkmerchantresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class CheckMerchantResponse
    {
        [XmlElement(ElementName = "merchant")]
        public Merchant Merchant { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    public class Merchant
    {
        [XmlElement(ElementName = "active")]
        public bool Active { get; set; }

        [XmlElement(ElementName = "merchantid")]
        public string Id { get; set; }

        [XmlArray(ElementName = "payments")]
        [XmlArrayItem(ElementName = "payment")]
        public List<string> Payments { get; set; }
    }
}
