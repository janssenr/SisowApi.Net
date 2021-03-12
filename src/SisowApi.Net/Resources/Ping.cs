using System;
using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "pingresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class PingResponse
    {
        [XmlElement(ElementName = "timestamp")]
        public string Timestamp { get; set; }
    }
}
