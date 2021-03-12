using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    public class Signature
    {
        [XmlElement(ElementName = "sha1")]
        public string SHA1 { get; set; }
    }
}
