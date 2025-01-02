using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum OrganRejestrowySymbolEnum
    {
        [XmlEnum("fizC_OrganRejestrowy_Symbol")]
        fizC_OrganRejestrowy_Symbol,
        [XmlEnum("fizP_OrganRejestrowy_Symbol")]
        fizP_OrganRejestrowy_Symbol,
        [XmlEnum("lokpraw_organRejestrowy_Symbol")]
        lokpraw_organRejestrowy_Symbol,
        [XmlEnum("praw_organRejestrowy_Symbol")]
        praw_organRejestrowy_Symbol,
        [XmlEnum("lokfiz_organRejestrowy_Symbol")]
        lokfiz_organRejestrowy_Symbol,
    }
}
