using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum NumerFaksuEnum
    {
        [XmlEnum("fiz_numerFaksu")]
        fiz_numerFaksu,
        [XmlEnum("praw_numerFaksu")]
        praw_numerFaksu,
        [XmlEnum("fizC_numerFaksu")]
        fizC_numerFaksu,
    }
}
