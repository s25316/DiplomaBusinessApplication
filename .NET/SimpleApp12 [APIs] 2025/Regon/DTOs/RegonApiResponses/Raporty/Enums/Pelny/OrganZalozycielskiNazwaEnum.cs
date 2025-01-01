using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum OrganZalozycielskiNazwaEnum
    {
        [XmlEnum("praw_organZalozycielski_Nazwa")]
        praw_organZalozycielski_Nazwa,
        [XmlEnum("lokpraw_organZalozycielski_Nazwa")]
        lokpraw_organZalozycielski_Nazwa,
    }
}
