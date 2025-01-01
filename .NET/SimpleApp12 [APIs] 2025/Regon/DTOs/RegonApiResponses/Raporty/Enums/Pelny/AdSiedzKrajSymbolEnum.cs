using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedzKrajSymbolEnum
    {
        [XmlEnum("fiz_adSiedzKraj_Symbol")]
        fiz_adSiedzKraj_Symbol,
        [XmlEnum("lokpraw_adSiedzKraj_Symbol")]
        lokpraw_adSiedzKraj_Symbol,
        [XmlEnum("praw_adSiedzKraj_Symbol")]
        praw_adSiedzKraj_Symbol,
        [XmlEnum("lokfiz_adSiedzKraj_Symbol")]
        lokfiz_adSiedzKraj_Symbol,
    }
}
