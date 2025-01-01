using Regon.Enums;

namespace Regon.ValueObjects
{
    public record PelnyRaport
    {
        //Properties
        public string Typ { get; init; } = null!;
        public int? SilosID { get; init; } = null;
        public PelnyRaportEnum Raport { get; private init; }
        public PelnyRaportEnum RaportPkd { get; private init; }
        public IEnumerable<PelnyRaportEnum> RaportyInne { get; private init; } = [];


        //Constructor
        public PelnyRaport(string typ, int? silosID)
        {
            Typ = typ;
            SilosID = silosID;

            switch (typ.ToLower())
            {
                case "f":
                    switch (SilosID)
                    {
                        case 1:
                            Raport = PelnyRaportEnum.PublDaneRaportDzialalnoscFizycznejCeidg;
                            break;
                        case 2:
                            Raport = PelnyRaportEnum.PublDaneRaportDzialalnoscFizycznejRolnicza;
                            break;
                        case 3:
                            Raport = PelnyRaportEnum.PublDaneRaportDzialalnoscFizycznejPozostala;
                            break;
                        case 4:
                            Raport = PelnyRaportEnum.PublDaneRaportDzialalnoscFizycznejWKrupgn;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    RaportPkd = PelnyRaportEnum.PublDaneRaportDzialalnosciFizycznej;

                    RaportyInne = new List<PelnyRaportEnum>
                    {
                        PelnyRaportEnum.PublDaneRaportFizycznaOsoba, //F, null
                        PelnyRaportEnum.PublDaneRaportLokalneFizycznej, //F, null
                    };
                    break;
                case "lf":
                    Raport = PelnyRaportEnum.PublDaneRaportLokalnaFizycznej;
                    RaportPkd = PelnyRaportEnum.PublDaneRaportDzialalnosciLokalnejFizycznej;
                    break;
                case "p":
                    Raport = PelnyRaportEnum.PublDaneRaportPrawna;
                    RaportPkd = PelnyRaportEnum.PublDaneRaportDzialalnosciPrawnej;

                    RaportyInne = new List<PelnyRaportEnum>
                    {
                        PelnyRaportEnum.PublDaneRaportLokalnePrawnej,
                        PelnyRaportEnum.PublDaneRaportWspolnicyPrawnej,
                    };
                    break;
                case "lp":
                    Raport = PelnyRaportEnum.PublDaneRaportLokalnaPrawnej;
                    RaportPkd = PelnyRaportEnum.PublDaneRaportDzialalnosciLokalnejPrawnej;
                    break;
                default:
                    throw new NotImplementedException();
            }
            /*
            //Nieuzywane
            RaportyInne = new List<PelnyRaportEnum>
            {
                PelnyRaportEnum.PublDaneRaportTypJednostki,//null, null
            };*/
        }


        //=================================================================================================
        //=================================================================================================
        //=================================================================================================
        //Public Methods

        //=================================================================================================
        //=================================================================================================
        //=================================================================================================
        //Private Methods


    }
}
