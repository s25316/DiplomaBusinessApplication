using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Enums.Pelny
{
    public enum NumerTelefonuEnum
    {
        [XmlEnum("fiz_numerTelefonu")]
        fiz_numerTelefonu,
        [XmlEnum("praw_numerTelefonu")]
        praw_numerTelefonu,
    }
}
