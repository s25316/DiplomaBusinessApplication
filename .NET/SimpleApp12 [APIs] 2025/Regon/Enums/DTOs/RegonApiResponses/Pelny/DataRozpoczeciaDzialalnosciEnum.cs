using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum DataRozpoczeciaDzialalnosciEnum
    {
        [XmlEnum("fiz_dataRozpoczeciaDzialalnosci")]
        fiz_dataRozpoczeciaDzialalnosci,
        [XmlEnum("lokpraw_dataRozpoczeciaDzialalnosci")]
        lokpraw_dataRozpoczeciaDzialalnosci,
        [XmlEnum("praw_dataRozpoczeciaDzialalnosci")]
        praw_dataRozpoczeciaDzialalnosci,
        [XmlEnum("lokfiz_dataRozpoczeciaDzialalnosci")]
        lokfiz_dataRozpoczeciaDzialalnosci,
    }
}
