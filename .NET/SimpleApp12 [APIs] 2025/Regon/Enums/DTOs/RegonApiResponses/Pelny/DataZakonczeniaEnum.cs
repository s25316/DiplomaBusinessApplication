using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum DataZakonczeniaEnum
    {
        [XmlEnum("fiz_dataZakonczeniaDzialalnosci")]
        fiz_dataZakonczeniaDzialalnosci,
        [XmlEnum("lokpraw_dataZakonczeniaDzialalnosci")]
        lokpraw_dataZakonczeniaDzialalnosci,
        [XmlEnum("praw_dataZakonczeniaDzialalnosci")]
        praw_dataZakonczeniaDzialalnosci,
        [XmlEnum("lokfiz_dataZakonczeniaDzialalnosci")]
        lokfiz_dataZakonczeniaDzialalnosci,
    }
}
