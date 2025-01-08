using Teryt.Entities.SourceData;
using Teryt.ValueObjects;

namespace Teryt.Entities.CustomData
{
    public class Street
    {
        public static long StartId = 1;
        //============================================================================================================================================
        public long Id { get; private set; } = -1;
        public long IdSource { get; private set; } = -1;
        public AdministrativeType? Cecha { get; private set; } = null;
        public string Nazwa1 { get; private set; } = null!;
        public string? Nazwa2 { get; private set; } = null;

        public Street(Ulic ulic)
        {
            Id = StartId++;
            IdSource = ulic.SymUl;
            Cecha = ulic.Cecha;
            Nazwa1 = ulic.Nazwa1;
            Nazwa2 = ulic.Nazwa2;
        }

        public override string ToString()
        {
            return string.Format
                (
                "{0}: {1}; {2}: {3}; {4}: \"{5}\" \"{6}\" ",
                "Id",
                Id,
                "Cecha",
                Cecha,
                "Nazwa",
                Nazwa1,
                Nazwa2
                );
        }
    }
}
