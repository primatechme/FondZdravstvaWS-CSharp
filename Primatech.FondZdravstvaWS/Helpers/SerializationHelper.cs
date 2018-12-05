using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Primatech.FondZdravstvaWS.Helpers
{
    public class SerializationHelper
    {
        public static string DataToXmlString<T>(T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            var xml = "";

            using (var sw = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sw, new XmlWriterSettings { Encoding = Encoding.UTF8 }))
            {
                serializer.Serialize(writer, data);
                xml = sw.ToString();
            }

            return xml;
        }

        public static T XmlStringToData<T>(string xml)
        {
            var result = default(T);

            using (TextReader reader = new StringReader(xml))
            {
                var deserializer = new XmlSerializer(typeof(T));
                result = (T)deserializer.Deserialize(reader);
            }

            return result;
        }
    }
}
