using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum PodstawowaFormaPrawnaSymbolEnum
    {
        [XmlEnum("praw_podstawowaFormaPrawna_Symbol")]
        praw_podstawowaFormaPrawna_Symbol,
        [XmlEnum("lokpraw_podstawowaFormaPrawna_Symbol")]
        lokpraw_podstawowaFormaPrawna_Symbol,
    }
}
