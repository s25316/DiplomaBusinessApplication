using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum SzczegolnaFormaPrawnaNazwaEnum
    {
        [XmlEnum("praw_szczegolnaFormaPrawna_Nazwa")]
        praw_szczegolnaFormaPrawna_Nazwa,
        [XmlEnum("lokpraw_szczegolnaFormaPrawna_Nazwa")]
        lokpraw_szczegolnaFormaPrawna_Nazwa,
    }
}
