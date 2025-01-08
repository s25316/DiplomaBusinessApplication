using RadonFlatFileDB.DTOs.Interfaces;

namespace RadonFlatFileDB.DTOs
{
    public class InstitutionDto : IFactory<InstitutionDto>
    {
        //Properties Static
        //For Mapping
        //"Lp";
        private static readonly int _lpIndex = 0;

        //"Id";
        private static readonly int _idIndex = 1;

        //"Nazwa instytucji";
        private static readonly int _institutionNameIndex = 2;

        //"Data utworzenia / data wpisu do ewiencji uczelni niepublicznych";
        private static readonly int _creationDateIndex = 3;

        //"Organ nadzorujący";
        private static readonly int _supervisingBodyIndex = 4;

        //"Rodzaj instytucji";
        private static readonly int _institutionTypeIndex = 5;

        //"Państwowy Instytut Badawczy";
        private static readonly int _stateResearchInstituteIndex = 6;

        //"Rok od kiedy Państwowy Instytut Badawczy";
        private static readonly int _stateResearchInstituteYearIndex = 7;

        //"Data postawienia w stan likwidacji";
        private static readonly int _liquidationStartDateIndex = 8;

        //"Data likwidacji";
        private static readonly int _liquidationDateIndex = 9;

        //private static readonly string _universityType = "Typ uczelni";
        private static readonly int _universityTypeIndex = 10;

        //private static readonly string _scientificInstitutionType = "Typ instytucji naukowej";
        private static readonly int _scientificInstitutionTypeIndex = 11;

        //private static readonly string _regon = "REGON";
        private static readonly int _regonIndex = 12;

        //private static readonly string _nip = "NIP";
        private static readonly int _nipIndex = 13;

        //private static readonly string _krs = "KRS";
        private static readonly int _krsIndex = 14;

        //private static readonly string _ministerialNumber = "Numer uczelni nadany przez ministra";
        private static readonly int _ministerialNumberIndex = 15;

        //private static readonly string _nonPublicEntryNumber = "Numer wpisu do ewidencji uczelni niepublicznych";
        private static readonly int _nonPublicEntryNumberIndex = 16;

        //private static readonly string _panRegistryNumber = "Numer rejestru instytutów PAN";
        private static readonly int _panRegistryNumberIndex = 17;

        //private static readonly string _website = "Strona www";
        private static readonly int _websiteIndex = 18;

        //private static readonly string _email = "Adres e-mail";
        private static readonly int _emailIndex = 19;

        //private static readonly string _phone = "Telefon";
        private static readonly int _phoneIndex = 20;

        //private static readonly string _mailboxAddress = "Adres skrzynki podawczej";
        private static readonly int _mailboxAddressIndex = 21;

        //private static readonly string _country = "Kraj";
        private static readonly int _countryIndex = 22;

        //private static readonly string _voivodeship = "Województwo";
        private static readonly int _voivodeshipIndex = 23;

        //private static readonly string _streetAddress = "Adres - ulica";
        private static readonly int _streetAddressIndex = 24;

        //private static readonly string _addressNumber = "Adres - numer";
        private static readonly int _addressNumberIndex = 25;

        //private static readonly string _postalCode = "Adres - kod pocztowy";
        private static readonly int _postalCodeIndex = 26;

        //private static readonly string _city = "Adres - miasto";
        private static readonly int _cityIndex = 27;

        //private static readonly string _leaderDetails = "Dane osoby kierującej podmiotem";
        private static readonly int _leaderDetailsIndex = 28;

        //private static readonly string _leaderId = "Identyfikator osoby kierującej podmiotem";
        private static readonly int _leaderIdIndex = 29;

        //private static readonly string _federationMemberName = "Skład federacji - Nazwa instytucji";
        private static readonly int _federationMemberNameIndex = 30;

        //private static readonly string _federationMemberId = "Skład federacji - Identyfikator instytucji";
        private static readonly int _federationMemberIdIndex = 31;

