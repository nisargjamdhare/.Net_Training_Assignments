using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;

public interface IEmployeeAdditionalDetailsService
{
    Task<EmployeeAdditionalDetailsEntity> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsEntity additionalDetailsEntity);
    Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmployeeAdditionalDetails();
    Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDetailsByBasicDetailsUId(string basicDetailsUId);
    Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalDetailsByBasicDetailsUId(string basicDetailsUId, EmployeeAdditionalDetailsDTO additionalDetailsDTO);
    Task<EmployeeAdditionalDetailsDTO> DeleteAdditionalDetailsByBasicDetailsUId(string basicDetailsUId);
}
