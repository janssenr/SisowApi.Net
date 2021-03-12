using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "cancelreservationresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class CancelReservationResponse
    {
        [XmlElement(ElementName = "reservation>")]
        public Reservation Reservation { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    public class Reservation
    {
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
    }
}
