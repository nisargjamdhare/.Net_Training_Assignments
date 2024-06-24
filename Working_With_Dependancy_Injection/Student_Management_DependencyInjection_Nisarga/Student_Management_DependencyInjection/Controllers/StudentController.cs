using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Student_Management_DependencyInjection.DTO;
using Student_Management_DependencyInjection.Interface;
using System.Drawing;

namespace Student_Management_DependencyInjection.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : Controller
    {

        //To access the Interface of student in controller
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //Define API

        [HttpPost]

        public async Task<StudentDTO> AddStudent(StudentDTO studentDTO)
        {
            var response = await _studentService.AddStudent(studentDTO);
            return response;
        }

        [HttpGet]

        public async Task<List<StudentDTO>> GetAllStudent()
        {
            var response = await _studentService.GetAllStudent();
            return response;
        }

        [HttpGet]

        public async Task<StudentDTO> GetStudentByUId(string UId)
        {
            var response = await _studentService.GetStudentByUId(UId);
            return response;
        }

        [HttpPost]
        public async Task<StudentDTO> UpdateStudent(StudentDTO studentDTO)
        {
            var response = await _studentService.UpdateStudent(studentDTO);
            return response;
        }

        [HttpPost]

        public async Task<string> DeleteStudent (string  uId)
        {
            var response = await _studentService.DeleteStudent(uId);
            return response;
        }
        



        private string GetStringFormCell(ExcelWorksheet worksheet, int row, int column)
        {
            var cellValue = worksheet.Cells[row, column].Value;
            return cellValue?.ToString()?.Trim();
        }

        [HttpPost]

        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty ");


            var students = new List<StudentDTO>();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;


            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;


                    for (int row = 2; row <= rowCount; row++)
                    {
                        var age = Convert.ToInt32(GetStringFormCell(worksheet, row, 4) ?? "0");
                        var student = new StudentDTO
                        {

                            RollNo = GetStringFormCell(worksheet, row, 1),
                            StudentName = GetStringFormCell(worksheet, row, 2),
                            PhoneNumber = GetStringFormCell(worksheet, row, 3),
                            Age = age,


                        };
                        await AddStudent(student);

                        students.Add(student);
                    }
                }
            }
            return Ok((students));
        }


        [HttpGet]
        public async Task<IActionResult> Export()
        {
            var students = await _studentService.GetAllStudent();
            ExcelPackage.LicenseContext=OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Students");

                //Add Header
                worksheet.Cells[1, 1].Value = "UId";
                worksheet.Cells[1, 2].Value = "RollNo";
                worksheet.Cells[1, 3].Value = "StudentName";
                worksheet.Cells[1, 4].Value = "Age";
                worksheet.Cells[1, 5].Value = "PhoneNumber";


                //set header style

                using(var range = worksheet.Cells[1,1,1,5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

                }

                //Add Student data

                for(int i=0;i<students.Count;i++)
                {
                    var student = students[i];
                    worksheet.Cells[i + 2, 1].Value = student.UId;
                    worksheet.Cells[i + 2, 2].Value = student.RollNo;
                    worksheet.Cells[i + 2, 3].Value = student.StudentName;
                    worksheet.Cells[i + 2, 4].Value = student.Age;
                    worksheet.Cells[i + 2, 5].Value = student.PhoneNumber;



                }

                var stream = new System.IO.MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Book2.xlsx";
                return File(stream, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

            }
        }
    }
}
