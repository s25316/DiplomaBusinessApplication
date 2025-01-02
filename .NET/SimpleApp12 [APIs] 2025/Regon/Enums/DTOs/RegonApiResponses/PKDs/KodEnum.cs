using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.PKDs
{
    public enum KodEnum
    {
        [XmlEnum("praw_pkdKod")]
        praw_pkdKod,
        [XmlEnum("lokpraw_pkdKod")]
        lokpraw_pkdKod,
        [XmlEnum("lokfiz_pkd_Kod")]
        lokfiz_pkd_Kod,
        [XmlEnum("fiz_pkd_Kod")]
        fiz_pkd_Kod,
    }
}
