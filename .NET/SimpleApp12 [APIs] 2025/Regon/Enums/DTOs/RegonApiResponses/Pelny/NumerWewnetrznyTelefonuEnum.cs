using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum NumerWewnetrznyTelefonuEnum
    {
        [XmlEnum("fiz_numerWewnetrznyTelefonu")]
        fiz_numerWewnetrznyTelefonu,
        [XmlEnum("praw_numerWewnetrznyTelefonu")]
        praw_numerWewnetrznyTelefonu,
        [XmlEnum("fizC_numerWewnetrznyTelefonu")]
        fizC_numerWewnetrznyTelefonu,
    }
}
