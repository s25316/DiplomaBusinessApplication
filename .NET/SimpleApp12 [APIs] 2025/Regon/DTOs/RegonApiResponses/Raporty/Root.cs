using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty
{
    [XmlRoot(ElementName = "root", Namespace = "http://CIS/BIR/PUBL/2014/07")]
    public class Root<T>
    {
        [XmlElement(ElementName = "dane")]
        public List<T> Dane { get; init; } = new List<T>();
    }
}
