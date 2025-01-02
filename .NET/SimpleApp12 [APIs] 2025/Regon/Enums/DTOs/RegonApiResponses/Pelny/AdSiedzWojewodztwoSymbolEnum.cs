using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum AdSiedzWojewodztwoSymbolEnum
    {
        [XmlEnum("fiz_adSiedzWojewodztwo_Symbol")]
        fiz_adSiedzWojewodztwo_Symbol,
        [XmlEnum("lokpraw_adSiedzWojewodztwo_Symbol")]
        lokpraw_adSiedzWojewodztwo_Symbol,
        [XmlEnum("praw_adSiedzWojewodztwo_Symbol")]
        praw_adSiedzWojewodztwo_Symbol,
        [XmlEnum("lokfiz_adSiedzWojewodztwo_Symbol")]
        lokfiz_adSiedzWojewodztwo_Symbol,
    }
}
