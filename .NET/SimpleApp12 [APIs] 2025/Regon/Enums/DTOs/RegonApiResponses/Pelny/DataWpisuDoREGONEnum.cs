using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum DataWpisuDoREGONEnum
    {
        [XmlEnum("fiz_dataWpisuDoREGONDzialalnosci")]
        fiz_dataWpisuDoREGONDzialalnosci,
        [XmlEnum("lokpraw_dataWpisuDoREGON")]
        lokpraw_dataWpisuDoREGON,
        [XmlEnum("praw_dataWpisuDoREGON")]
        praw_dataWpisuDoREGON,
        [XmlEnum("lokfiz_dataWpisuDoREGON")]
        lokfiz_dataWpisuDoREGON,
    }
}
