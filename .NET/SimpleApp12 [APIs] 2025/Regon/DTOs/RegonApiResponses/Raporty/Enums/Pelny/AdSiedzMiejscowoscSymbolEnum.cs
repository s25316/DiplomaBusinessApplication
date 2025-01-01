using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedzMiejscowoscSymbolEnum
    {
        [XmlEnum("fiz_adSiedzMiejscowosc_Symbol")]
        fiz_adSiedzMiejscowosc_Symbol,
        [XmlEnum("lokpraw_adSiedzMiejscowosc_Symbol")]
        lokpraw_adSiedzMiejscowosc_Symbol,
        [XmlEnum("praw_adSiedzMiejscowosc_Symbol")]
        praw_adSiedzMiejscowosc_Symbol,
        [XmlEnum("lokfiz_adSiedzMiejscowosc_Symbol")]
        lokfiz_adSiedzMiejscowosc_Symbol,
    }
}
