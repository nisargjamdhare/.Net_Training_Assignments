using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Practice_Project_____Bank_Management_System__.Common;
using Practice_Project_____Bank_Management_System__.Interfaces;
using System.Threading.Tasks;
using User = Practice_Project_____Bank_Management_System__.Entities.User;

namespace Practice_Project_____Bank_Management_System__.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        public  readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosDBService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndpoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }

        public async Task<User> AddUser(User user)
        {
            var response = await _container.CreateItemAsync(user);
            return response;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var query = _container.GetItemLinqQueryable<User>(true)
                .Where(user => user.Active && !user.Archived && user.DocumentType == Credentials.UserDocumentType)
                .ToFeedIterator();

            var users = new List<User>();

            for (; query.HasMoreResults;)
            {
                var response = await query.ReadNextAsync();
                users.AddRange(response);
            }

            return users;
        }




        public async Task<User> GetUserByUId(string userId)
        {
            var query = _container.GetItemLinqQueryable<User>(true)
                                  .Where(q => q.Id == userId && q.DocumentType == Credentials.VisitorDocumentType && !q.Archived && q.Active)
                                  .ToFeedIterator();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                var user = response.FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
            }

            return null;
        }


        public async Task<User> ReplaceAsync(User user)
        {
            var response = await _container.ReplaceItemAsync(user, user.Id);
            return response.Resource;
        }
    }
}
