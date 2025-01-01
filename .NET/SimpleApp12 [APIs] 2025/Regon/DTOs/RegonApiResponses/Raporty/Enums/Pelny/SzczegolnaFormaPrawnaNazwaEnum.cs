using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum SzczegolnaFormaPrawnaNazwaEnum
    {
        [XmlEnum("praw_szczegolnaFormaPrawna_Nazwa")]
        praw_szczegolnaFormaPrawna_Nazwa,
        [XmlEnum("lokpraw_szczegolnaFormaPrawna_Nazwa")]
        lokpraw_szczegolnaFormaPrawna_Nazwa,
    }
}
