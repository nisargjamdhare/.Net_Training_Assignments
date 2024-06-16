using AutoMapper;
using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;
using EmployeeManagementSystem25.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Threading.Tasks;

namespace EmployeeManagementSystem25.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeBasicDetailsController : ControllerBase
    {
        private readonly IEmployeeBasicDetailsService _employeeBasicDetailsService;
        private readonly IEmployeeAdditionalDetailsService _employeeAdditionalDetailsService;
        private readonly IMapper _mapper;

        public EmployeeBasicDetailsController(IEmployeeBasicDetailsService employeeBasicDetailsService, IMapper mapper)
        {
            _employeeBasicDetailsService = employeeBasicDetailsService;
          
            _mapper = mapper;
        }
       
       

        [HttpPost]
        public async Task<EmployeeBasicDetailsDTO> AddEmployeeBasicDetails(EmployeeBasicDetailsDTO employeeBasicDetailsDTO)
        {
            var model = _mapper.Map<EmployeeBasicDetailsEntity>(employeeBasicDetailsDTO);
            var response = await _employeeBasicDetailsService.AddEmployeeBasicDetails(model);
            return _mapper.Map<EmployeeBasicDetailsDTO>(response);
        }


        [HttpGet]
        public async Task<List<EmployeeBasicDetailsDTO>> GetAllEmployeeBasicDetails()

        {
           
            var response = await _employeeBasicDetailsService.GetAllEmployeeBasicDetails();
            return _mapper.Map<List<EmployeeBasicDetailsDTO>>(response);

        }

        [HttpPost]
        public async Task<EmployeeBasicDetailsDTO> GetEmployeeBasicDetailsByUId(string UId)
        {
            return await _employeeBasicDetailsService.GetEmployeeBasicDetailsByUId(UId);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserDetailsByUId(string UId, [FromBody] EmployeeBasicDetailsDTO employeeBasicDetailsDTO)
        {
            var updatedUser = await _employeeBasicDetailsService.UpdateUserDetailsByUId(UId, employeeBasicDetailsDTO);
            return Ok(updatedUser);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserByUId(string UId)
        {
            var response = await _employeeBasicDetailsService.DeleteUserByUId(UId);
            return Ok("User Deleted SuccessFully!!");
        }


        // ******************************** Excel Import Export Methods ******************************************

         [HttpPost("ImportExcel")]
        public async Task<IActionResult> ImportExcel(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                return BadRequest("File is empty or null");
            }

            var employees = new List<EmployeeBasicDetailsDTO>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream); // Ensure async copying
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var houseOrBuildingNumberString = GetStringFromCell(worksheet, row, 10); // Assuming column 10 is HouseOrBuildingNumber
                        int houseOrBuildingNumber;
                        if (!int.TryParse(houseOrBuildingNumberString, out houseOrBuildingNumber))
                        {
                            return BadRequest($"Invalid HouseOrBuildingNumber at row {row}");
                        }

                        var address = new Address
                        {
                            HouseNumber = houseOrBuildingNumber,
                            StreetName = GetStringFromCell(worksheet, row, 11),
                            City = GetStringFromCell(worksheet, row, 12),
                            State = GetStringFromCell(worksheet, row, 13),
                            PostalCodes = GetStringFromCell(worksheet, row, 14)
                        };

                        var employee = new EmployeeBasicDetailsDTO
                        {
                            EmployeeID = GetStringFromCell(worksheet, row, 2),
                            Salutory = GetStringFromCell(worksheet, row, 3),
                            FirstName = GetStringFromCell(worksheet, row, 4),
                            MiddleName = GetStringFromCell(worksheet, row, 5),
                            LastName = GetStringFromCell(worksheet, row, 6),
                            NickName = GetStringFromCell(worksheet, row, 7),
                            Email = GetStringFromCell(worksheet, row, 8),
                            Mobile = GetStringFromCell(worksheet, row, 9),
                            Address = address,
                            Role = GetStringFromCell(worksheet, row, 15),
                            ReportingManagerUId = GetStringFromCell(worksheet, row, 16),
                            ReportingManagerName = GetStringFromCell(worksheet, row, 17),
                        };

                        // Call the service method to add employee basic details
                        var addedEmployee = await _employeeBasicDetailsService.AddEmployeeBasicDetails(employee);
                        employees.Add(addedEmployee);
                    }
                }
            }

            return Ok(employees);
        }

        private string GetStringFromCell(ExcelWorksheet worksheet, int row, int column)
        {
            var cellValue = worksheet.Cells[row, column].Value;
            return cellValue?.ToString();
        }

        [HttpGet("ExportInExcel")]
        public async Task<IActionResult> Export()
        {
            // Fetch basic employee details
            var basicDetails = await _employeeBasicDetailsService.GetAllEmployeeBasicDetails();

            // Prepare data for export
            var dataToExport = basicDetails.Select(basic => new EmployeeBasicDetailsDTO
            {
                EmployeeID = basic.EmployeeID,
                FirstName = basic.FirstName,
                LastName = basic.LastName,
                Email = basic.Email,
                Mobile = basic.Mobile,
                ReportingManagerName = basic.ReportingManagerName
            }).ToList();

            // Check if there are any records to export
            if (!dataToExport.Any())
            {
                return NotFound("No data found to export.");
            }

            // Configure ExcelPackage
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees");

                // Add Header
                worksheet.Cells[1, 1].Value = "Sr.No";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Last Name";
                worksheet.Cells[1, 4].Value = "Email";
                worksheet.Cells[1, 5].Value = "Phone No";
                worksheet.Cells[1, 6].Value = "Reporting Manager Name";

                // Set Header Style
                using (var range = worksheet.Cells[1, 1, 1, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                }

                // Populate data rows
                var rowIndex = 2;
                foreach (var data in dataToExport)
                {
                    worksheet.Cells[rowIndex, 1].Value = data.EmployeeID;
                    worksheet.Cells[rowIndex, 2].Value = data.FirstName;
                    worksheet.Cells[rowIndex, 3].Value = data.LastName;
                    worksheet.Cells[rowIndex, 4].Value = data.Email;
                    worksheet.Cells[rowIndex, 5].Value = data.Mobile;
                    worksheet.Cells[rowIndex, 6].Value = data.ReportingManagerName;
                    rowIndex++;
                }

                // Save Excel package to a stream
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                // Return the Excel file as a response
                var fileName = "Employees.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }


        ///  ***************************   Filter CriTeria **********************************

        [HttpGet]
         public async Task<IActionResult> GetAllEmployeeBasicDetailsByRole(string role)
        {
            var response = await _employeeBasicDetailsService.GetAllEmployeeBasicDetailsByRole(role);
            return Ok(response);
        }

        [HttpPost]

        public async Task<EmployeeFilterCriteria> GetAllEmployeeBasicDetailsByPagination(EmployeeFilterCriteria employeeFilterCriteria)
        {
            var response =  await _employeeBasicDetailsService.GetAllEmployeeBasicDetailsByPagination(employeeFilterCriteria);
            return response;
        }


    }




}

