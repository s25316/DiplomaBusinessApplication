using System.Reflection;
using Teryt.CustomExeptions;
using Teryt.Factories;
using Teryt.ValueObjects;

namespace Teryt.Entities.SourceData
{
    public class Ulic
    {
        //Postions
        private static readonly int _positionWoj = 0;
        private static readonly int _positionPow = 1;
        private static readonly int _positionGmi = 2;
        private static readonly int _positionRodzGmi = 3;
        private static readonly int _positionSym = 4;
        private static readonly int _positionSymUl = 5;
        private static readonly int _positionCecha = 6;
        private static readonly int _positionNazwa1 = 7;
        private static readonly int _positionNazwa2 = 8;
        private static readonly int _positionStanNa = 9;
        //Values
        public long Woj { get; private set; } = -1;
        public long Pow { get; private set; } = -1;
        public long Gmi { get; private set; } = -1;
        public long RodzGmi { get; private set; } = -1;
        public long Sym { get; private set; } = -1;
        public long SymUl { get; private set; } = -1;
        public AdministrativeType? Cecha { get; private set; } = null;
        public string Nazwa1 { get; private set; } = null!;
        public string? Nazwa2 { get; private set; } = null;

        //Constructor
        public Ulic(long woj, long pow, long gmi, long rodzGmi, long sym, long symUl, string? cecha, string nazwa1, string? nazwa2)
        {
            Woj = woj;
            Pow = pow;
            Gmi = gmi;
            RodzGmi = rodzGmi;
            Sym = sym;
            SymUl = symUl;
            Cecha = string.IsNullOrWhiteSpace(cecha) ? null : AdministrativeType.GetByUlicCecha(cecha);
            Nazwa1 = nazwa1;
            Nazwa2 = nazwa2;
        }

        //Methods
        public static implicit operator Ulic(string data)
        {
            var array = data.Split(';');
            if (array.Count() != (_positionStanNa + 1))
            {
                throw new TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Structure of File Changed, Expected Count:  {(_positionStanNa + 1)}, Result Count: {array.Count()}",
                    typeof(Simc),
                    MethodBase.GetCurrentMethod(),
                    data));
            }
            return new Ulic
                (
                    long.Parse(array[_positionWoj]),
                    long.Parse(array[_positionPow]),
                    long.Parse(array[_positionGmi]),
                    long.Parse(array[_positionRodzGmi]),
                    long.Parse(array[_positionSym]),
                    long.Parse(array[_positionSymUl]),
                    string.IsNullOrWhiteSpace(array[_positionCecha]) ? null : array[_positionCecha],
                    array[_positionNazwa1],
                    string.IsNullOrWhiteSpace(array[_positionNazwa2]) ? null : array[_positionNazwa2]
                );
        }

        public override string ToString()
        {
            return String.Format
                ("{0}; {1}; {2}; {3}; {4}; {5}; {6}; {7}; {8};",
                   Woj,
                        Pow,
                        Gmi,
                        RodzGmi,
                        Sym,
                        SymUl,
                        Cecha,
                        Nazwa1,
                        Nazwa2
                );
        }
    }
}