        //private static readonly string _federationStartDate = "Skład federacji - W federacji od";
        private static readonly int _federationStartDateIndex = 32;

        //private static readonly string _federationEndDate = "Skład federacji - W federacji do";
        private static readonly int _federationEndDateIndex = 33;

        //private static readonly string _names = "Nazwy - Nazwa";
        private static readonly int _namesIndex = 34;

        //private static readonly string _nameDate = "Nazwy - Data nadania nazwy";
        private static readonly int _nameDateIndex = 35;

        //private static readonly string _precedingInstitutionName = "Instytucje poprzedzające - Nazwa instytucji";
        private static readonly int _precedingInstitutionNameIndex = 36;

        //private static readonly string _precedingInstitutionId = "Instytucje poprzedzające - ID instytucji";
        private static readonly int _precedingInstitutionIdIndex = 37;

        //private static readonly string _precedingInstitutionRegon = "Instytucje poprzedzające - REGON";
        private static readonly int _precedingInstitutionRegonIndex = 38;

        //private static readonly string _precedingInstitutionNip = "Instytucje poprzedzające - NIP";
        private static readonly int _precedingInstitutionNipIndex = 39;

        //private static readonly string _precedingInstitutionKrs = "Instytucje poprzedzające - KRS";
        private static readonly int _precedingInstitutionKrsIndex = 40;

        //private static readonly string _precedingInstitutionPanNumber = "Instytucje poprzedzające - Numer w rejestrze PAN";
        private static readonly int _precedingInstitutionPanNumberIndex = 41;

        //private static readonly string _precedingInstitutionNonPublicEntryNumber = "Instytucje poprzedzające - Numer w ewidencji uczelni niepublicznych";
        private static readonly int _precedingInstitutionNonPublicEntryNumberIndex = 42;

        //private static readonly string _precedingInstitutionSupervisingBody = "Instytucje poprzedzające - Organ nadzorujący";
        private static readonly int _precedingInstitutionSupervisingBodyIndex = 43;

        //private static readonly string _precedingInstitutionTransformationType = "Instytucje poprzedzające - Rodzaj przekształcenia";
        private static readonly int _precedingInstitutionTransformationTypeIndex = 44;

        //private static readonly string _precedingInstitutionTransformationDate = "Instytucje poprzedzające - Data przekształcenia";
        private static readonly int _precedingInstitutionTransformationDateIndex = 45;

        //private static readonly string _succeedingInstitutionName = "Instytucje dziedziczące - Nazwa instytucji";
        private static readonly int _succeedingInstitutionNameIndex = 46;

        //private static readonly string _succeedingInstitutionId = "Instytucje dziedziczące - ID instytucji";
        private static readonly int _succeedingInstitutionIdIndex = 47;

        //private static readonly string _succeedingInstitutionRegon = "Instytucje dziedziczące - REGON";
        private static readonly int _succeedingInstitutionRegonIndex = 48;

        //private static readonly string _succeedingInstitutionNip = "Instytucje dziedziczące - NIP";
        private static readonly int _succeedingInstitutionNipIndex = 49;

        //private static readonly string _succeedingInstitutionKrs = "Instytucje dziedziczące - KRS";
        private static readonly int _succeedingInstitutionKrsIndex = 50;

        //private static readonly string _succeedingInstitutionPanNumber = "Instytucje dziedziczące - Numer w rejestrze PAN";
        private static readonly int _succeedingInstitutionPanNumberIndex = 51;

        //private static readonly string _succeedingInstitutionNonPublicEntryNumber = "Instytucje dziedziczące - Numer w ewidencji uczelni niepublicznych";
        private static readonly int _succeedingInstitutionNonPublicEntryNumberIndex = 52;

        //private static readonly string _succeedingInstitutionSupervisingBody = "Instytucje dziedziczące - Organ nadzorujący";
        private static readonly int _succeedingInstitutionSupervisingBodyIndex = 53;

