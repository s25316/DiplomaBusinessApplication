using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum FormaWlasnosciSymbolEnum
    {
        [XmlEnum("praw_formaWlasnosci_Symbol")]
        praw_formaWlasnosci_Symbol,
        [XmlEnum("lokpraw_formaWlasnosci_Symbol")]
        lokpraw_formaWlasnosci_Symbol,
    }
}
