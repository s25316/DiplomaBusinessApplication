using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum WWWEnum
    {
        [XmlEnum("fiz_adresStronyinternetowej")]
        fiz_adresStronyinternetowej,
        [XmlEnum("praw_adresStronyinternetowej")]
        praw_adresStronyinternetowej,
    }
}
