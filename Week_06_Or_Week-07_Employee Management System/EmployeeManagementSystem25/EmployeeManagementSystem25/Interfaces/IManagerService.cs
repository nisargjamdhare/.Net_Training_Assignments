using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;

namespace EmployeeManagementSystem25.Interfaces
{
    public interface IManagerService
    {
        Task<ManagerEntity> AddManager(ManagerEntity managerEntity);
    }
}