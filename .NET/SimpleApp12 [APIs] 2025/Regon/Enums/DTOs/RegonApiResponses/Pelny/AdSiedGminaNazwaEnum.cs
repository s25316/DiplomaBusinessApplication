using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum AdSiedGminaNazwaEnum
    {
        [XmlEnum("fiz_adSiedzGmina_Nazwa")]
        fiz_adSiedzGmina_Nazwa,
        [XmlEnum("lokpraw_adSiedzGmina_Nazwa")]
        lokpraw_adSiedzGmina_Nazwa,
        [XmlEnum("praw_adSiedzGmina_Nazwa")]
        praw_adSiedzGmina_Nazwa,
        [XmlEnum("lokfiz_adSiedzGmina_Nazwa")]
        lokfiz_adSiedzGmina_Nazwa,
    }
}
