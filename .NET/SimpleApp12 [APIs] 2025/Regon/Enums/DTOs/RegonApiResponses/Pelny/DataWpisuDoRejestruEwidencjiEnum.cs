﻿using System.Xml.Serialization;

namespace Regon.Enums.DTOs.RegonApiResponses.Pelny
{
    public enum DataWpisuDoRejestruEwidencjiEnum
    {
        [XmlEnum("fizC_dataWpisuDoRejestruEwidencji")]
        fizC_dataWpisuDoRejestruEwidencji,
        [XmlEnum("fizP_dataWpisuDoRejestruEwidencji")]
        fizP_dataWpisuDoRejestruEwidencji,
        [XmlEnum("lokpraw_dataWpisuDoRejestruEwidencji")]
        lokpraw_dataWpisuDoRejestruEwidencji,
        [XmlEnum("lokfiz_dataWpisuDoRejestruEwidencji")]
        lokfiz_dataWpisuDoRejestruEwidencji,
    }
}
