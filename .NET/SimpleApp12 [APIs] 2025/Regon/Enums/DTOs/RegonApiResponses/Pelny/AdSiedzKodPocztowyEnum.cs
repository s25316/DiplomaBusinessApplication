using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum AdSiedzKodPocztowyEnum
    {
        [XmlEnum("fiz_adSiedzKodPocztowy")]
        fiz_adSiedzKodPocztowy,
        [XmlEnum("lokpraw_adSiedzKodPocztowy")]
        lokpraw_adSiedzKodPocztowy,
        [XmlEnum("praw_adSiedzKodPocztowy")]
        praw_adSiedzKodPocztowy,
        [XmlEnum("lokfiz_adSiedzKodPocztowy")]
        lokfiz_adSiedzKodPocztowy,
    }
}
