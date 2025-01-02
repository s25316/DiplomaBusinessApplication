using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum AdresEmailEnum
    {
        [XmlEnum("fiz_adresEmail")]
        fiz_adresEmail,
        [XmlEnum("praw_adresEmail")]
        praw_adresEmail,
        [XmlEnum("fizC_adresEmail")]
        fizC_adresEmail,
        [XmlEnum("fiz_adresEmail2")]
        fiz_adresEmail2,
        [XmlEnum("praw_adresEmail2")]
        praw_adresEmail2,
    }
}
