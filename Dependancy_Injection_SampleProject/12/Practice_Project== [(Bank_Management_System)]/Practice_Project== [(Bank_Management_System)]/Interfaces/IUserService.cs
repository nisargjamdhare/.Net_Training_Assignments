using Practice_Project_____Bank_Management_System__.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice_Project_____Bank_Management_System__.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> AddUser(UserDTO userDTO);
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserByUId(string uId);
        Task<UserDTO> ReplaceAsync(string userId, UserDTO userDTO);
    }
}
