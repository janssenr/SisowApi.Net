using System.Collections.Generic;
using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "directoryresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class DirectoryResponse
    {
        [XmlArray(ElementName = "directory")]
        [XmlArrayItem(ElementName = "issuer")]
        public List<Issuer> Issuers { get; set; }
    }

    public class Issuer
    {
        [XmlElement(ElementName = "issuerid")]
        public string Id { get; set; }

        [XmlElement(ElementName = "issuername")]
        public string Name { get; set; }
    }
}
