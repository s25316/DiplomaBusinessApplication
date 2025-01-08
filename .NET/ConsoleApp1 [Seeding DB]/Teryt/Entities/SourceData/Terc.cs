using System.Reflection;
using Teryt.CustomExeptions;
using Teryt.Entities.CustomData;
using Teryt.Factories;
using Teryt.ValueObjects;

namespace Teryt.Entities.SourceData
{
    public class Terc
    {
        //Positions
        private static readonly int _positionWoj = 0;
        private static readonly int _positionPow = 1;
        private static readonly int _positionGmi = 2;
        private static readonly int _positionRodz = 3;
        private static readonly int _positionNazwa = 4;
        private static readonly int _positionNazwaDod = 5;
        private static readonly int _positionStanNa = 6;

        //Values
        public long Woj { get; private set; }
        public long? Pow { get; private set; } = null;
        public long? Gmi { get; private set; } = null;
        public AdministrativeType Rodz { get; private set; }
        public string Nazwa { get; private set; } = null!;
        public string NazwaDod { get; private set; } = null!;
        public Division? Division { get; private set; } = null;
        //Constructor
        public Terc(long woj, long? pow, long? gmi, long? rodz, string nazwa, string nazwaDod)
        {
            Woj = woj;
            Pow = pow;
            Gmi = gmi;
            Nazwa = nazwa;
            NazwaDod = nazwaDod;
            Rodz = AdministrativeType.GetByTercAttributes(pow, gmi, rodz, nazwaDod);
        }

        //Methods
        public static implicit operator Terc(string data)
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
            return new Terc
                (
                long.Parse(array[_positionWoj]),
                (string.IsNullOrWhiteSpace(array[_positionPow])) ? null : long.Parse(array[_positionPow]),
                (string.IsNullOrWhiteSpace(array[_positionGmi])) ? null : long.Parse(array[_positionGmi]),
                (string.IsNullOrWhiteSpace(array[_positionRodz])) ? null : long.Parse(array[_positionRodz]),
                array[_positionNazwa],
                array[_positionNazwaDod]
                );
        }

        public override string ToString()
        {
            return string.Format
                (
                    "W: {0}; P: {1}; G: {2}; RG: {3}; Nazwa {4};",
                       Woj,
                            Pow,
                            Gmi,
                            Rodz,
                            Nazwa
                );
        }
    }
}
