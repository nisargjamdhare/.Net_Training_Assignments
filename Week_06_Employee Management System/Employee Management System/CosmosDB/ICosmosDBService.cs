using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem.CosmoDB
{
    public interface ICosmoDBService
    {
        //Generic Function for all services
        Task<IEnumerable<T>> GetAll<T>();
        Task<T> Add<T>(T entity);
        Task<T> Update<T>(string id, T entity);

        //Additional Details Function
        Task DeleteAdditionalDetails(string id);
        Task<EmployeeAdditionalDetailsEntity> GetEmployeeAdditionalDetailsById(string id);

        //Baisc Details Function
        Task<EmployeeBasicDetails> GetEmployeeBasicDetailsById(string id);
        Task DeleteBasicDetails(string id);
    }
}
