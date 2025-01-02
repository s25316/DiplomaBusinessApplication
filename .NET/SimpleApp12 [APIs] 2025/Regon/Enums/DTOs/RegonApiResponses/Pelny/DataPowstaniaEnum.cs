using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum DataPowstaniaEnum
    {
        [XmlEnum("fiz_dataPowstania")]
        fiz_dataPowstania,
        [XmlEnum("lokpraw_dataPowstania")]
        lokpraw_dataPowstania,
        [XmlEnum("praw_dataPowstania")]
        praw_dataPowstania,
        [XmlEnum("lokfiz_dataPowstania")]
        lokfiz_dataPowstania,
    }
}
