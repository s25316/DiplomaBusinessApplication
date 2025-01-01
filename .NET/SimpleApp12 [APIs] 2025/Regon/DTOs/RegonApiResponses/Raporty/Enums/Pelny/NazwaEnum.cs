using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum NazwaEnum
    {
        [XmlEnum("fiz_nazwa")]
        fiz_nazwa,
        [XmlEnum("lokpraw_nazwa")]
        lokpraw_nazwa,
        [XmlEnum("praw_nazwa")]
        praw_nazwa,
        [XmlEnum("lokfiz_nazwa")]
        lokfiz_nazwa,
    }
}
