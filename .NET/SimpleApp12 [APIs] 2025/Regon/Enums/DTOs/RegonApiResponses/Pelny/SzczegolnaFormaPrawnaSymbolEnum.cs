using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum SzczegolnaFormaPrawnaSymbolEnum
    {
        [XmlEnum("praw_szczegolnaFormaPrawna_Symbol")]
        praw_szczegolnaFormaPrawna_Symbol,
        [XmlEnum("lokpraw_szczegolnaFormaPrawna_Symbol")]
        lokpraw_szczegolnaFormaPrawna_Symbol,
    }
}
