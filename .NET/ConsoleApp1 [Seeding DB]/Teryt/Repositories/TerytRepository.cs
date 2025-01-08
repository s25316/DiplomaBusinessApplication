using Teryt.CustomExeptions;
using Teryt.Entities.CustomData;
using Teryt.Entities.SourceData;
using Teryt.ValueObjects;

namespace Teryt.Repositories
{
    public class TerytRepository
    {
        private static readonly string _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _flatFilesPath = Path.GetFullPath(Path.Combine(_baseDirectory, @"..\..\..\..\Teryt\FlatFiles\"));
        private readonly string _pathToFileSimc = $"{_flatFilesPath}\\SIMC_Adresowy_2024-08-12.csv";
        private readonly string _pathToFileUlic = $"{_flatFilesPath}\\ULIC_Adresowy_2024-08-12.csv";
        private readonly string _pathToFileTerc = $"{_flatFilesPath}\\TERC_Adresowy_2024-08-12.csv";

        private readonly DataAdapterRepository _adapter = new DataAdapterRepository();

        public TerytRepository()
        {

        }

        public TerytRepository(string pathToFileTerc, string pathToFileSimc, string pathToFileUlic)
        {
            if (!File.Exists(pathToFileSimc))
            {
                throw new FileNotFoundException($"File Not Exist: {pathToFileSimc}");
            }
            if (!File.Exists(pathToFileUlic))
            {
                throw new FileNotFoundException($"File Not Exist: {pathToFileUlic}");
            }
            if (!File.Exists(pathToFileTerc))
            {
                throw new FileNotFoundException($"File Not Exist: {pathToFileTerc}");
            }
            _pathToFileSimc = pathToFileSimc;
            _pathToFileUlic = pathToFileUlic;
            _pathToFileTerc = pathToFileTerc;
        }
        //=======================================================================================================
        //Source
        public async Task<IEnumerable<Terc>> SelectFileTercAsync()
        {
            var list = new List<Terc>();
            await using (FileStream fs = File.Open
                (
                _pathToFileTerc,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite
                ))
            {
                await using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        string? str = sr.ReadLine();
                        while ((str = sr.ReadLine()) != null)
                        {
                            if (string.IsNullOrWhiteSpace(str))
                            {
                                continue;
                            }
                            var terc = (Terc)str;
                            list.Add(terc);
                        }
                    }
                }
            }
            return list;
        }

        public async Task<Dictionary<long, Simc>> SelectFileSimcAsync()
        {
            var dictionary = new Dictionary<long, Simc>();
            await using (FileStream fs = File.Open
                (
                _pathToFileSimc,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite
                ))
            {
                await using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        string? str = sr.ReadLine();
                        while ((str = sr.ReadLine()) != null)
                        {
                            if (string.IsNullOrWhiteSpace(str))
                            {
                                continue;
                            }
                            var simcs = (Simc)str;
                            dictionary.Add(simcs.Sym, simcs);
                        }
                    }
                }
            }
            return dictionary;
        }

        public async Task<IEnumerable<Ulic>> SelectFileUlicAsync()
        {
            var list = new List<Ulic>();
            await using (FileStream fs = File.Open
                (
                _pathToFileUlic,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite
                ))
            {
                await using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        string? str = sr.ReadLine();
                        while ((str = sr.ReadLine()) != null)
                        {
                            if (string.IsNullOrWhiteSpace(str))
                            {
                                continue;
                            }
                            var ulica = (Ulic)str;
                            list.Add(ulica);
                        }
                    }
                }
            }
            return list;
        }

        //=======================================================================================================


        public async Task<Response> GetFullDataAsync(int startIdDivision, int startIdStreet, int startIdType, int startIdDepth)
        {
            AdministrativeType.StartValueDepth = startIdDepth;
            AdministrativeType.StartValue = startIdType;
            var pair = await GetCollocationsAndStreetsAsync(startIdStreet);
            var divisions = await GetDivisionsAsync(startIdDivision);
            var collocations = _adapter.AdaptColocations(pair.Item1, divisions, pair.Item2);
            var response = new Response
            {
                Divisions = divisions,
                Streets = pair.Item2,
                Collocations = collocations,
                AdministrativeTypes = AdministrativeType.GetAllTypes(),
            };

            return response;
        }
        //=================================================================================================================================================
        //=================================================================================================================================================
        //Private Methods
        //=================================================================================================================================================

        //Custom
        private async Task<(IEnumerable<Collocation>, Dictionary<long, Street>)> GetCollocationsAndStreetsAsync(int startId)
        {
            var ulicList = await SelectFileUlicAsync();
            return (_adapter.SelectColocations(ulicList), _adapter.SelectStreets(ulicList, startId));
        }

        private async Task<Dictionary<long, Division>> GetDivisionsAsync(long startId)
        {
            var terc = await SelectFileTercAsync();
            var simc = await SelectFileSimcAsync();
            //Always > 0
            if (startId < 1)
            {
                throw new TerytExeption("Val >= 1 ");
            }
            Division.StartId = startId;

            var simcDivisions = _adapter.TransformSimc(simc);
            var tercDivisions = _adapter.TransformTerc(terc);

            if (_adapter.IsAllSimcKeysContansInTercKeys(tercDivisions, simcDivisions))
            {
                throw new TerytExeption($"Files Simc And Terc data incomplete");
            }

            var redundant = _adapter.SelectRedundantSimc(simcDivisions);

            tercDivisions = _adapter.SettoTercDivisionsDataFromRedundantSimc(tercDivisions, redundant);
            simcDivisions = _adapter.RemoveRedundantValuesFromSimc(redundant, simcDivisions);

            tercDivisions = _adapter.TercCreateIdAndStructure(tercDivisions);

            return _adapter.JoinTercAndSimc(tercDivisions, simcDivisions);
        }

    }
}
