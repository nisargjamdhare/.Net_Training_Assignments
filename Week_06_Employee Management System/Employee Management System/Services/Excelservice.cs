using OfficeOpenXml;
using Employee_Management_System.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EmployeeManagementSystem.Entities;

namespace Employee_Management_System.Services
{
    public class ExcelService
    {
        public async Task<List<EmployeeBasicDetails>> ImportEmployeeDetailsAsync(Stream fileStream)
        {
            var employeeList = new List<EmployeeBasicDetails>();

            using (var package = new ExcelPackage(fileStream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var employee = new EmployeeBasicDetails
                    {
                        Salutory = worksheet.Cells[row, 1].Text,
                        FirstName = worksheet.Cells[row, 2].Text,
                        MiddleName = worksheet.Cells[row, 3].Text,
                        LastName = worksheet.Cells[row, 4].Text,
                        NickName = worksheet.Cells[row, 5].Text,
                        Email = worksheet.Cells[row, 6].Text,
                        Mobile = worksheet.Cells[row, 7].Text,
                        EmployeeID = worksheet.Cells[row, 8].Text,
                        Role = worksheet.Cells[row, 9].Text,
                        ReportingManagerUId = worksheet.Cells[row, 10].Text,
                        ReportingManagerName = worksheet.Cells[row, 11].Text,
                        DateOfBirth = DateTime.Parse(worksheet.Cells[row, 12].Text),
                        DateOfJoining = DateTime.Parse(worksheet.Cells[row, 13].Text),
                        // Add Address property handling if needed
                    };
                    employeeList.Add(employee);
                }
            }

            return employeeList;
        }

        public async Task<Stream> ExportEmployeeDetailsAsync(List<EmployeeBasicDetails> employeeList)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("EmployeeDetails");

                worksheet.Cells[1, 1].Value = "Sr.No";
                worksheet.Cells[1, 2].Value = "Salutory";
                worksheet.Cells[1, 3].Value = "First Name";
                worksheet.Cells[1, 4].Value = "Middle Name";
                worksheet.Cells[1, 5].Value = "Last Name";
                worksheet.Cells[1, 6].Value = "Nick Name";
                worksheet.Cells[1, 7].Value = "Email";
                worksheet.Cells[1, 8].Value = "Phone No";
                worksheet.Cells[1, 9].Value = "Employee ID";
                worksheet.Cells[1, 10].Value = "Role";
                worksheet.Cells[1, 11].Value = "Reporting Manager UId";
                worksheet.Cells[1, 12].Value = "Reporting Manager Name";
                worksheet.Cells[1, 13].Value = "Date Of Birth";
                worksheet.Cells[1, 14].Value = "Date of Joining";

                for (int i = 0; i < employeeList.Count; i++)
                {
                    var employee = employeeList[i];
                    worksheet.Cells[i + 2, 1].Value = i + 1;
                    worksheet.Cells[i + 2, 2].Value = employee.Salutory;
                    worksheet.Cells[i + 2, 3].Value = employee.FirstName;
                    worksheet.Cells[i + 2, 4].Value = employee.MiddleName;
                    worksheet.Cells[i + 2, 5].Value = employee.LastName;
                    worksheet.Cells[i + 2, 6].Value = employee.NickName;
                    worksheet.Cells[i + 2, 7].Value = employee.Email;
                    worksheet.Cells[i + 2, 8].Value = employee.Mobile;
                    worksheet.Cells[i + 2, 9].Value = employee.EmployeeID;
                    worksheet.Cells[i + 2, 10].Value = employee.Role;
                    worksheet.Cells[i + 2, 11].Value = employee.ReportingManagerUId;
                    worksheet.Cells[i + 2, 12].Value = employee.ReportingManagerName;
                    worksheet.Cells[i + 2, 13].Value = employee.DateOfBirth.ToString("yyyy-MM-dd");
                    worksheet.Cells[i + 2, 14].Value = employee.DateOfJoining.ToString("yyyy-MM-dd");
                }

                package.SaveAs(stream);
            }

            stream.Position = 0;
            return stream;
        }
    }
}
