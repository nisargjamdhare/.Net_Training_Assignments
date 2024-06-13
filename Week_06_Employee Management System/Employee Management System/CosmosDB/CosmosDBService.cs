using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using EmployeeManagementSystem.Common;
using EmployeeManagementSystem.Entities;
using Employee_Management_System.Common;

namespace EmployeeManagementSystem.CosmoDB
{
    public class CosmoDBService : ICosmoDBService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmoDBService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndpoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.DatabaseName, Credentials.ContainerName);
        }

        public async Task<T> Add<T>(T entity)
        {
            var response = await _container.CreateItemAsync(entity);
            return response.Resource;
        }

        public async Task<T> Update<T>(string id, T entity)
        {
            var response = await _container.ReplaceItemAsync(entity, id);
            return response.Resource;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            var query = _container.GetItemQueryIterator<T>();
            var results = new List<T>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public async Task<EmployeeBasicDetails> GetEmployeeBasicDetailsById(string id)
        {
            try
            {
                var query = _container.GetItemLinqQueryable<EmployeeBasicDetails>(true)
                                      .Where(q => q.Id == id && q.Active && !q.Archived)
                                      .FirstOrDefault();
                return query;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<EmployeeAdditionalDetailsEntity> GetEmployeeAdditionalDetailsById(string id)
        {
            try
            {
                var query = _container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true)
                                      .Where(q => q.Id == id && q.Active && !q.Archived)
                                      .FirstOrDefault();
                return query;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task DeleteBasicDetails(string id)
        {
            var employee = await GetEmployeeBasicDetailsById(id);
            if (employee != null)
            {
                employee.Active = false;
                employee.Archived = true;
                await Update(id, employee);
            }
            else
            {
                throw new Exception($"Item with ID {id} not found.");
            }
        }

        public async Task DeleteAdditionalDetails(string id)
        {
            var employee = await GetEmployeeAdditionalDetailsById(id);
            if (employee != null)
            {
                employee.Active = false;
                employee.Archived = true;
                await Update(id, employee);
            }
            else
            {
                throw new Exception($"Item with ID {id} not found.");
            }
        }
    }
}
