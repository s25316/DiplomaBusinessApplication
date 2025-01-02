using Regon.Enums.DTOs.RegonApiResponses.Pelny;
using System.Xml.Serialization;

namespace Regon.DTOs.RegonApiResponses.Raporty.Pelny
{
    public class ReportFull
    {
        [XmlChoiceIdentifier("RegonEnum")]
        [XmlElement(ElementName = "fiz_regon9")]
        [XmlElement(ElementName = "lokpraw_regon14")]
        [XmlElement(ElementName = "praw_regon14")]
        [XmlElement(ElementName = "lokfiz_regon14")]
        public string Regon { get; init; } = null!;
        public RegonEnum RegonEnum { get; init; }


        [XmlChoiceIdentifier("NazwaEnum")]
        [XmlElement(ElementName = "fiz_nazwa")]
        [XmlElement(ElementName = "lokpraw_nazwa")]
        [XmlElement(ElementName = "praw_nazwa")]
        [XmlElement(ElementName = "lokfiz_nazwa")]
        public string Nazwa { get; init; } = null!;
        public NazwaEnum NazwaEnum { get; init; }


        [XmlChoiceIdentifier("NipEnum")]
        [XmlElement(ElementName = "lokpraw_nip", IsNullable = true)]
        [XmlElement(ElementName = "praw_nip", IsNullable = true)]
        public string? Nip { get; init; } = null;
        public NipEnum NipEnum { get; init; }


