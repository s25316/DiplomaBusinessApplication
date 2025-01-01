using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedzPowiatSymbolEnum
    {
        [XmlEnum("fiz_adSiedzPowiat_Symbol")]
        fiz_adSiedzPowiat_Symbol,
        [XmlEnum("lokpraw_adSiedzPowiat_Symbol")]
        lokpraw_adSiedzPowiat_Symbol,
        [XmlEnum("praw_adSiedzPowiat_Symbol")]
        praw_adSiedzPowiat_Symbol,
        [XmlEnum("lokfiz_adSiedzPowiat_Symbol")]
        lokfiz_adSiedzPowiat_Symbol,
    }
}
