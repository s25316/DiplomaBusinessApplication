using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum OrganRejestrowyNazwaEnum
    {
        [XmlEnum("fizC_OrganRejestrowy_Nazwa")]
        fizC_OrganRejestrowy_Nazwa,
        [XmlEnum("fizP_OrganRejestrowy_Nazwa")]
        fizP_OrganRejestrowy_Nazwa,
        [XmlEnum("lokpraw_organRejestrowy_Nazwa")]
        lokpraw_organRejestrowy_Nazwa,
        [XmlEnum("praw_organRejestrowy_Nazwa")]
        praw_organRejestrowy_Nazwa,
        [XmlEnum("lokfiz_organRejestrowy_Nazwa")]
        lokfiz_organRejestrowy_Nazwa,
    }
}
