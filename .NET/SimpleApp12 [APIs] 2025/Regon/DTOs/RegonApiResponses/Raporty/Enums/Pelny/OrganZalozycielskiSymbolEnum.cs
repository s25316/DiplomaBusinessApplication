using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum OrganZalozycielskiSymbolEnum
    {
        [XmlEnum("praw_organZalozycielski_Symbol")]
        praw_organZalozycielski_Symbol,
        [XmlEnum("lokpraw_organZalozycielski_Symbol")]
        lokpraw_organZalozycielski_Symbol,
    }
}
