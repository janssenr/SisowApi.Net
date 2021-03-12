using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SisowApi.Net.Helpers
{
    internal static class XmlHelper
    {
        internal static string Serialize<T>(T obj)
        {
            string retVal;
            var serializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, obj);
                retVal = Encoding.UTF8.GetString(ms.ToArray());
            }
            return retVal;
        }

        internal static T Deserialize<T>(string xml)
        {
            T obj;
            var serializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                obj = (T)serializer.Deserialize(ms);
                ms.Close();
            }
            return obj;
        }
    }
}
