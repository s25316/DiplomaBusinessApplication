using Teryt.CustomExeptions;
using Teryt.Entities.CustomData;
using Teryt.Entities.SourceData;
using Teryt.ValueObjects;

namespace Teryt.Repositories
{
    public class DataAdapterRepository
    {
        public IEnumerable<Collocation> SelectColocations(IEnumerable<Ulic> ulicy)
        {
            return ulicy.Select(u => new Collocation(u)).ToList();
        }

        public Dictionary<long, Street> SelectStreets(IEnumerable<Ulic> ulicy, long startId)
        {
            Street.StartId = startId;
            return ulicy.GroupBy(ul => ul.SymUl).Select(group => new Street(group.First()))
                .ToDictionary(st => st.Id, st => st);
        }
        public Dictionary<(long, long?, long?, AdministrativeType), Division> TransformTerc(IEnumerable<Terc> structure)
        {
            return structure.Select(str => new Division(str)).ToDictionary(div => div.TercKey, div => div);
        }

        public Dictionary<(long, long?, long?, AdministrativeType), List<Division>> TransformSimc(Dictionary<long, Simc> cities)
        {
            var divisionsDictionary = cities.ToDictionary(city => city.Key, city => new Division(city.Value));
            divisionsDictionary.Values.Where(div => div.SourceParentId != null).ToList().ForEach(div =>
            {
                if (div.SourceParentId != null && divisionsDictionary.TryGetValue(div.SourceParentId.Value, out var parent))
                {
                    div.ParentId = parent.Id;
                }
                //Can add exeption
            });
            var result = divisionsDictionary.Values.GroupBy(val => val.TercKey).ToDictionary(group => group.Key, group => group.Select(x => x).ToList());
            return result;
        }

        public bool IsAllSimcKeysContansInTercKeys
            (
            Dictionary<(long, long?, long?, AdministrativeType), Division> terc,
            Dictionary<(long, long?, long?, AdministrativeType), List<Division>> simc
            )
        {
            var keySimc = terc.Keys;
            var keyTerc = simc.Keys;
            var intersect = keyTerc.Intersect(keySimc);
            return intersect.Count() != simc.Count();
        }

        //Dopracowac
        public Dictionary<(long, long?, long?, AdministrativeType), Division> SelectRedundantSimc
           (
           Dictionary<(long, long?, long?, AdministrativeType), List<Division>> cities
           )
        {
            var redundantValues = cities.Where(city => city.Value.Any(div => div.Type.Name == city.Key.Item4.Name))
                .ToDictionary(
                x => x.Key,
                x => x.Value.Where(y => y.Type.Name == x.Key.Item4.Name && y.SourceParentId == null).ToList()
                );

            if (redundantValues.Where(city => city.Value.Count != 1).ToList().Count() > 0)
            {
                throw new TerytExeption("Niepoprawne dane żrodłowe, struktura danych redundantnych zmieniła sie należy przepisać kod, lub dana funkcje");
                ///Najprawdopodobnej dodac warunki w WHERE
            };
            return redundantValues.ToDictionary(d => d.Key, d => d.Value.First());
        }


        public Dictionary<(long, long?, long?, AdministrativeType), Division> SettoTercDivisionsDataFromRedundantSimc
            (
            Dictionary<(long, long?, long?, AdministrativeType), Division> terc,
            Dictionary<(long, long?, long?, AdministrativeType), Division> redundant
            )
        {
            foreach (var item in redundant)
            {
                if (terc.TryGetValue(item.Key, out var tercDiv))
                {
                    tercDiv.TercJoinSimcData(item.Value);
                }
            }
            return terc;
        }


        public Dictionary<(long, long?, long?, AdministrativeType), List<Division>> RemoveRedundantValuesFromSimc
            (
            Dictionary<(long, long?, long?, AdministrativeType), Division> redundant,
            Dictionary<(long, long?, long?, AdministrativeType), List<Division>> simc
            )
        {
            foreach (var item in redundant)
            {
                if (simc.TryGetValue(item.Key, out var simcListDiv))
                {
                    simcListDiv.Remove(item.Value);
                    if (simcListDiv.Count == 0)
                    {
                        simc.Remove(item.Key);
                    }
                }
            }
            return simc;
        }

