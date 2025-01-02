using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.PKDs
{
    public enum PrzewazajaceEnum
    {
        [XmlEnum("praw_pkdPrzewazajace")]
        praw_pkdPrzewazajace,
        [XmlEnum("lokpraw_pkdPrzewazajace")]
        lokpraw_pkdPrzewazajace,
        [XmlEnum("lokfiz_pkd_Przewazajace")]
        lokfiz_pkd_Przewazajace,
        [XmlEnum("fiz_pkd_Przewazajace")]
        fiz_pkd_Przewazajace,
    }
}
