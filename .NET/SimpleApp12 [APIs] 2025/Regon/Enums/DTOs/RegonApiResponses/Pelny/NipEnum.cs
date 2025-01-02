using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum NipEnum
    {
        [XmlEnum("lokpraw_nip")]
        lokpraw_nip,
        [XmlEnum("praw_nip")]
        praw_nip,
    }
}
