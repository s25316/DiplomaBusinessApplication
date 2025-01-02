using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum OrganZalozycielskiSymbolEnum
    {
        [XmlEnum("praw_organZalozycielski_Symbol")]
        praw_organZalozycielski_Symbol,
        [XmlEnum("lokpraw_organZalozycielski_Symbol")]
        lokpraw_organZalozycielski_Symbol,
    }
}
