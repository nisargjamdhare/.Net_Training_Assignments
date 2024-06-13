using Employee_Management_System.Services;
using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeBasicDetailsController : Controller
    {
        private readonly IEmployeeBasicDetailsService _basicDetailService;
        private readonly ExcelService _excelService;

        public EmployeeBasicDetailsController(IEmployeeBasicDetailsService basicDetailService)
        {
            _basicDetailService = basicDetailService;
           
        }

        [HttpPost]
        public async Task<EmployeeBasicDetailsDTO> AddBasicDetail(EmployeeBasicDetailsDTO basicDetailsDTO)
        {
            return await _basicDetailService.AddEmployeeBasicDetails(basicDetailsDTO);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeBasicDetailsDTO>> GetAllEmployeeBasicDetails()
        {
            return await _basicDetailService.GetAllEmployeeBasicDetails();
        }

        [HttpGet("{id}")]
        public async Task<EmployeeBasicDetailsDTO> GetEmployeeBasicDetailsById(string id)
        {
            return await _basicDetailService.GetEmployeeBasicDetailsById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeBasicDetails(string id, EmployeeBasicDetailsDTO basicDetailsDTO)
        {
            try
            {
                var updatedEmployee = await _basicDetailService.UpdateEmployeeBasicDetails(id, basicDetailsDTO);
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateVisitor (Controller): {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeBasiclDetails(string id)
        {
            await _basicDetailService.DeleteEmployeeBasicDetails(id);
            return NoContent();
        }


        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please upload a valid file.");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var employees = await _excelService.ImportEmployeeDetailsAsync(stream);

                foreach (var employee in employees)
                {
                  /*  await _basicDetailService.AddEmployeeBasicDetails(employee);*/
                }
            }

            return Ok();
        }

        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
            var employees = await _basicDetailService.GetAllEmployeeBasicDetails();
         /*   var stream = await _excelService.ExportEmployeeDetailsAsync(employees);*/

            return File("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EmployeeDetails.xlsx");
        }


    }
}
