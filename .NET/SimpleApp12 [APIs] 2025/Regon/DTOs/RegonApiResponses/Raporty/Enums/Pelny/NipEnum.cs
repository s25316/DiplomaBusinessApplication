using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum NipEnum
    {
        [XmlEnum("lokpraw_nip")]
        lokpraw_nip,
        [XmlEnum("praw_nip")]
        praw_nip,
    }
}
