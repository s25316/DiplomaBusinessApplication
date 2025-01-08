using Teryt.ValueObjects;

namespace Teryt.Entities.CustomData
{
    public class Response
    {
        public Dictionary<long, Street> Streets { get; set; } = new Dictionary<long, Street>();
        public IEnumerable<Collocation> Collocations { get; set; } = new List<Collocation>();
        public Dictionary<long, Division> Divisions { get; set; } = new Dictionary<long, Division>();
        public Dictionary<long, AdministrativeType> AdministrativeTypes { get; set; } = new();

    }
}
