using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum RodzajRejestruNazwaEnum
    {
        [XmlEnum("fizC_RodzajRejestru_Nazwa")]
        fizC_RodzajRejestru_Nazwa,
        [XmlEnum("fizP_RodzajRejestru_Nazwa")]
        fizP_RodzajRejestru_Nazwa,
        [XmlEnum("lokpraw_rodzajRejestruEwidencji_Nazwa")]
        lokpraw_rodzajRejestruEwidencji_Nazwa,
        [XmlEnum("praw_rodzajRejestruEwidencji_Nazwa")]
        praw_rodzajRejestruEwidencji_Nazwa,
        [XmlEnum("lokfiz_rodzajRejestru_Nazwa")]
        lokfiz_rodzajRejestru_Nazwa,
    }
}
