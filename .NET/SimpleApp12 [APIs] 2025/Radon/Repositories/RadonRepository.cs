using Radon.Enums;

namespace Radon.Repositories
{
    public class RadonRepository : IRadonRepository
    {
        //Properties
        private static readonly string _url = "https://radon.nauka.gov.pl/opendata/polon/";

        private static readonly string _institutionUuidQueryParameter = "institutionUuid=";
        private static readonly string _branchUuidQueryParameter = "branchUuid=";
        private static readonly string _mainInstitutionNameQueryParameter = "mainInstitutionName=";
        private static readonly string _mainInstitutionUuidQueryParameter = "mainInstitutionUuid=";

        private static readonly string _resultNumbersQueryParameter = "resultNumbers=";
        private static readonly string _tokenQueryParameter = "token=";
        private static readonly string _nameQueryParameter = "name=";
        private static readonly string _nipQueryParameter = "nip=";
        private static readonly string _krsQueryParameter = "krs=";
        private static readonly string _regonQueryParameter = "regon=";



        //==================================================================================================
        //==================================================================================================
        //==================================================================================================
        //Private Methods

        //WWW
        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_institution
        public async Task<string> GetInstytucjeAsync(
            string value,
            InstytucjeSearchByEnum search,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default)
        {
            var urlSegment = "institutions?";
            var url = CreateBaseUrl(urlSegment, maxItems, token);

            switch (search)
            {
                case InstytucjeSearchByEnum.Nip:
                    url = $"{url}&{_nipQueryParameter}{value}";
                    break;
                case InstytucjeSearchByEnum.Krs:
                    url = $"{url}&{_krsQueryParameter}{value}";
                    break;
                case InstytucjeSearchByEnum.Regon:
                    url = $"{url}&{_regonQueryParameter}{value}";
                    break;
                case InstytucjeSearchByEnum.InstitutionUuid:
                    url = $"{url}&{_institutionUuidQueryParameter}{value.ToLower()}";
                    break;
                case InstytucjeSearchByEnum.Name:
                    url = $"{url}&{_nameQueryParameter}{value}";
                    break;
                default:
                    url = $"{url}&name={value}";
                    break;
            }
            var json = await MakeRequestAsync(url, cancellation);
            return json;
        }

        //WWW
        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_branch
        public async Task<string> GetBranchesAsync(
            string value,
            BranchesSearchByEnum search,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default)
        {
            var urlSegment = "branches?";
            var url = CreateBaseUrl(urlSegment, maxItems, token);

            switch (search)
            {
                case BranchesSearchByEnum.Nip:
                    url = $"{url}&{_nipQueryParameter}{value}";
                    break;
                case BranchesSearchByEnum.Krs:
                    url = $"{url}&{_krsQueryParameter}{value}";
                    break;
                case BranchesSearchByEnum.Regon:
                    url = $"{url}&{_regonQueryParameter}{value}";
                    break;
                case BranchesSearchByEnum.BranchUuid:
                    url = $"{url}&{_branchUuidQueryParameter}{value.ToLower()}";
                    break;
                case BranchesSearchByEnum.BranchName:
                    url = $"{url}&{_nameQueryParameter}{value}";
                    break;
                case BranchesSearchByEnum.MainInstitutionUuid:
                    url = $"{url}&{_mainInstitutionUuidQueryParameter}{value.ToLower()}";
                    break;
                case BranchesSearchByEnum.MainInstitutionName:
                    url = $"{url}&{_mainInstitutionNameQueryParameter}{value}";
                    break;
                default:
                    url = $"{url}&{_mainInstitutionNameQueryParameter}{value}";
                    break;
            };

            var json = await MakeRequestAsync(url, cancellation);
            return json;
        }

        //WWW
        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_course
        public async Task<string> GetCoursesAsync(
            string value,
            CoursesSearchByEnum search,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default)
        {
            //511d4dfc-574e-4801-af14-e99dc24f8209&Uniwersytet%20Warszawski
            var urlSegment = "courses?";
            var url = CreateBaseUrl(urlSegment, maxItems, token);

            switch (search)
            {
                case CoursesSearchByEnum.InstitutionUuid:
                    url = $"{url}&leadingInstitutionUuid={value.ToLower()}";
                    break;
                case CoursesSearchByEnum.InstitutionName:
                    url = $"{url}&leadingInstitutionName={value}";
                    break;
                default:
                    url = $"{url}&leadingInstitutionName={value}";
                    break;
            }
            var json = await MakeRequestAsync(url, cancellation);
            return json;
        }

        //WWW
        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_doctoral_school
        public async Task<string> GetDoctoralSchoolsAsync(
            Guid doctoralSchoolGuid,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default)
        {
            var urlSegment = "doctoralSchools?";
            var url = CreateBaseUrl(urlSegment, maxItems, token);
            url = $"{url}&doctoralSchoolUuid={doctoralSchoolGuid.ToString().ToLower()}";
            var json = await MakeRequestAsync(url, cancellation);
            return json;
        }

        //WWW
        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_specialized_education
        public async Task<string> GetSpecializedEducationsAsync(
            Guid institutionUuid,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default)
        {
            var urlSegment = "specializedEducations?";
            var url = CreateBaseUrl(urlSegment, maxItems, token);
            url = $"{url}&institutionUuid={institutionUuid.ToString().ToLower()}";
            var json = await MakeRequestAsync(url, cancellation);
            return json;
        }

        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_dictionaries
        public async Task<string> GetDisciplinesAsync(CancellationToken cancellation = default)
        {
            var url = "https://radon.nauka.gov.pl/opendata/polon/dictionaries/shared/disciplines";
            var json = await MakeRequestAsync(url, cancellation);
            return json;
        }
        //==================================================================================================
        //==================================================================================================
        //==================================================================================================
        //Private Methods
        private async Task<string> MakeRequestAsync(string endpoint, CancellationToken cancellation)
        {
            using (var client = new HttpClient())
            {
                //Prepare Request
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(endpoint),
                };

                //Making Request
                var response = await client.SendAsync(request, cancellation);
                string body = await response.Content.ReadAsStringAsync(cancellation);

                request.Dispose();
                response.Dispose();

                return body;
            }
        }

        private string CreateBaseUrl(
            string urlSegment,
            int maxItems = 100,
            string? token = null)
        {
            maxItems = maxItems > 100 ? 100 : maxItems;
            maxItems = maxItems < 10 ? 10 : maxItems;
            var url = $"{_url}{urlSegment}{_resultNumbersQueryParameter}{maxItems}";
            url = string.IsNullOrWhiteSpace(token) ?
                url :
                $"{url}&{_tokenQueryParameter}{token}";
            return url;
        }
    }
}
