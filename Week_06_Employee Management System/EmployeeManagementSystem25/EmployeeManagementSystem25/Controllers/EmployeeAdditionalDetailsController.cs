using AutoMapper;
using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;
using EmployeeManagementSystem25.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class EmployeeAdditionalDetailsController : ControllerBase
{
    private readonly IEmployeeAdditionalDetailsService _employeeAdditionalDetailsService;
    private readonly IMapper _mapper;

    public EmployeeAdditionalDetailsController(IEmployeeAdditionalDetailsService employeeAdditionalDetailsService, IMapper mapper)
    {
        _employeeAdditionalDetailsService = employeeAdditionalDetailsService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<EmployeeAdditionalDetailsDTO> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsDTO additionalDetailsDTO)
    {
        var entity = _mapper.Map<EmployeeAdditionalDetailsEntity>(additionalDetailsDTO);
        var response = await _employeeAdditionalDetailsService.AddEmployeeAdditionalDetails(entity);
        return _mapper.Map<EmployeeAdditionalDetailsDTO>(response);
    }

    [HttpGet]
    public async Task<List<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalDetails()
    {
        var response = await _employeeAdditionalDetailsService.GetAllEmployeeAdditionalDetails();
        return _mapper.Map<List<EmployeeAdditionalDetailsDTO>>(response);
    }

    [HttpPost]
    public async Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDetailsByBasicDetailsUId(string basicDetailsUId)
    {
        return await _employeeAdditionalDetailsService.GetEmployeeAdditionalDetailsByBasicDetailsUId(basicDetailsUId);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAdditionalDetailsByBasicDetailsUId(string basicDetailsUId, [FromBody] EmployeeAdditionalDetailsDTO additionalDetailsDTO)
    {
        var updatedDetails = await _employeeAdditionalDetailsService.UpdateAdditionalDetailsByBasicDetailsUId(basicDetailsUId, additionalDetailsDTO);
        return Ok(updatedDetails);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAdditionalDetailsByBasicDetailsUId(string basicDetailsUId)
    {
        var response = await _employeeAdditionalDetailsService.DeleteAdditionalDetailsByBasicDetailsUId(basicDetailsUId);
        return Ok("Details Deleted Successfully!!");
    }
}
