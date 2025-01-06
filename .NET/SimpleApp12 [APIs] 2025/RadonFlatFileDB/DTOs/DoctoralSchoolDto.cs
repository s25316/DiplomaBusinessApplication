using RadonFlatFileDB.DTOs.Interfaces;

namespace RadonFlatFileDB.DTOs
{
    public class DoctoralSchoolDto : IFactory<DoctoralSchoolDto>
    {
        //Static Properties
        private static readonly int _Lp = 0;
        private static readonly int _Id = 1;
        private static readonly int _NazwaSzkolyDoktorskiej = 2;
        private static readonly int _DataUtworzenia = 3;
        private static readonly int _DyscyplinyKształcenia = 4;
        private static readonly int _PodmiotProwadzącyNazwa = 5;
        private static readonly int _PodmiotProwadzącyId = 6;
        private static readonly int _PodmiotyWspółprowadzące = 7;
        private static readonly int _DataZaprzestaniaKształcenia = 8;
        private static readonly int _Status = 9;
        private static readonly int _ProgramId = 10;
        private static readonly int _ProgramNazwaProgramuKształcenia = 11;
        private static readonly int _ProgramZakresProgramuKształcenia = 12;
        private static readonly int _ProgramDataRozpoczęciaKształcenia = 13;
        private static readonly int _ProgramLiczbaSemestrów = 14;
        private static readonly int _ProgramKlasyfikacjaISCED = 15;
        private static readonly int _ProgramDyscypliny = 16;
        private static readonly int _ProgramPodmiotyWspółpracujące = 17;
        private static readonly int _ProgramDataZakończeniaKształcenia = 18;
        private static readonly int _AdresUlica = 19;
        private static readonly int _AdresNumerBudynku = 20;
        private static readonly int _AdresNumerLokalu = 21;
        private static readonly int _AdresKodPocztowy = 22;
        private static readonly int _AdresMiasto = 23;
        private static readonly int _StronaWWW = 24;
        private static readonly int _AdresEmail = 25;
        //Properties
        public Guid Id { get; init; }
        public Guid PodmiotProwadzącyId { get; init; }


        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Public Methods
        public DoctoralSchoolDto Create(string[] args)
        {
            return (DoctoralSchoolDto)args;
        }

        public static implicit operator DoctoralSchoolDto(string[] table)
        {
            return new DoctoralSchoolDto
            {
                Id = Guid.Parse(table[_Id]),
                PodmiotProwadzącyId = Guid.Parse(table[_PodmiotProwadzącyId]),
            };
        }
        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Public Methods
    }
}
