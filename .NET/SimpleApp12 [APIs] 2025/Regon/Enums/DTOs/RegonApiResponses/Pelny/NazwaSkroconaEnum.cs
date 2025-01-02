using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum NazwaSkroconaEnum
    {
        [XmlEnum("fiz_nazwaSkrocona")]
        fiz_nazwaSkrocona,
        [XmlEnum("praw_nazwaSkrocona")]
        praw_nazwaSkrocona,
    }
}