        //private static readonly string _succeedingInstitutionTransformationType = "Instytucje dziedziczące - Rodzaj przekształcenia";
        private static readonly int _succeedingInstitutionTransformationTypeIndex = 54;

        //private static readonly string _succeedingInstitutionTransformationDate = "Instytucje dziedziczące - Data przekształcenia";
        private static readonly int _succeedingInstitutionTransformationDateIndex = 55;

        //private static readonly string _organChangeHistory = "Historia zmian organu - Organ nadzorujący";
        private static readonly int _organChangeHistoryIndex = 56;

        //private static readonly string _organChangeDate = "Historia zmian organu - Data przypisania do organu";
        private static readonly int _organChangeDateIndex = 57;

        //private static readonly string _statusChangeHistory = "Historia zmian statusu - Status";
        private static readonly int _statusChangeHistoryIndex = 58;

        //private static readonly string _statusChangeDate = "Historia zmian statusu - Data nadania statusu";
        private static readonly int _statusChangeDateIndex = 59;

        //private static readonly string _typeChangeHistory = "Historia zmian typu - Typ";
        private static readonly int _typeChangeHistoryIndex = 60;

        //private static readonly string _typeChangeDate = "Historia zmian typu - Data nadania typu";
        private static readonly int _typeChangeDateIndex = 61;

        //private static readonly string _addressChangeHistory = "Historia zmian adresu - Adres";
        private static readonly int _addressChangeHistoryIndex = 62;

        //private static readonly string _addressChangeDate = "Historia zmian adresu - Data otrzymania adresu";
        private static readonly int _addressChangeDateIndex = 63;

        //====================================================================================================
        //====================================================================================================
        //Properties

        public Guid Id { get; init; }
        public string Name { get; init; } = null!;//2        
        public DateOnly CreationDate { get; init; } //3        
        public string InstitutionType { get; init; } = null!;//5
        public bool IsPan { get; init; }//6 Tak/Nie
        public int? YearFromPan { get; init; } = null;
        public DateOnly? LiquidationStartDate { get; init; } = null;//8;
        public DateOnly? LiquidationDate { get; init; } = null;//9 
        public string? UniversityType { get; init; } = null;// 10; Tylko jeśli InstitutionType contains Uczelnia
        public string? ScientificInstitutionType { get; init; } = null;// 11;
        public string? Regon { get; init; } = null;//12;
        public string? Nip { get; init; } = null;// 13;
        public string? Krs { get; init; } = null;// 14;
        public string? Website { get; init; } = null;//18;
        public string? Email { get; init; } = null;//19;
        public string? Phone { get; init; } = null;// 20;
        public string Country { get; init; } = null!;//22;
        public string Voivodeship { get; init; } = null!;//23;
        public string StreetAddress { get; init; } = null!;// 24;
        public string AddressNumber { get; init; } = null!;// 25;
        public string PostalCode { get; init; } = null!;// 26;
        public string City { get; init; } = null!;// 27;
        public string? Names { get; init; } = null;// 34;
        public DateOnly? NameDate { get; init; } = null;//35;
        public Guid? ParentInstitutionId { get; init; } = null;//37;
        public string? ParentInstitutionTransformationType { get; init; } = null;//44;
        public DateOnly? ParentInstitutionTransformationDate { get; init; } = null;//45;
        public Guid? SucceedingInstitutionId { get; init; } = null;// 47;
        public string? SucceedingInstitutionTransformationType { get; init; } = null;// 54;
        public DateOnly? SucceedingInstitutionTransformationDate { get; init; } = null;// 55;
        public string? StatusChangeHistory { get; init; } = null;//58;
        public DateOnly? StatusChangeDate { get; init; } = null;//59;
        public string? TypeChangeHistory { get; init; } = null;//60;
        public DateOnly? TypeChangeDate { get; init; } = null;//61;
        public string? AddressChangeHistory { get; init; } = null;//62;
        public DateOnly? AddressChangeDate { get; init; } = null;//63;


