using System.Collections.Generic;
using System.Xml.Serialization;

namespace SisowApi.Net.Resources
{
    [XmlRoot(ElementName = "batchresponse", Namespace = "https://www.sisow.nl/Sisow/REST")]
    public class BatchResponse
    {
        [XmlElement(ElementName = "batch>")]
        public Batch Batch { get; set; }

        [XmlElement(ElementName = "signature")]
        public Signature Signature { get; set; }
    }

    public class Batch
    {
        [XmlElement(ElementName = "batchid")]
        public string Id { get; set; }

        [XmlElement(ElementName = "timestamp")]
        public string Timestamp { get; set; }

        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlElement(ElementName = "amount")]
        public int Amount { get; set; }

        [XmlElement(ElementName = "cost")]
        public int Cost { get; set; }

        [XmlElement(ElementName = "batch")]
        public int BatchCost { get; set; }

        [XmlElement(ElementName = "total")]
        public int Total { get; set; }

        [XmlElement(ElementName = "payed")]
        public int Payed { get; set; }

        [XmlArray(ElementName = "transactions>")]
        [XmlArrayItem(ElementName = "transaction>")]
        public List<Transaction> Transactions { get; set; }
    }
}
