using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum NumerFaksuEnum
    {
        [XmlEnum("fiz_numerFaksu")]
        fiz_numerFaksu,
        [XmlEnum("praw_numerFaksu")]
        praw_numerFaksu,
    }
}
