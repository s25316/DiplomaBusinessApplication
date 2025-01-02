using Regon.Enums.DTOs.RegonApiResponses.PKDs;
using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.PKDs
{
    public class Pkd
    {
        [XmlChoiceIdentifier("KodEnum")]
        [XmlElement(ElementName = "praw_pkdKod")]
        [XmlElement(ElementName = "lokpraw_pkdKod")]
        [XmlElement(ElementName = "lokfiz_pkd_Kod")]
        [XmlElement(ElementName = "fiz_pkd_Kod")]
        public string Kod { get; init; } = null!;
        public KodEnum KodEnum { get; init; }


        [XmlChoiceIdentifier("NazwaEnum")]
        [XmlElement(ElementName = "praw_pkdNazwa")]
        [XmlElement(ElementName = "lokpraw_pkdNazwa")]
        [XmlElement(ElementName = "lokfiz_pkd_Nazwa")]
        [XmlElement(ElementName = "fiz_pkd_Nazwa")]
        public string Nazwa { get; init; } = null!;
        public NazwaEnum NazwaEnum { get; init; }


        [XmlChoiceIdentifier("PrzewazajaceEnum")]
        [XmlElement(ElementName = "praw_pkdPrzewazajace")]
        [XmlElement(ElementName = "lokpraw_pkdPrzewazajace")]
        [XmlElement(ElementName = "lokfiz_pkd_Przewazajace")]
        [XmlElement(ElementName = "fiz_pkd_Przewazajace")]
        public string Przewazajace { get; init; } = null!;
        public PrzewazajaceEnum PrzewazajaceEnum { get; init; }
    }
}
