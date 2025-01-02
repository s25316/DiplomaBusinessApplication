using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum AdSiedWojewodztwoNazwaEnum
    {
        [XmlEnum("fiz_adSiedzWojewodztwo_Nazwa")]
        fiz_adSiedzWojewodztwo_Nazwa,
        [XmlEnum("lokpraw_adSiedzWojewodztwo_Nazwa")]
        lokpraw_adSiedzWojewodztwo_Nazwa,
        [XmlEnum("praw_adSiedzWojewodztwo_Nazwa")]
        praw_adSiedzWojewodztwo_Nazwa,
        [XmlEnum("lokfiz_adSiedzWojewodztwo_Nazwa")]
        lokfiz_adSiedzWojewodztwo_Nazwa,
    }
}
