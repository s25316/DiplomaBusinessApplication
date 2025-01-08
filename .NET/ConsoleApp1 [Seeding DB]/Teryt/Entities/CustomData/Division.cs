using Teryt.Entities.SourceData;
using Teryt.ValueObjects;

namespace Teryt.Entities.CustomData
{
    public class Division
    {
        public static long StartId = 1;
        //====================================================================================================================================================
        //Values
        public long Id { get; private set; } = -1;
        public long? ParentId { get; set; } = null;
        public long? SourceId { get; private set; } = null;
        public long? SourceParentId { get; private set; } = null;
        public (long, long?, long?, AdministrativeType) TercKey { get; private set; }
        public string Name { get; private set; } = null!;
        public AdministrativeType Type { get; private set; }

        //Constructor
        public Division(long? sourceId, long? sourceParentId, (long, long?, long?, AdministrativeType) tercKey, string name, AdministrativeType type)
        {

            SourceId = sourceId;
            SourceParentId = sourceParentId;
            TercKey = tercKey;
            Name = name;
            Type = type;
        }

        public Division(Simc simc) : this(simc.Sym, simc.SymPod, (simc.Woj, simc.Pow, simc.Gmi, simc.RodzGmi), simc.Nazwa, simc.Rm)
        {
            GenerateId();
        }
        public Division(Terc terc) : this(null, null, (terc.Woj, terc.Pow, terc.Gmi, terc.Rodz), terc.Nazwa, terc.Rodz)
        {

        }

        public void TercJoinSimcData(Division simc)
        {
            Id = simc.Id;
            SourceId = simc.SourceId;
        }

        public void GenerateId()
        {
            if (Id < 1)
            {
                Id = StartId++;
            }
        }

        public override string ToString()
        {
            return string.Format
                (
                "{0}: {1}; {2}: {3}; {4}: {5}; {6}: {7}; {8}: {9};{10}: {11}; {12}: {13};",
                "Id",
                Id,
                "ParentId",
                ParentId,
                "SourceId",
                SourceId,
                "SourceParentId",
                SourceParentId,
                "TercKey",
                TercKey,
                "Name",
                Name,
                "Type",
                $"{Type.Name}, {Type.Depth}"
                );
        }
    }
}
