using OfficeOpenXml;
using RadonFlatFileDB.DTOs;
using RadonFlatFileDB.DTOs.Interfaces;

namespace RadonFlatFileDB.Repositories
{
    public class RadonRepository : IRadonRepository
    {
        //Properties
        private static readonly string _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _pathToFolder = Path.GetFullPath(Path.Combine(_baseDirectory, @"..\..\..\..\RadonFlatFileDB\Files\"));
        private static string _pathToInstitutions = "Instytucje systemu szkolnictwa wyższego i nauki.xlsx";
        private static string _pathToBranches = "Filie instytucji systemu szkolnictwa wyższego i nauki.xlsx";
        private static string _pathToDoctoralSchools = "Szkoły doktorskie.xlsx";
        private static string _pathToSpecialEducation = "Kształcenie specjalistyczne.xlsx";


        //==============================================================================================
        //==============================================================================================
        //==============================================================================================
        //Public Methods
        public IEnumerable<InstitutionDto> GetInstitutions(string? path = null)
        {
            path = path ?? $"{_pathToFolder}{_pathToInstitutions}";
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            return Serialize<InstitutionDto>(path);
        }

        public IEnumerable<BranchDto> GetBranches(string? path = null)
        {
            path = path ?? $"{_pathToFolder}{_pathToBranches}";
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            return Serialize<BranchDto>(path);
        }

        public IEnumerable<DoctoralSchoolDto> GetDoctoralSchools(string? path = null)
        {
            path = path ?? $"{_pathToFolder}{_pathToDoctoralSchools}";
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            return Serialize<DoctoralSchoolDto>(path);
        }

        public IEnumerable<KsztalcenieSpecjalistyczneDto> GetSpecialEducations(string? path = null)
        {
            path = path ?? $"{_pathToFolder}{_pathToSpecialEducation}";
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            return Serialize<KsztalcenieSpecjalistyczneDto>(path).ToHashSet();
        }

        //==============================================================================================
        //==============================================================================================
        //==============================================================================================
        //Private Methods
        public IEnumerable<T> Serialize<T>(string filePath) where T : class, IFactory<T>, new()
        {
            var list = new List<T>();
            // Załaduj plik Excel
            FileInfo fileInfo = new FileInfo(filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                // Pobierz pierwszy arkusz
                int totalSheets = package.Workbook.Worksheets.Count;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // Pobierz wymiary arkusza
                int rows = worksheet.Dimension.Rows;
                int columns = worksheet.Dimension.Columns;

                // Inicjalizacja dwuwymiarowej tablicy
                var table = new string[columns];

                // Przekształć dane arkusza na tablicę
                for (int i = 2; i <= rows; i++)
                {
                    for (int j = 1; j <= columns; j++)
                    {
                        //Czytanie tylko od 1 X 1 nie jak w tablice od 0 X 0
                        table[j - 1] = worksheet.Cells[i, j].Text;
                    }

                    var t = new T();
                    var institution = t.Create(table);
                    list.Add(institution);
                }
            }
            return list;
        }
    }
}
