using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum FormaFinansowaniaSymbolEnum
    {
        [XmlEnum("praw_formaFinansowania_Symbol")]
        praw_formaFinansowania_Symbol,
        [XmlEnum("lokfiz_formaFinansowania_Symbol")]
        lokfiz_formaFinansowania_Symbol,
        [XmlEnum("lokpraw_formaFinansowania_Symbol")]
        lokpraw_formaFinansowania_Symbol,
    }
}
