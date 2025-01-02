using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.PKDs
{
    public enum NazwaEnum
    {
        [XmlEnum("praw_pkdNazwa")]
        praw_pkdNazwa,
        [XmlEnum("lokpraw_pkdNazwa")]
        lokpraw_pkdNazwa,
        [XmlEnum("lokfiz_pkd_Nazwa")]
        lokfiz_pkd_Nazwa,
        [XmlEnum("fiz_pkd_Nazwa")]
        fiz_pkd_Nazwa,
    }
}
