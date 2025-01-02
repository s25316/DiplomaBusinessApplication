using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum DataZawieszeniaEnum
    {
        [XmlEnum("fiz_dataZawieszeniaDzialalnosci")]
        fiz_dataZawieszeniaDzialalnosci,
        [XmlEnum("lokpraw_dataZawieszeniaDzialalnosci")]
        lokpraw_dataZawieszeniaDzialalnosci,
        [XmlEnum("praw_dataZawieszeniaDzialalnosci")]
        praw_dataZawieszeniaDzialalnosci,
        [XmlEnum("lokfiz_dataZawieszeniaDzialalnosci")]
        lokfiz_dataZawieszeniaDzialalnosci,
    }
}
