using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "errorresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class ErrorResponse
    {
        [XmlElement(ElementName = "error")]
        public Error Error { get; set; }
    }

    public class Error
    {
        [XmlElement(ElementName = "errorcode")]
        public string ErrorCode { get; set; }

        [XmlElement(ElementName = "errormessage")]
        public string ErrorMessage { get; set; }
    }
}
