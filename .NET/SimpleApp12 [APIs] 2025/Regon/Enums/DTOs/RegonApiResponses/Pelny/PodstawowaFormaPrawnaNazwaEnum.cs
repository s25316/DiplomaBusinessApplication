using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum PodstawowaFormaPrawnaNazwaEnum
    {
        [XmlEnum("praw_podstawowaFormaPrawna_Nazwa")]
        praw_podstawowaFormaPrawna_Nazwa,
        [XmlEnum("lokpraw_podstawowaFormaPrawna_Nazwa")]
        lokpraw_podstawowaFormaPrawna_Nazwa,
    }
}
