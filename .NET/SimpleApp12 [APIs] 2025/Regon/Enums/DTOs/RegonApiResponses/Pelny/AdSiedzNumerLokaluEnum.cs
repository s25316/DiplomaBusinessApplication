using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum AdSiedzNumerLokaluEnum
    {
        [XmlEnum("fiz_adSiedzNumerLokalu")]
        fiz_adSiedzNumerLokalu,
        [XmlEnum("lokpraw_adSiedzNumerLokalu")]
        lokpraw_adSiedzNumerLokalu,
        [XmlEnum("praw_adSiedzNumerLokalu")]
        praw_adSiedzNumerLokalu,
        [XmlEnum("lokfiz_adSiedzNumerLokalu")]
        lokfiz_adSiedzNumerLokalu,
    }
}
