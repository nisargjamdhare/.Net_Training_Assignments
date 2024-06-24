using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem25.CosmosDB
{
    public interface ICosmosDBService
    {
        // Methods for EmployeeBasicDetailsEntity
        Task<EmployeeBasicDetailsEntity> AddEmployeeBasicDetails(EmployeeBasicDetailsEntity employeeEntity);
        Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeBasicDetails();
        Task<EmployeeBasicDetailsEntity> GetEmployeeBasicDetailsByUId(string UId);
        Task ReplaceAsync(string UId, EmployeeBasicDetailsEntity existingUser);

        Task<EmployeeBasicDetailsDTO> AddEmployeeBasicDetails(EmployeeBasicDetailsDTO employeeBasicDetailsDTO);

        Task<ManagerEntity> AddManager(ManagerEntity manager);

        // Methods for EmployeeAdditionalDetailsEntity
        Task<EmployeeAdditionalDetailsEntity> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsEntity additionalDetailsEntity);
        Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmployeeAdditionalDetails();
        Task<EmployeeAdditionalDetailsEntity> GetEmployeeAdditionalDetailsByBasicDetailsUId(string basicDetailsUId);
        Task ReplaceAdditionalDetailsAsync(string UId, EmployeeAdditionalDetailsEntity additionalDetailsEntity);
    }
}
