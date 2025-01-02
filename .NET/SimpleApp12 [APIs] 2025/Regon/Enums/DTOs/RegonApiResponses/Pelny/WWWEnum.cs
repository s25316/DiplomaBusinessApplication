using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum WWWEnum
    {
        [XmlEnum("fiz_adresStronyinternetowej")]
        fiz_adresStronyinternetowej,
        [XmlEnum("praw_adresStronyinternetowej")]
        praw_adresStronyinternetowej,
        [XmlEnum("fizC_adresStronyInternetowej")]
        fizC_adresStronyInternetowej,
    }
}
