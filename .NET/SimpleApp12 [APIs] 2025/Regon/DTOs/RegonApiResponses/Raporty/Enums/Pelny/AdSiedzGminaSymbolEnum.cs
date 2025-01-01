using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedzGminaSymbolEnum
    {
        [XmlEnum("fiz_adSiedzGmina_Symbol")]
        fiz_adSiedzGmina_Symbol,
        [XmlEnum("lokpraw_adSiedzGmina_Symbol")]
        lokpraw_adSiedzGmina_Symbol,
        [XmlEnum("praw_adSiedzGmina_Symbol")]
        praw_adSiedzGmina_Symbol,
        [XmlEnum("lokfiz_adSiedzGmina_Symbol")]
        lokfiz_adSiedzGmina_Symbol,

    }
}