        public Dictionary<(long, long?, long?, AdministrativeType), Division> TercCreateIdAndStructure
           (
           Dictionary<(long, long?, long?, AdministrativeType), Division> terc
           )
        {
            foreach (var item in terc)
            {
                item.Value.GenerateId();
            }

            terc.Where(parent => parent.Key.Item2 == null && parent.Key.Item3 == null).ToList().ForEach(woj =>
            {
                terc.Where(child =>

                child.Key.Item1 == woj.Key.Item1 &&
                child.Key.Item2 != null &&
                child.Key.Item3 == null

                ).ToList().ForEach(pow =>
                {
                    pow.Value.ParentId = woj.Value.Id;
                });
            });

            terc.Where(parent => parent.Key.Item2 != null && parent.Key.Item3 == null).ToList().ForEach(pow =>
            {
                terc.Where(child =>

                child.Key.Item1 == pow.Key.Item1 &&
                child.Key.Item2 == pow.Key.Item2 &&
                child.Key.Item3 != null).ToList().ForEach(gmi =>
                {
                    gmi.Value.ParentId = pow.Value.Id;
                });
            });
            return terc;
        }

        public Dictionary<long, Division> JoinTercAndSimc
           (
           Dictionary<(long, long?, long?, AdministrativeType), Division> terc,
           Dictionary<(long, long?, long?, AdministrativeType), List<Division>> simc
           )
        {
            simc.ToList().ForEach(sim =>
            {
                if (terc.TryGetValue(sim.Key, out var ter))
                {
                    sim.Value.ForEach(x =>
                    {
                        x.ParentId = ter.Id;
                    });
                }
                else
                {
                    throw new NotImplementedException();
                }
            });

            var tercList = terc.Select(t => t.Value).ToList();
            var simcList = simc.SelectMany(t => t.Value).ToList();

            var list = tercList.Concat(simcList);
            var dictionary = list.ToDictionary(var => var.Id, var => var);
            if (list.Count() != dictionary.Count())
            {
                throw new TerytExeption("after Transfoming not the same values");
            }
            return dictionary;
        }

        public IEnumerable<Collocation> AdaptColocations
            (
            IEnumerable<Collocation> collocations,
            Dictionary<long, Division> divisions,
            Dictionary<long, Street> streets
            )
        {
            var list = new List<Collocation>();
            //If set id dictionary  as IdSource shold more faster
            var divisionsWIthSourceId = divisions.Values.Where(x => x.SourceId != null).ToDictionary(x => x.SourceId, x => x);
            var streetsWIthSourceId = streets.Values.ToDictionary(x => x.IdSource, x => x);

            collocations.GroupBy(x => x.StreetId).ToList().ForEach(x =>
            {
                if (streetsWIthSourceId.TryGetValue(x.Key, out var street))
                {
                    x.ToList().ForEach(y =>
                    {
                        if (divisionsWIthSourceId.TryGetValue(y.DivisionId, out var div))
                        {

                            list.Add(new Collocation(

                                divisionId: div.Id,
                                streetId: street.Id
                            ));
                        }
                        else
                        {
                            throw new Exception("Not exist");
                        }
                    });
                }
                else
                {
                    throw new Exception("Not exist");
                }
            });

            /* collocations.GroupBy(x => x.StreetId).ToList().ForEach(x =>
             {
                 var street = streets.Values.Where(str => str.IdSource == x.Key).FirstOrDefault();
                 if (street == null)
                 {
                     throw new Exception();
                 }
                 x.ToList().ForEach(x =>
                 {
                     var division = divisions.Values.Where(div => div.SourceId == x.DivisionId).FirstOrDefault();
                     if (division == null)
                     {
                         throw new Exception();
                     }

                     list.Add(new Collocation(

                         divisionId: division.Id,
                         streetId: street.Id
                     ));
                 });
             });
 */

            if (list.Count() != collocations.Count())
            {
                throw new TerytExeption("after Transfoming not the same values");
            }
            return list;
        }

        //========================================================================================================================================================================================================
    }
}
