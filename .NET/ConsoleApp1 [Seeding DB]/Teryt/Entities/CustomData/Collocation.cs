using Teryt.Entities.SourceData;

namespace Teryt.Entities.CustomData
{
    public class Collocation
    {
        public long DivisionId { get; set; }
        public long StreetId { get; set; }

        public Collocation(Ulic ulic)
        {
            DivisionId = ulic.Sym;
            StreetId = ulic.SymUl;
        }

        public Collocation(long divisionId, long streetId)
        {
            DivisionId = divisionId;
            StreetId = streetId;
        }
        public override string ToString() => $"D: {DivisionId}, U: {StreetId}";
    }
}
