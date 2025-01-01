using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum DataZaistnieniaZmianyEnum
    {
        [XmlEnum("fiz_dataZaistnieniaZmianyDzialalnosci")]
        fiz_dataZaistnieniaZmianyDzialalnosci,
        [XmlEnum("lokpraw_dataZaistnieniaZmiany")]
        lokpraw_dataZaistnieniaZmiany,
        [XmlEnum("praw_dataZaistnieniaZmiany")]
        praw_dataZaistnieniaZmiany,
        [XmlEnum("lokfiz_dataZaistnieniaZmiany")]
        lokfiz_dataZaistnieniaZmiany,
    }
}
