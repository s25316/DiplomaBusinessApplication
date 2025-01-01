using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum DataSkresleniaEnum
    {
        [XmlEnum("fiz_dataSkresleniazRegonDzialalnosci")]
        fiz_dataSkresleniazRegonDzialalnosci,
        [XmlEnum("lokpraw_dataSkresleniazRegon")]
        lokpraw_dataSkresleniazRegon,
        [XmlEnum("praw_dataSkresleniazRegon")]
        praw_dataSkresleniazRegon,
        [XmlEnum("lokfiz_dataSkresleniazRegon")]
        lokfiz_dataSkresleniazRegon,
    }
}
