using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;

namespace EmployeeManagementSystem25.Interfaces
{
    public interface IEmployeeBasicDetailsService
    {
        Task<EmployeeBasicDetailsEntity> AddEmployeeBasicDetails(EmployeeBasicDetailsEntity employeeEntity);
        Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeBasicDetails();
        Task<EmployeeBasicDetailsDTO> GetEmployeeBasicDetailsByUId(string uId);

        Task<EmployeeBasicDetailsDTO> UpdateUserDetailsByUId(string UId, EmployeeBasicDetailsDTO employeeBasicDetailsDTO);

        Task<EmployeeBasicDetailsDTO> DeleteUserByUId(string UId);

        Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeBasicDetailsByRole(string role);  

        Task<EmployeeBasicDetailsDTO> AddEmployeeBasicDetails(EmployeeBasicDetailsDTO employee);
        Task<EmployeeFilterCriteria> GetAllEmployeeBasicDetailsByPagination(EmployeeFilterCriteria employeeFilterCriteria);
    }
}
