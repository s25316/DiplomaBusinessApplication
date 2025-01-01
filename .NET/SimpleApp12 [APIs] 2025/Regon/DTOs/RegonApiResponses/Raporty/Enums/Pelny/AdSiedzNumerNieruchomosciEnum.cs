using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedzNumerNieruchomosciEnum
    {
        [XmlEnum("fiz_adSiedzNumerNieruchomosci")]
        fiz_adSiedzNumerNieruchomosci,
        [XmlEnum("lokpraw_adSiedzNumerNieruchomosci")]
        lokpraw_adSiedzNumerNieruchomosci,
        [XmlEnum("praw_adSiedzNumerNieruchomosci")]
        praw_adSiedzNumerNieruchomosci,
        [XmlEnum("lokfiz_adSiedzNumerNieruchomosci")]
        lokfiz_adSiedzNumerNieruchomosci,
    }
}
