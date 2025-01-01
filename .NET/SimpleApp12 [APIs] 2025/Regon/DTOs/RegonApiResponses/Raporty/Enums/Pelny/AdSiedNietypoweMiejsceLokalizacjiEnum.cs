using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedNietypoweMiejsceLokalizacjiEnum
    {
        [XmlEnum("fiz_adSiedzNietypoweMiejsceLokalizacji")]
        fiz_adSiedzNietypoweMiejsceLokalizacji,
        [XmlEnum("lokpraw_adSiedzNietypoweMiejsceLokalizacji")]
        lokpraw_adSiedzNietypoweMiejsceLokalizacji,
        [XmlEnum("praw_adSiedzNietypoweMiejsceLokalizacji")]
        praw_adSiedzNietypoweMiejsceLokalizacji,
        [XmlEnum("lokfiz_adSiedzNietypoweMiejsceLokalizacji")]
        lokfiz_adSiedzNietypoweMiejsceLokalizacji,
    }
}
