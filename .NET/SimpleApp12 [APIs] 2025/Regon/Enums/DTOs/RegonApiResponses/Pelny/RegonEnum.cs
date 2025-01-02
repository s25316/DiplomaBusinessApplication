using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum RegonEnum
    {
        [XmlEnum("fiz_regon9")]
        fiz_regon9,
        [XmlEnum("lokpraw_regon14")]
        lokpraw_regon14,
        [XmlEnum("praw_regon14")]
        praw_regon14,
        [XmlEnum("lokfiz_regon14")]
        lokfiz_regon14,
    }
}