        //====================================================================================================
        //====================================================================================================
        //====================================================================================================
        //Public Methods
        public static implicit operator InstitutionDto(string[] table)
        {
            return new InstitutionDto
            {
                Id = Guid.Parse(table[_idIndex]),
                Name = table[_namesIndex],//2        
                CreationDate = DateOnly.Parse(table[_creationDateIndex]),//3        
                InstitutionType = table[_institutionTypeIndex],//5
                IsPan = table[_stateResearchInstituteIndex].ToLower() == "tak",//6
                YearFromPan = ParseToInt(table[_stateResearchInstituteYearIndex]),
                LiquidationStartDate = ParseToDateOnly(table[_liquidationStartDateIndex]),//8;
                LiquidationDate = ParseToDateOnly(table[_liquidationDateIndex]),//9 
                UniversityType = table[_universityTypeIndex],// 10;
                ScientificInstitutionType = table[_scientificInstitutionTypeIndex],// 11;
                Regon = table[_regonIndex],// 12;
                Nip = table[_nipIndex],// 13;
                Krs = table[_krsIndex],// 14;
                Website = table[_websiteIndex],//18;
                Email = table[_emailIndex],///19;
                Phone = table[_phoneIndex],// 20;
                Country = table[_countryIndex],//22;
                Voivodeship = table[_voivodeshipIndex], //23;
                StreetAddress = table[_streetAddressIndex],// 24;
                AddressNumber = table[_addressNumberIndex],// 25;
                PostalCode = table[_postalCodeIndex],// 26;
                City = table[_cityIndex],// 27;
                Names = table[_namesIndex],// 34;
                NameDate = ParseToDateOnly(table[_nameDateIndex]),//35;
                ParentInstitutionId = ParseToGuid(table[_precedingInstitutionIdIndex]),//37;
                ParentInstitutionTransformationType = table[_precedingInstitutionTransformationTypeIndex],//44;
                ParentInstitutionTransformationDate = ParseToDateOnly(table[_precedingInstitutionTransformationDateIndex]),//45;
                SucceedingInstitutionId = ParseToGuid(table[_succeedingInstitutionIdIndex]),// 47;
                SucceedingInstitutionTransformationType = table[_succeedingInstitutionTransformationTypeIndex],// 54;
                SucceedingInstitutionTransformationDate = ParseToDateOnly(table[_succeedingInstitutionTransformationDateIndex]),// 55;
                StatusChangeHistory = table[_statusChangeHistoryIndex],//58;
                StatusChangeDate = ParseToDateOnly(table[_statusChangeDateIndex]),//59;
                TypeChangeHistory = table[_typeChangeHistoryIndex],//60;
                TypeChangeDate = ParseToDateOnly(table[_typeChangeDateIndex]),//61;
                AddressChangeHistory = table[_addressChangeHistoryIndex],//62;
                AddressChangeDate = ParseToDateOnly(table[_addressChangeDateIndex]),//63;
            };
        }

        public InstitutionDto Create(string[] args)
        {
            return (InstitutionDto)args;
        }
        //====================================================================================================
        //====================================================================================================
        //====================================================================================================
        //Private Methods
        private static Guid? ParseToGuid(string? value) =>
            string.IsNullOrWhiteSpace(value) ? null : Guid.Parse(value);
        private static int? ParseToInt(string? value) =>
            string.IsNullOrWhiteSpace(value) ? null : int.Parse(value);
        private static string? ParseToString(string? value) =>
            string.IsNullOrWhiteSpace(value) ? null : value;
        private static DateOnly? ParseToDateOnly(string? value) =>
            string.IsNullOrWhiteSpace(value) ? null : DateOnly.FromDateTime(DateTime.Parse(value));

    }

}
