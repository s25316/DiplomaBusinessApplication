using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum NumerTelefonuEnum
    {
        [XmlEnum("fiz_numerTelefonu")]
        fiz_numerTelefonu,
        [XmlEnum("praw_numerTelefonu")]
        praw_numerTelefonu,
        [XmlEnum("fizC_numerTelefonu")]
        fizC_numerTelefonu,
    }
}
