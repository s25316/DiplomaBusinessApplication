using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum AdresEmailEnum
    {
        [XmlEnum("fiz_adresEmail")]
        fiz_adresEmail,
        [XmlEnum("praw_adresEmail")]
        praw_adresEmail,
    }
}
