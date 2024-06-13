using EmployeeManagementSystem.DTO;

namespace EmployeeManagementSystem.Interface
{
    public interface IEmployeeAdditionalDetailsService
    {
        Task<IEnumerable<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalDetails();
        Task DeleteEmployeeAdditionalDetails(string id);
        Task<EmployeeAdditionalDetailsDTO> UpdateEmployeeAdditionalDetails(string id, EmployeeAdditionalDetailsDTO employeeAdditionalDetails);
        Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDetailsById(string id);
        Task<EmployeeAdditionalDetailsDTO> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsDTO employeeAdditionalDetails);
    }
}
