using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedMiejscowoscNazwaEnum
    {
        [XmlEnum("fiz_adSiedzMiejscowosc_Nazwa")]
        fiz_adSiedzMiejscowosc_Nazwa,
        [XmlEnum("lokpraw_adSiedzMiejscowosc_Nazwa")]
        lokpraw_adSiedzMiejscowosc_Nazwa,
        [XmlEnum("praw_adSiedzMiejscowosc_Nazwa")]
        praw_adSiedzMiejscowosc_Nazwa,
        [XmlEnum("lokfiz_adSiedzMiejscowosc_Nazwa")]
        lokfiz_adSiedzMiejscowosc_Nazwa,
    }
}