        [XmlChoiceIdentifier("NazwaSkroconaEnum")]
        [XmlElement(ElementName = "fiz_nazwaSkrocona", IsNullable = true)]
        [XmlElement(ElementName = "praw_nazwaSkrocona", IsNullable = true)]
        public string? NazwaSkrocona { get; init; } = null;
        public NazwaSkroconaEnum NazwaSkroconaEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzKrajSymbolEnum")]
        [XmlElement(ElementName = "fiz_adSiedzKraj_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzKraj_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzKraj_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzKraj_Symbol", IsNullable = true)]
        public string? AdSiedzKrajSymbol { get; init; } = null;
        public AdSiedzKrajSymbolEnum AdSiedzKrajSymbolEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzWojewodztwoSymbolEnum")]
        [XmlElement(ElementName = "fiz_adSiedzWojewodztwo_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzWojewodztwo_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzWojewodztwo_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzWojewodztwo_Symbol", IsNullable = true)]
        public string? AdSiedzWojewodztwoSymbol { get; init; } = null;
        public AdSiedzWojewodztwoSymbolEnum AdSiedzWojewodztwoSymbolEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzPowiatSymbolEnum")]
        [XmlElement(ElementName = "fiz_adSiedzPowiat_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzPowiat_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzPowiat_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzPowiat_Symbol", IsNullable = true)]
        public string? AdSiedzPowiatSymbol { get; init; } = null;
        public AdSiedzPowiatSymbolEnum AdSiedzPowiatSymbolEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzGminaSymbolEnum")]
        [XmlElement(ElementName = "fiz_adSiedzGmina_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzGmina_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzGmina_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzGmina_Symbol", IsNullable = true)]
        public string? AdSiedzGminaSymbol { get; init; } = null;
        public AdSiedzGminaSymbolEnum AdSiedzGminaSymbolEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzKodPocztowyEnum")]
        [XmlElement(ElementName = "fiz_adSiedzKodPocztowy", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzKodPocztowy", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzKodPocztowy", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzKodPocztowy", IsNullable = true)]
        public string? AdSiedzKodPocztowy { get; init; } = null;
        public AdSiedzKodPocztowyEnum AdSiedzKodPocztowyEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzMiejscowoscPocztySymbolEnum")]
        [XmlElement(ElementName = "fiz_adSiedzMiejscowoscPoczty_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzMiejscowoscPoczty_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzMiejscowoscPoczty_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzMiejscowoscPoczty_Symbol", IsNullable = true)]
        public string? AdSiedzMiejscowoscPocztySymbol { get; init; } = null;
        public AdSiedzMiejscowoscPocztySymbolEnum AdSiedzMiejscowoscPocztySymbolEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzMiejscowoscSymbolEnum")]
        [XmlElement(ElementName = "fiz_adSiedzMiejscowosc_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzMiejscowosc_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzMiejscowosc_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzMiejscowosc_Symbol", IsNullable = true)]
        public string? AdSiedzMiejscowoscSymbol { get; init; } = null;
        public AdSiedzMiejscowoscSymbolEnum AdSiedzMiejscowoscSymbolEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzUlicaSymbolEnum")]
        [XmlElement(ElementName = "fiz_adSiedzUlica_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzUlica_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzUlica_Symbol", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzUlica_Symbol", IsNullable = true)]
        public string? AdSiedzUlicaSymbol { get; init; } = null;
        public AdSiedzUlicaSymbolEnum AdSiedzUlicaSymbolEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzNumerNieruchomosciEnum")]
        [XmlElement(ElementName = "fiz_adSiedzNumerNieruchomosci", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzNumerNieruchomosci", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzNumerNieruchomosci", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzNumerNieruchomosci", IsNullable = true)]
        public string? AdSiedzNumerNieruchomosci { get; init; } = null;
        public AdSiedzNumerNieruchomosciEnum AdSiedzNumerNieruchomosciEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedzNumerLokaluEnum")]
        [XmlElement(ElementName = "fiz_adSiedzNumerLokalu", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzNumerLokalu", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzNumerLokalu", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzNumerLokalu", IsNullable = true)]
        public string? AdSiedzNumerLokalu { get; init; } = null;
        public AdSiedzNumerLokaluEnum AdSiedzNumerLokaluEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedNietypoweMiejsceLokalizacjiEnum")]
        [XmlElement(ElementName = "fiz_adSiedzNietypoweMiejsceLokalizacji", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzNietypoweMiejsceLokalizacji", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzNietypoweMiejsceLokalizacji", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzNietypoweMiejsceLokalizacji", IsNullable = true)]
        public string? AdSiedNietypoweMiejsceLokalizacji { get; init; } = null;
        public AdSiedNietypoweMiejsceLokalizacjiEnum AdSiedNietypoweMiejsceLokalizacjiEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedKrajNazwaEnum")]
        [XmlElement(ElementName = "fiz_adSiedzKraj_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzKraj_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzKraj_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzKraj_Nazwa", IsNullable = true)]
        public string? AdSiedKrajNazwa { get; init; } = null;
        public AdSiedKrajNazwaEnum AdSiedKrajNazwaEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedWojewodztwoNazwaEnum")]
        [XmlElement(ElementName = "fiz_adSiedzWojewodztwo_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzWojewodztwo_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzWojewodztwo_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzWojewodztwo_Nazwa", IsNullable = true)]
        public string? AdSiedWojewodztwoNazwa { get; init; } = null;
        public AdSiedWojewodztwoNazwaEnum AdSiedWojewodztwoNazwaEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedPowiatNazwaEnum")]
        [XmlElement(ElementName = "fiz_adSiedzPowiat_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzPowiat_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzPowiat_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzPowiat_Nazwa", IsNullable = true)]
        public string? AdSiedPowiatNazwa { get; init; } = null;
        public AdSiedPowiatNazwaEnum AdSiedPowiatNazwaEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedGminaNazwaEnum")]
        [XmlElement(ElementName = "fiz_adSiedzGmina_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzGmina_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzGmina_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzGmina_Nazwa", IsNullable = true)]
        public string? AdSiedGminaNazwa { get; init; } = null;
        public AdSiedGminaNazwaEnum AdSiedGminaNazwaEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedMiejscowoscPocztyNazwaEnum")]
        [XmlElement(ElementName = "fiz_adSiedzMiejscowoscPoczty_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzMiejscowoscPoczty_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzMiejscowoscPoczty_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzMiejscowoscPoczty_Nazwa", IsNullable = true)]
        public string? AdSiedMiejscowoscPocztyNazwa { get; init; } = null;
        public AdSiedMiejscowoscPocztyNazwaEnum AdSiedMiejscowoscPocztyNazwaEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedMiejscowoscNazwaEnum")]
        [XmlElement(ElementName = "fiz_adSiedzMiejscowosc_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzMiejscowosc_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzMiejscowosc_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzMiejscowosc_Nazwa", IsNullable = true)]
        public string? AdSiedMiejscowoscNazwa { get; init; } = null;
        public AdSiedMiejscowoscNazwaEnum AdSiedMiejscowoscNazwaEnum { get; init; }


        [XmlChoiceIdentifier("AdSiedUlicaNazwaEnum")]
        [XmlElement(ElementName = "fiz_adSiedzUlica_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_adSiedzUlica_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "praw_adSiedzUlica_Nazwa", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_adSiedzUlica_Nazwa", IsNullable = true)]
        public string? AdSiedUlicaNazwa { get; init; } = null;
        public AdSiedUlicaNazwaEnum AdSiedUlicaNazwaEnum { get; init; }


        [XmlChoiceIdentifier("NumerTelefonuEnum")]
        [XmlElement(ElementName = "fiz_numerTelefonu", IsNullable = true)]
        [XmlElement(ElementName = "praw_numerTelefonu", IsNullable = true)]
        [XmlElement(ElementName = "fizC_numerTelefonu", IsNullable = true)]
        public string[] NumerTelefonu { get; init; } = Array.Empty<string>();
        public NumerTelefonuEnum[] NumerTelefonuEnum { get; init; } = Array.Empty<NumerTelefonuEnum>();


        [XmlChoiceIdentifier("NumerWewnetrznyTelefonuEnum")]
        [XmlElement(ElementName = "fiz_numerWewnetrznyTelefonu", IsNullable = true)]
        [XmlElement(ElementName = "praw_numerWewnetrznyTelefonu", IsNullable = true)]
        [XmlElement(ElementName = "fizC_numerWewnetrznyTelefonu", IsNullable = true)]
        public string[] NumerWewnetrznyTelefonu { get; init; } = Array.Empty<string>();
        public NumerWewnetrznyTelefonuEnum[] NumerWewnetrznyTelefonuEnum { get; init; } = Array.Empty<NumerWewnetrznyTelefonuEnum>();


        [XmlChoiceIdentifier("NumerFaksuEnum")]
        [XmlElement(ElementName = "fiz_numerFaksu", IsNullable = true)]
        [XmlElement(ElementName = "praw_numerFaksu", IsNullable = true)]
        [XmlElement(ElementName = "fizC_numerFaksu", IsNullable = true)]
        public string[] NumerFaksu { get; init; } = Array.Empty<string>();
        public NumerFaksuEnum[] NumerFaksuEnum { get; init; } = Array.Empty<NumerFaksuEnum>();


        [XmlChoiceIdentifier("AdresEmailEnum")]
        [XmlElement(ElementName = "fiz_adresEmail", IsNullable = true)]
        [XmlElement(ElementName = "praw_adresEmail", IsNullable = true)]
        [XmlElement(ElementName = "fizC_adresEmail", IsNullable = true)]
        [XmlElement(ElementName = "fiz_adresEmail2", IsNullable = true)]
        [XmlElement(ElementName = "praw_adresEmail2", IsNullable = true)]
        public string[] AdresEmail { get; init; } = Array.Empty<string>();
        public AdresEmailEnum[] AdresEmailEnum { get; init; } = Array.Empty<AdresEmailEnum>();


        [XmlChoiceIdentifier("WWWEnum")]
        [XmlElement(ElementName = "fiz_adresStronyinternetowej", IsNullable = true)]
        [XmlElement(ElementName = "praw_adresStronyinternetowej", IsNullable = true)]
        [XmlElement(ElementName = "fizC_adresStronyInternetowej", IsNullable = true)]
        public string[] WWW { get; init; } = Array.Empty<string>();
        public WWWEnum[] WWWEnum { get; init; } = Array.Empty<WWWEnum>();


        [XmlChoiceIdentifier("DataPowstaniaEnum")]
        [XmlElement(ElementName = "fiz_dataPowstania")]
        [XmlElement(ElementName = "lokpraw_dataPowstania")]
        [XmlElement(ElementName = "praw_dataPowstania")]
        [XmlElement(ElementName = "lokfiz_dataPowstania")]
        public string DataPowstania { get; init; } = null!;
        public DataPowstaniaEnum DataPowstaniaEnum { get; init; }


        [XmlChoiceIdentifier("DataRozpoczeciaDzialalnosciEnum")]
        [XmlElement(ElementName = "fiz_dataRozpoczeciaDzialalnosci")]
        [XmlElement(ElementName = "lokpraw_dataRozpoczeciaDzialalnosci")]
        [XmlElement(ElementName = "praw_dataRozpoczeciaDzialalnosci")]
        [XmlElement(ElementName = "lokfiz_dataRozpoczeciaDzialalnosci")]
        public string DataRozpoczeciaDzialalnosci { get; init; } = null!;
        public DataRozpoczeciaDzialalnosciEnum DataRozpoczeciaDzialalnosciEnum { get; init; }


        [XmlChoiceIdentifier("DataWpisuDoREGONEnum")]
        [XmlElement(ElementName = "fiz_dataWpisuDoREGONDzialalnosci")]
        [XmlElement(ElementName = "lokpraw_dataWpisuDoREGON")]
        [XmlElement(ElementName = "praw_dataWpisuDoREGON")]
        [XmlElement(ElementName = "lokfiz_dataWpisuDoREGON")]
        public string DataWpisuDoREGON { get; init; } = null!;
        public DataWpisuDoREGONEnum DataWpisuDoREGONEnum { get; init; }


        [XmlChoiceIdentifier("DataZawieszeniaEnum")]
        [XmlElement(ElementName = "fiz_dataZawieszeniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_dataZawieszeniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "praw_dataZawieszeniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_dataZawieszeniaDzialalnosci", IsNullable = true)]
        public string? DataZawieszenia { get; init; } = null;
        public DataZawieszeniaEnum DataZawieszeniaEnum { get; init; }


        [XmlChoiceIdentifier("DataWznowieniaEnum")]
        [XmlElement(ElementName = "fiz_dataWznowieniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_dataWznowieniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "praw_dataWznowieniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_dataWznowieniaDzialalnosci", IsNullable = true)]
        public string? DataWznowienia { get; init; } = null;
        public DataWznowieniaEnum DataWznowieniaEnum { get; init; }


        [XmlChoiceIdentifier("DataZaistnieniaZmianyEnum")]
        [XmlElement(ElementName = "fiz_dataZaistnieniaZmianyDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_dataZaistnieniaZmiany", IsNullable = true)]
        [XmlElement(ElementName = "praw_dataZaistnieniaZmiany", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_dataZaistnieniaZmiany", IsNullable = true)]
        public string? DataZaistnieniaZmiany { get; init; } = null;
        public DataZaistnieniaZmianyEnum DataZaistnieniaZmianyEnum { get; init; }


        [XmlChoiceIdentifier("DataZakonczeniaEnum")]
        [XmlElement(ElementName = "fiz_dataZakonczeniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_dataZakonczeniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "praw_dataZakonczeniaDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_dataZakonczeniaDzialalnosci", IsNullable = true)]
        public string? DataZakonczenia { get; init; } = null;
        public DataZakonczeniaEnum DataZakonczeniaEnum { get; init; }


        [XmlChoiceIdentifier("DataSkresleniaEnum")]
        [XmlElement(ElementName = "fiz_dataSkresleniazRegonDzialalnosci", IsNullable = true)]
        [XmlElement(ElementName = "lokpraw_dataSkresleniazRegon", IsNullable = true)]
        [XmlElement(ElementName = "praw_dataSkresleniazRegon", IsNullable = true)]
        [XmlElement(ElementName = "lokfiz_dataSkresleniazRegon", IsNullable = true)]
        public string? DataSkreslenia { get; init; } = null;
        public DataSkresleniaEnum DataSkresleniaEnum { get; init; }


        [XmlChoiceIdentifier("DataWpisuDoRejestruEwidencjiEnum")]
        [XmlElement(ElementName = "fizC_dataWpisuDoRejestruEwidencji")]
        [XmlElement(ElementName = "fizP_dataWpisuDoRejestruEwidencji")]
        [XmlElement(ElementName = "lokpraw_dataWpisuDoRejestruEwidencji")]
        [XmlElement(ElementName = "lokfiz_dataWpisuDoRejestruEwidencji")]
        public string? DataWpisuDoRejestruEwidencji { get; init; } = null;
        public DataWpisuDoRejestruEwidencjiEnum DataWpisuDoRejestruEwidencjiEnum { get; init; }


        [XmlChoiceIdentifier("NumerwRejestrzeEwidencjiEnum")]
        [XmlElement(ElementName = "fizC_numerwRejestrzeEwidencji")]
        [XmlElement(ElementName = "fizP_numerwRejestrzeEwidencji")]
        [XmlElement(ElementName = "lokpraw_numerWrejestrzeEwidencji")]
        [XmlElement(ElementName = "praw_numerWrejestrzeEwidencji")]
        [XmlElement(ElementName = "lokfiz_numerwRejestrzeEwidencji")]
        public string? NumerwRejestrzeEwidencji { get; init; } = null;
        public NumerwRejestrzeEwidencjiEnum NumerwRejestrzeEwidencjiEnum { get; init; }


        [XmlChoiceIdentifier("OrganRejestrowySymbolEnum")]
        [XmlElement(ElementName = "fizC_OrganRejestrowy_Symbol")]
        [XmlElement(ElementName = "fizP_OrganRejestrowy_Symbol")]
        [XmlElement(ElementName = "lokpraw_organRejestrowy_Symbol")]
        [XmlElement(ElementName = "praw_organRejestrowy_Symbol")]
        [XmlElement(ElementName = "lokfiz_organRejestrowy_Symbol")]
        public string? OrganRejestrowySymbol { get; init; } = null;
        public OrganRejestrowySymbolEnum OrganRejestrowySymbolEnum { get; init; }


        [XmlChoiceIdentifier("OrganRejestrowyNazwaEnum")]
        [XmlElement(ElementName = "fizC_OrganRejestrowy_Nazwa")]
        [XmlElement(ElementName = "fizP_OrganRejestrowy_Nazwa")]
        [XmlElement(ElementName = "lokpraw_organRejestrowy_Nazwa")]
        [XmlElement(ElementName = "praw_organRejestrowy_Nazwa")]
        [XmlElement(ElementName = "lokfiz_organRejestrowy_Nazwa")]
        public string? OrganRejestrowyNazwa { get; init; } = null;
        public OrganRejestrowyNazwaEnum OrganRejestrowyNazwaEnum { get; init; }


        [XmlChoiceIdentifier("RodzajRejestruSymbolEnum")]
        [XmlElement(ElementName = "fizC_RodzajRejestru_Symbol")]
        [XmlElement(ElementName = "fizP_RodzajRejestru_Symbol")]
        [XmlElement(ElementName = "lokpraw_rodzajRejestruEwidencji_Symbol")]
        [XmlElement(ElementName = "praw_rodzajRejestruEwidencji_Symbol")]
        [XmlElement(ElementName = "lokfiz_rodzajRejestru_Symbol")]
        public string? RodzajRejestruSymbol { get; init; } = null;
        public RodzajRejestruSymbolEnum RodzajRejestruSymbolEnum { get; init; }


        [XmlChoiceIdentifier("RodzajRejestruNazwaEnum")]
        [XmlElement(ElementName = "fizC_RodzajRejestru_Nazwa")]
        [XmlElement(ElementName = "fizP_RodzajRejestru_Nazwa")]
        [XmlElement(ElementName = "lokpraw_rodzajRejestruEwidencji_Nazwa")]
        [XmlElement(ElementName = "praw_rodzajRejestruEwidencji_Nazwa")]
        [XmlElement(ElementName = "lokfiz_rodzajRejestru_Nazwa")]
        public string RodzajRejestruNazwa { get; init; } = null!;
        public RodzajRejestruNazwaEnum RodzajRejestruNazwaEnum { get; init; }

        [XmlChoiceIdentifier("FormaFinansowaniaSymbolEnum")]
        [XmlElement(ElementName = "praw_formaFinansowania_Symbol")]
        [XmlElement(ElementName = "lokfiz_formaFinansowania_Symbol")]
        [XmlElement(ElementName = "lokpraw_formaFinansowania_Symbol")]
        public string? FormaFinansowaniaSymbol { get; init; } = null;
        public FormaFinansowaniaSymbolEnum FormaFinansowaniaSymbolEnum { get; init; }


        [XmlChoiceIdentifier("FormaFinansowaniaNazwaEnum")]
        [XmlElement(ElementName = "praw_formaFinansowania_Nazwa")]
        [XmlElement(ElementName = "lokfiz_formaFinansowania_Nazwa")]
        [XmlElement(ElementName = "lokpraw_formaFinansowania_Nazwa")]
        public string? FormaFinansowaniaNazwa { get; init; } = null;
        public FormaFinansowaniaNazwaEnum FormaFinansowaniaNazwaEnum { get; init; }


        [XmlChoiceIdentifier("PodstawowaFormaPrawnaSymbolEnum")]
        [XmlElement(ElementName = "praw_podstawowaFormaPrawna_Symbol")]
        [XmlElement(ElementName = "lokpraw_podstawowaFormaPrawna_Symbol")]
        public string? PodstawowaFormaPrawnaSymbol { get; init; } = null;
        public PodstawowaFormaPrawnaSymbolEnum PodstawowaFormaPrawnaSymbolEnum { get; init; }


        [XmlChoiceIdentifier("PodstawowaFormaPrawnaNazwaEnum")]
        [XmlElement(ElementName = "praw_podstawowaFormaPrawna_Nazwa")]
        [XmlElement(ElementName = "lokpraw_podstawowaFormaPrawna_Nazwa")]
        public string? PodstawowaFormaPrawnaNazwa { get; init; } = null;
        public PodstawowaFormaPrawnaNazwaEnum PodstawowaFormaPrawnaNazwaEnum { get; init; }


        [XmlChoiceIdentifier("SzczegolnaFormaPrawnaSymbolEnum")]
        [XmlElement(ElementName = "praw_szczegolnaFormaPrawna_Symbol")]
        [XmlElement(ElementName = "lokpraw_szczegolnaFormaPrawna_Symbol")]
        public string? SzczegolnaFormaPrawnaSymbol { get; init; } = null;
        public SzczegolnaFormaPrawnaSymbolEnum SzczegolnaFormaPrawnaSymbolEnum { get; init; }


        [XmlChoiceIdentifier("SzczegolnaFormaPrawnaNazwaEnum")]
        [XmlElement(ElementName = "praw_szczegolnaFormaPrawna_Nazwa")]
        [XmlElement(ElementName = "lokpraw_szczegolnaFormaPrawna_Nazwa")]
        public string? SzczegolnaFormaPrawnaNazwa { get; init; } = null;
        public SzczegolnaFormaPrawnaNazwaEnum SzczegolnaFormaPrawnaNazwaEnum { get; init; }


        [XmlChoiceIdentifier("OrganZalozycielskiSymbolEnum")]
        [XmlElement(ElementName = "praw_organZalozycielski_Symbol")]
        [XmlElement(ElementName = "lokpraw_organZalozycielski_Symbol")]
        public string? OrganZalozycielskiSymbol { get; init; } = null;
        public OrganZalozycielskiSymbolEnum OrganZalozycielskiSymbolEnum { get; init; }


        [XmlChoiceIdentifier("OrganZalozycielskiNazwaEnum")]
        [XmlElement(ElementName = "praw_organZalozycielski_Nazwa")]
        [XmlElement(ElementName = "lokpraw_organZalozycielski_Nazwa")]
        public string? OrganZalozycielskiNazwa { get; init; } = null;
        public OrganZalozycielskiNazwaEnum OrganZalozycielskiNazwaEnum { get; init; }


        [XmlChoiceIdentifier("FormaWlasnosciSymbolEnum")]
        [XmlElement(ElementName = "praw_formaWlasnosci_Symbol")]
        [XmlElement(ElementName = "lokpraw_formaWlasnosci_Symbol")]
        public string? FormaWlasnosciSymbol { get; init; } = null;
        public FormaWlasnosciSymbolEnum FormaWlasnosciSymbolEnum { get; init; }


        [XmlChoiceIdentifier("FormaWlasnosciNazwaEnum")]
        [XmlElement(ElementName = "praw_formaWlasnosci_Nazwa")]
        [XmlElement(ElementName = "lokpraw_formaWlasnosci_Nazwa")]
        public string? FormaWlasnosciNazwa { get; init; } = null;
        public FormaWlasnosciNazwaEnum FormaWlasnosciNazwaEnum { get; init; }
    }
}
