using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum NumerWewnetrznyTelefonuEnum
    {
        [XmlEnum("fiz_numerWewnetrznyTelefonu")]
        fiz_numerWewnetrznyTelefonu,
        [XmlEnum("praw_numerWewnetrznyTelefonu")]
        praw_numerWewnetrznyTelefonu,
    }
}
