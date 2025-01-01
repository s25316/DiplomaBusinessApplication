using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedUlicaNazwaEnum
    {
        [XmlEnum("fiz_adSiedzUlica_Nazwa")]
        fiz_adSiedzUlica_Nazwa,
        [XmlEnum("lokpraw_adSiedzUlica_Nazwa")]
        lokpraw_adSiedzUlica_Nazwa,
        [XmlEnum("praw_adSiedzUlica_Nazwa")]
        praw_adSiedzUlica_Nazwa,
        [XmlEnum("lokfiz_adSiedzUlica_Nazwa")]
        lokfiz_adSiedzUlica_Nazwa,
    }
}
