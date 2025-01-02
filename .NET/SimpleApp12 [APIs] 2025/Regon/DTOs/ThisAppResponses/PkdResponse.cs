using Regon.DTOs.RegonApiResponses.Raporty.PKDs;

namespace Regon.DTOs.ThisAppResponses
{
    public class PkdResponse
    {
        public string Kod { get; init; } = null!;
        public string Nazwa { get; init; } = null!;
        /// <summary>
        /// 0 lub 1 1 = głowne
        /// </summary>
        public bool Przewazajace { get; init; } = false;


        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Public Methods 
        public static implicit operator PkdResponse(Pkd pkd)
        {
            return new PkdResponse
            {
                Kod = pkd.Kod,
                Nazwa = pkd.Nazwa,
                Przewazajace = int.Parse(pkd.Przewazajace) > 0,
            };
        }
        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Private Methods 
    }
}
