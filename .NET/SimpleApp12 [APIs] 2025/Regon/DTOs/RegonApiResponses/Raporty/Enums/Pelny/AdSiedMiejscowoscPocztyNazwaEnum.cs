using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdSiedMiejscowoscPocztyNazwaEnum
    {
        [XmlEnum("fiz_adSiedzMiejscowoscPoczty_Nazwa")]
        fiz_adSiedzMiejscowoscPoczty_Nazwa,
        [XmlEnum("lokpraw_adSiedzMiejscowoscPoczty_Nazwa")]
        lokpraw_adSiedzMiejscowoscPoczty_Nazwa,
        [XmlEnum("praw_adSiedzMiejscowoscPoczty_Nazwa")]
        praw_adSiedzMiejscowoscPoczty_Nazwa,
        [XmlEnum("lokfiz_adSiedzMiejscowoscPoczty_Nazwa")]
        lokfiz_adSiedzMiejscowoscPoczty_Nazwa,
    }
}
