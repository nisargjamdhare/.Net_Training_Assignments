using Practice_Project_____Bank_Management_System__.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice_Project_____Bank_Management_System__.Interfaces
{
    public interface ICosmosDBService
    {
        Task<User> AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByUId(string userId);
        Task<User> ReplaceAsync(User user);
    }
}
