using System.Data;
using System.Reflection;
using Teryt.CustomExeptions;
using Teryt.Factories;

namespace Teryt.ValueObjects
{
    /// <summary>
    /// Dane żrodłowe 
    /// https://eteryt.stat.gov.pl/eTeryt/rejestr_teryt/ogolna_charakterystyka_systemow_rejestru/ogolna_charakterystyka_systemow_rejestru.aspx?contrast=default
    /// </summary>
    public record AdministrativeType
    {
        public static int StartValue = 1;
        public static int StartValueDepth = 1;
        //====================================================================================
        private static Dictionary<long, AdministrativeType> _dictionary = new();

        //Names
        private static readonly string _nameWoj = "województwo";

        private static readonly string _namePow = "powiat";
        private static readonly string _nameMiaPow = "miasto na prawach powiatu";

        private static readonly string _nameGmiMie = "gmina miejska";
        private static readonly string _nameGmiWie = "gmina wiejska";
        private static readonly string _nameGmiMieWie = "gmina miejsko-wiejska";
        private static readonly string _nameObszarWie = "obszar wiejski";
        private static readonly string _nameDzielnica = "dzielnica";
        private static readonly string _nameDelegatura = "delegatura";
        private static readonly string _nameMiasto = "miasto";

        private static readonly string _nameCzescMiasta = "część miasta";
        private static readonly string _nameSchronisko = "schronisko turystyczne";
        private static readonly string _nameOsiedle = "osiedle";
        private static readonly string _nameOsadaLesna = "osada leśna";
        private static readonly string _nameOsada = "osada";
        private static readonly string _namePrzysiowek = "przysiółek";
        private static readonly string _nameKolonia = "kolonia";
        private static readonly string _nameWies = "wieś";
        private static readonly string _nameCzescMiej = "część miejscowości";
        //====================================================================================
        //Values
        public long Id { get; private set; } = -1;
        public string Name { get; private set; } = null!;
        public long Depth { get; private set; } = -1;

        //Constructors
        private AdministrativeType(string name, long depth)
        {
            Id = StartValue;
            Name = name;
            Depth = depth;
            StartValue++;
            _dictionary.Add(Id, this);
        }

        private AdministrativeType()
        {
            /*Depth
            *//*0*//*    "województwo",
            *//*1*//*    "powiat", "miasto na prawach powiatu",
            *//*2*//*    "gmina miejska", "gmina wiejska", "gmina miejsko-wiejska","obszar wiejski", "dzielnica", "delegatura","miasto",
            *//*3*//*    "część miasta", "schronisko turystyczne", "osiedle", "osada leśna", "osada", "przysiółek", "kolonia", "wieś", "część miejscowości",
            *//*4*//*    "ul.", "pl.", "rondo","os.", "skwer", "al.", "park", "droga","rynek","bulw.", "wyspa",  "wyb.","ogród"
            */
            //From Documentation on WWW
            new AdministrativeType(_nameWoj, 0 + StartValueDepth);

            new AdministrativeType(_namePow, 1 + StartValueDepth);
            new AdministrativeType(_nameMiaPow, 1 + StartValueDepth);

            new AdministrativeType(_nameGmiMie, 2 + StartValueDepth);
            new AdministrativeType(_nameGmiWie, 2 + StartValueDepth);
            new AdministrativeType(_nameGmiMieWie, 2 + StartValueDepth);
            new AdministrativeType(_nameObszarWie, 2 + StartValueDepth);
            new AdministrativeType(_nameDzielnica, 2 + StartValueDepth);
            new AdministrativeType(_nameDelegatura, 2 + StartValueDepth);
            new AdministrativeType(_nameMiasto, 2 + StartValueDepth);

            new AdministrativeType(_nameMiasto, 3 + StartValueDepth);
            new AdministrativeType(_nameCzescMiasta, 3 + StartValueDepth);
            new AdministrativeType(_nameSchronisko, 3 + StartValueDepth);
            new AdministrativeType(_nameOsiedle, 3 + StartValueDepth);
            new AdministrativeType(_nameOsadaLesna, 3 + StartValueDepth);
            new AdministrativeType(_nameOsada, 3 + StartValueDepth);
            new AdministrativeType(_namePrzysiowek, 3 + StartValueDepth);
            new AdministrativeType(_nameKolonia, 3 + StartValueDepth);
            new AdministrativeType(_nameWies, 3 + StartValueDepth);
            new AdministrativeType(_nameCzescMiej, 3 + StartValueDepth);
            new AdministrativeType(_nameDzielnica, 3 + StartValueDepth);
            new AdministrativeType(_nameDelegatura, 3 + StartValueDepth);
        }

        //Methods
        public static Dictionary<long, AdministrativeType> GetAllTypes() => _dictionary;

