using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SchoolFrom.Model;
using SchoolFrom.Service;
using System.Reflection;

namespace SchoolFrom.Controllers
{
    [ApiController]
   
    public class GetExelController : ControllerBase
    {
        private readonly DataBaseMethods dataBaseMethodsl;
        [HttpGet]
        [Route("GetExel")]
        public async Task<IActionResult> ExportExcel()
        {
            var databaseCollection = dataBaseMethodsl.GetAllCandidates(); // Получите данные из базы данных

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Candidates");

                Type type = typeof(Candidate);
                PropertyInfo[] properties = type.GetProperties(); //  read
                string[] propertiesNames = new string[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    propertiesNames[i] = properties[i].Name;
                }

                for (int columms = 0; columms < databaseCollection.Result.Count; columms++)
                {
                    for (int rows = 1; rows < propertiesNames.Length; rows++)
                    {
                        worksheet.Cells[rows, columms].Value = propertiesNames[rows];

                    }
                }
                var stream = new MemoryStream(package.GetAsByteArray()); //read

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Candidates.xlsx");
            }
        }
    }
}
