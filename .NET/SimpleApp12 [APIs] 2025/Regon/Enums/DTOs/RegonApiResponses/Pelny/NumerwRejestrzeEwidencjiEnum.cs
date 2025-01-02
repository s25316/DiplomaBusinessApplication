using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum NumerwRejestrzeEwidencjiEnum
    {
        [XmlEnum("fizC_numerwRejestrzeEwidencji")]
        fizC_numerwRejestrzeEwidencji,
        [XmlEnum("fizP_numerwRejestrzeEwidencji")]
        fizP_numerwRejestrzeEwidencji,
        [XmlEnum("lokpraw_numerWrejestrzeEwidencji")]
        lokpraw_numerWrejestrzeEwidencji,
        [XmlEnum("praw_numerWrejestrzeEwidencji")]
        praw_numerWrejestrzeEwidencji,
        [XmlEnum("lokfiz_numerwRejestrzeEwidencji")]
        lokfiz_numerwRejestrzeEwidencji,
    }
}
