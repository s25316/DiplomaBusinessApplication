using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum AdSiedPowiatNazwaEnum
    {
        [XmlEnum("fiz_adSiedzPowiat_Nazwa")]
        fiz_adSiedzPowiat_Nazwa,
        [XmlEnum("lokpraw_adSiedzPowiat_Nazwa")]
        lokpraw_adSiedzPowiat_Nazwa,
        [XmlEnum("praw_adSiedzPowiat_Nazwa")]
        praw_adSiedzPowiat_Nazwa,
        [XmlEnum("lokfiz_adSiedzPowiat_Nazwa")]
        lokfiz_adSiedzPowiat_Nazwa,
    }
}
