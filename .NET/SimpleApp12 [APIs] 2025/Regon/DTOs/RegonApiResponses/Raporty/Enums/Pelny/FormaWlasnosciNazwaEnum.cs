using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum FormaWlasnosciNazwaEnum
    {
        [XmlEnum("praw_formaWlasnosci_Nazwa")]
        praw_formaWlasnosci_Nazwa,
        [XmlEnum("lokpraw_formaWlasnosci_Nazwa")]
        lokpraw_formaWlasnosci_Nazwa,
    }
}
