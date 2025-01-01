using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum NazwaSkroconaEnum
    {
        [XmlEnum("fiz_nazwaSkrocona")]
        fiz_nazwaSkrocona,
        [XmlEnum("praw_nazwaSkrocona")]
        praw_nazwaSkrocona,
    }
}
