using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedzUlicaSymbolEnum
    {
        [XmlEnum("fiz_adSiedzUlica_Symbol")]
        fiz_adSiedzUlica_Symbol,
        [XmlEnum("lokpraw_adSiedzUlica_Symbol")]
        lokpraw_adSiedzUlica_Symbol,
        [XmlEnum("praw_adSiedzUlica_Symbol")]
        praw_adSiedzUlica_Symbol,
        [XmlEnum("lokfiz_adSiedzUlica_Symbol")]
        lokfiz_adSiedzUlica_Symbol,
    }
}
