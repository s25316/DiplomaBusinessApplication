using RadonFlatFileDB.DTOs.Interfaces;

namespace RadonFlatFileDB.DTOs
{
    public record KsztalcenieSpecjalistyczneDto : IFactory<KsztalcenieSpecjalistyczneDto>
    {
        //Static Properties
        private static readonly int _Lp = 0;
        private static readonly int _IdentyfikatorKsztalceniaSpecjalistycznego = 1;
        private static readonly int _NazwaKsztalceniaSpecjalistycznego = 2;
        private static readonly int _KodSwiadectwa = 3;
        private static readonly int _NazwaSwiadectwa = 4;
        private static readonly int _SemestrRozpoczecia = 5;
        private static readonly int _IdentyfikatorUczelniZawodowej = 6;
        private static readonly int _NazwaUczelniZawodowej = 7;
        private static readonly int _InformacjaOŹródleDanych = 8;
        //Properties

        public Guid Id { get; init; }
        public string Nazwa { get; init; } = null!;
        public string NazwaSwiadectwa { get; init; } = null!;
        public DateOnly StartDate { get; init; }
        public Guid IdentyfikatorUczelniZawodowej { get; init; }


        //================================================================================================
        //================================================================================================
        //================================================================================================
        //Public Methods
        public KsztalcenieSpecjalistyczneDto Create(string[] args)
        {
            return (KsztalcenieSpecjalistyczneDto)args;
        }

        public static implicit operator KsztalcenieSpecjalistyczneDto(string[] table)
        {
            var x = table[_SemestrRozpoczecia].Split(" ");//zimowy 2023/2024
            var isFirstSemester = x[0].ToLower() == "zimowy";
            x = x[1].Split("/");
            var year = int.Parse(isFirstSemester ? x[0] : x[1]);
            var startDate = isFirstSemester ?
                new DateOnly(year, 10, 1) :
                new DateOnly(year, 02, 15);

            return new KsztalcenieSpecjalistyczneDto
            {
                Id = Guid.Parse(table[_IdentyfikatorKsztalceniaSpecjalistycznego]),
                Nazwa = table[_NazwaKsztalceniaSpecjalistycznego],
                NazwaSwiadectwa = table[_NazwaSwiadectwa],
                StartDate = startDate,
                IdentyfikatorUczelniZawodowej = Guid.Parse(table[_IdentyfikatorUczelniZawodowej]),
            };
        }
        //================================================================================================
        //================================================================================================
        //================================================================================================
        //Private Methods
    }
}
