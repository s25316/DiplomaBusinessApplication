using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum DataWznowieniaEnum
    {
        [XmlEnum("fiz_dataWznowieniaDzialalnosci")]
        fiz_dataWznowieniaDzialalnosci,
        [XmlEnum("lokpraw_dataWznowieniaDzialalnosci")]
        lokpraw_dataWznowieniaDzialalnosci,
        [XmlEnum("praw_dataWznowieniaDzialalnosci")]
        praw_dataWznowieniaDzialalnosci,
        [XmlEnum("lokfiz_dataWznowieniaDzialalnosci")]
        lokfiz_dataWznowieniaDzialalnosci,
    }
}
