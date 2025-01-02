using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum FormaWlasnosciSymbolEnum
    {
        [XmlEnum("praw_formaWlasnosci_Symbol")]
        praw_formaWlasnosci_Symbol,
        [XmlEnum("lokpraw_formaWlasnosci_Symbol")]
        lokpraw_formaWlasnosci_Symbol,
    }
}
