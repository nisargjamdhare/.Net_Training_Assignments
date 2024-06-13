using Practice_Project_____Bank_Management_System__.Common;
using Practice_Project_____Bank_Management_System__.DTO;
using Practice_Project_____Bank_Management_System__.Entities;
using Practice_Project_____Bank_Management_System__.Interfaces;

namespace Practice_Project_____Bank_Management_System__.Services
{
    public class UserService : IUserService
    {
        private readonly ICosmosDBService _cosmosDBService;

        public UserService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            var user = new User
            {
                UId = userDTO.UId,
                Name = userDTO.Name,
                DOB = userDTO.DOB,
                Username = userDTO.Username,
                Password = userDTO.Password
            };

            user.Initialize(true, Credentials.UserDocumentType, "Nisarg", "NisargJamadhare");

            var response = await _cosmosDBService.AddUser(user);
            return new UserDTO
            {
                UId = response.UId,
                Name = response.Name,
                DOB = response.DOB,
                Username = response.Username,
                Password = response.Password
            };
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _cosmosDBService.GetAllUsers();
            return users.Select(user => new UserDTO
            {
                UId = user.UId,
                Name = user.Name,
                DOB = user.DOB,
                Username = user.Username,
                Password = user.Password
            }).ToList();
        }

        public async Task<UserDTO> GetUserByUId(string UId)
        {
            var user = await _cosmosDBService.GetUserByUId(UId);

            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                UId = user.UId,
                Name = user.Name,
                DOB = user.DOB,
                Username = user.Username,
                Password = user.Password
            };
        }

        public async Task<UserDTO> ReplaceAsync(string userId, UserDTO userDTO)
        {
            var existingUser = await _cosmosDBService.GetUserByUId(userDTO.UId);
            if (existingUser == null)
                return null;

            existingUser.Name = userDTO.Name;
            existingUser.DOB = userDTO.DOB;
            existingUser.Username = userDTO.Username;
            existingUser.Password = userDTO.Password;

            var response = await _cosmosDBService.ReplaceAsync(existingUser);

            return new UserDTO
            {
                UId = response.UId,
                Name = response.Name,
                DOB = response.DOB,
                Username = response.Username,
                Password = response.Password
            };
        }
    }
}
