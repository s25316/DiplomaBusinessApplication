using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses
{
    [XmlRoot(ElementName = "dane", Namespace = "http://CIS/BIR/PUBL/2014/07")]
    public class DaneSzukaj
    {
        [XmlElement(ElementName = "Regon")]
        public string Regon { get; init; } = null!;
        [XmlElement(ElementName = "RegonLink")]
        public string RegonLink { get; init; } = null!;
        [XmlElement(ElementName = "Nazwa")]
        public string Nazwa { get; init; } = null!;
        [XmlElement(ElementName = "Wojewodztwo")]
        public string? Wojewodztwo { get; init; } = null;
        [XmlElement(ElementName = "Powiat")]
        public string? Powiat { get; init; } = null;
        [XmlElement(ElementName = "Gmina")]
        public string? Gmina { get; init; } = null;
        [XmlElement(ElementName = "Miejscowosc")]
        public string? Miejscowosc { get; init; } = null;
        [XmlElement(ElementName = "KodPocztowy")]
        public string? KodPocztowy { get; init; } = null;
        [XmlElement(ElementName = "Typ")]
        public string Typ { get; init; } = null!;
        [XmlElement(ElementName = "SilosID")]
        public int SilosID { get; init; } = -1;
    }
}
