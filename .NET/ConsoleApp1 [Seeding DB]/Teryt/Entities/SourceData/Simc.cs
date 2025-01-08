using System.Reflection;
using Teryt.CustomExeptions;
using Teryt.Factories;
using Teryt.ValueObjects;

namespace Teryt.Entities.SourceData
{
    /// <summary>
    /// Address do Danych żrodłowych > SIMC
    /// https://eteryt.stat.gov.pl/eTeryt/rejestr_teryt/ogolna_charakterystyka_systemow_rejestru/ogolna_charakterystyka_systemow_rejestru.aspx?contrast=default
    /// </summary>
    public class Simc
    {
        //Positions
        private static readonly int _positionWoj = 0;
        private static readonly int _positionPow = 1;
        private static readonly int _positionGmi = 2;
        private static readonly int _positionRodzGmi = 3;
        private static readonly int _positionRm = 4;
        private static readonly int _positionMz = 5;
        private static readonly int _positionNazwa = 6;
        private static readonly int _positionSym = 7;
        private static readonly int _positionSymPod = 8;
        private static readonly int _positionStanNa = 9;

        //Values
        public long Woj { get; private set; } = -1;
        public long Pow { get; private set; } = -1;
        public long Gmi { get; private set; } = -1;
        public AdministrativeType RodzGmi { get; private set; }
        public AdministrativeType Rm { get; private set; }
        public long Mz { get; private set; } = -1;   //występowanie nazwy zwyczajowej (0-tak,1-nie)
        public string Nazwa { get; private set; } = null!;
        public long Sym { get; private set; } = -1;
        public long? SymPod { get; private set; } = null;

        //Consructor
        public Simc(long woj, long pow, long gmi, long rodzGmi, long rm, long mz, string nazwa, long sym, long symPod)
        {
            Woj = woj;
            Pow = pow;
            Gmi = gmi;
            RodzGmi = AdministrativeType.GetByRodzGminy(rodzGmi);
            Rm = AdministrativeType.GetBySimcRm(rm);
            Mz = mz;
            Nazwa = nazwa;
            Sym = sym;
            SymPod = (symPod == sym) ? null : symPod;
        }

        //Methods
        public static implicit operator Simc(string data)
        {
            var array = data.Split(';');
            if (array.Count() != (_positionStanNa + 1))
            {
                throw new TerytExeption(MessagesFactory.GenerateExeptionMessage
                    (
                    $"Structure of File Changed, Expected Count: {(_positionStanNa + 1)}, Result Count: {array.Count()}",
                    typeof(Simc),
                    MethodBase.GetCurrentMethod(),
                    data));
            }
            return new Simc
                (
                long.Parse(array[_positionWoj]),
                long.Parse(array[_positionPow]),
                long.Parse(array[_positionGmi]),
                long.Parse(array[_positionRodzGmi]),
                long.Parse(array[_positionRm]),
                long.Parse(array[_positionMz]),
                array[_positionNazwa],
                long.Parse(array[_positionSym]),
                long.Parse(array[_positionSymPod])
                );
        }

        public override string ToString()
        {
            return string.Format
                (
                "W: {0}; P: {1}; G: {2}; RG: {3}; RM: {4}; MZ: {5}; NAZWA: {6}; Id {7}; ParentID {8}",
                   Woj,
                        Pow,
                        Gmi,
                        RodzGmi,
                        Rm,
                        Mz,
                        Nazwa,
                        Sym,
                        SymPod
                );
        }
    }
}