        public static AdministrativeType GetByRodzGminy(long rodz)
        {
            FillEmptyDictionary();

            var dictionary = new Dictionary<long, string>();
            dictionary.Add(1, _nameGmiMie);
            dictionary.Add(2, _nameGmiWie);
            dictionary.Add(3, _nameGmiMieWie);
            dictionary.Add(5, _nameObszarWie);
            dictionary.Add(4, _nameMiasto);
            dictionary.Add(8, _nameDzielnica);
            dictionary.Add(9, _nameDelegatura);

            if (dictionary.TryGetValue(rodz, out var name))
            {
                var result = _dictionary.Where(x => x.Value.Name == name && x.Value.Depth == (2 + StartValueDepth)).Select(x => x.Value).FirstOrDefault();
                if (result == null)
                {
                    throw new TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Undefined value in Class dictionary",
                    typeof(AdministrativeType),
                    MethodBase.GetCurrentMethod(),
                    name
                    ));
                }
                return result;
            }
            else
            {
                throw new Teryt.CustomExeptions.TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Undefined value in dictionary of Method",
                    typeof(AdministrativeType),
                    MethodBase.GetCurrentMethod(),
                    rodz.ToString()
                    ));
            }
        }

        public static AdministrativeType GetBySimcRm(long rm)
        {
            FillEmptyDictionary();

            var dictionary = new Dictionary<long, string>();
            dictionary.Add(0, _nameCzescMiej);
            dictionary.Add(1, _nameWies);
            dictionary.Add(2, _nameKolonia);
            dictionary.Add(3, _namePrzysiowek);
            dictionary.Add(4, _nameOsada);
            dictionary.Add(5, _nameOsadaLesna);
            dictionary.Add(6, _nameOsiedle);
            dictionary.Add(7, _nameSchronisko);
            dictionary.Add(95, _nameDzielnica);
            dictionary.Add(96, _nameMiasto);
            dictionary.Add(98, _nameDelegatura);
            dictionary.Add(99, _nameCzescMiasta);

            if (dictionary.TryGetValue(rm, out var name))
            {
                var result = _dictionary.Where(x => x.Value.Name == name && x.Value.Depth == (3 + StartValueDepth)).Select(x => x.Value).FirstOrDefault();
                if (result == null)
                {
                    throw new Teryt.CustomExeptions.TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Undefined value in Class dictionary",
                    typeof(AdministrativeType),
                    MethodBase.GetCurrentMethod(),
                    name
                    ));
                }
                return result;
            }
            else
            {
                throw new Teryt.CustomExeptions.TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Undefined value in dictionary of Method",
                    typeof(AdministrativeType),
                    MethodBase.GetCurrentMethod(),
                    rm.ToString()
                    ));
            }
        }

        public static AdministrativeType GetByTercAttributes(long? pow, long? gmi, long? rodz, string nazwaDod)
        {

            if (rodz != null && gmi != null && pow != null)
            {
                return GetByRodzGminy(rodz.Value);
            }
            else if (rodz == null && gmi == null && pow != null)
            {
                return GetByTercPow(pow.Value);
                //Wyjatek Expected "miasto stołeczne, na prawach powiatu", Result: "miasto na prawach powiatu"
            }
            else if (rodz == null && gmi == null && pow == null)
            {
                return GetByTercWoj();
            }
            else
            {
                throw new TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Not implemented varian of class for this Data",
                    typeof(AdministrativeType),
                    MethodBase.GetCurrentMethod(),
                    $"Pow: {pow}, Gmi: {gmi}, Rodz; {rodz}, NazwaDod: {nazwaDod}"
                    ));
            }
        }

        public static AdministrativeType GetByUlicCecha(string type)
        {
            FillEmptyDictionary();

            var value = _dictionary.Where(x => x.Value.Name == type && x.Value.Depth == (4 + StartValueDepth)).Select(x => x.Value).FirstOrDefault();
            if (value == null)
            {
                value = new AdministrativeType(type, (4 + StartValueDepth));
            }
            return value;
        }

        public override string ToString()
        {
            return $"{Name}:{Depth};";
        }
        //=======================================================================================================================================================
        //=======================================================================================================================================================
        //Private methods
        //=======================================================================================================================================================
        /// <summary>
        /// If Dictionary is empty GenerateExeptionMessage Contructor and Fill Values
        /// </summary>
        public static void FillEmptyDictionary()
        {
            if (_dictionary.Count() == 0)
            {
                new AdministrativeType();
            }
        }
        private static AdministrativeType GetByTercWoj()
        {
            FillEmptyDictionary();

            var result = _dictionary.Where(x => x.Value.Name == _nameWoj && x.Value.Depth == (0 + StartValueDepth)).Select(x => x.Value).FirstOrDefault();
            if (result == null)
            {
                throw new TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Undefined value in Class dictionary",
                    typeof(AdministrativeType),
                    MethodBase.GetCurrentMethod(),
                    _nameWoj
                    ));
            }
            return result;
        }
        private static AdministrativeType GetByTercPow(long pow)
        {
            FillEmptyDictionary();

            var name = _nameMiaPow;
            if (pow <= 60 && pow >= 1)
            {
                name = _namePow;
            }
            var result = _dictionary.Where(x => x.Value.Name == name && x.Value.Depth == (1 + StartValueDepth)).Select(x => x.Value).FirstOrDefault();
            if (result == null)
            {
                throw new TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Undefined value in Class dictionary",
                    typeof(AdministrativeType),
                    MethodBase.GetCurrentMethod(),
                    name
                    ));
            }
            return result;
        }

    }
}
