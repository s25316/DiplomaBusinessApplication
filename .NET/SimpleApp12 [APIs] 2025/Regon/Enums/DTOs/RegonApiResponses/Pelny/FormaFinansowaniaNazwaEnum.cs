using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum FormaFinansowaniaNazwaEnum
    {
        [XmlEnum("praw_formaFinansowania_Nazwa")]
        praw_formaFinansowania_Nazwa,
        [XmlEnum("lokfiz_formaFinansowania_Nazwa")]
        lokfiz_formaFinansowania_Nazwa,
        [XmlEnum("lokpraw_formaFinansowania_Nazwa")]
        lokpraw_formaFinansowania_Nazwa,
    }
}
