using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum AdSiedKrajNazwaEnum
    {
        [XmlEnum("fiz_adSiedzKraj_Nazwa")]
        fiz_adSiedzKraj_Nazwa,
        [XmlEnum("lokpraw_adSiedzKraj_Nazwa")]
        lokpraw_adSiedzKraj_Nazwa,
        [XmlEnum("praw_adSiedzKraj_Nazwa")]
        praw_adSiedzKraj_Nazwa,
        [XmlEnum("lokfiz_adSiedzKraj_Nazwa")]
        lokfiz_adSiedzKraj_Nazwa,
    }
}
