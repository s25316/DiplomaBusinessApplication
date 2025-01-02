using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
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
