using EmployeeManagementSystem25.Common;
using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using Container = Microsoft.Azure.Cosmos.Container;


namespace EmployeeManagementSystem25.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {

        public Container _container;

        public CosmosDBService()
        {
            _container = GetContainer();
        }

       

        public async Task<EmployeeBasicDetailsEntity> AddEmployeeBasicDetails(EmployeeBasicDetailsEntity employeeEntity)
        {
           return await _container.CreateItemAsync(employeeEntity);
        }

        public  async Task<ManagerEntity> AddManager(ManagerEntity managerEntity)
        {
            return await _container.CreateItemAsync(managerEntity);
        }

        public async Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeBasicDetails()
        {
            var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(q => q.DocumentType == Credentials.EmployeeDataType && q.Active ==true && q.Archieved == false).AsEnumerable().ToList();

            return response;
        }

       

        public async Task<EmployeeBasicDetailsEntity> GetEmployeeBasicDetailsByUId(string UId)
        {
            EmployeeBasicDetailsEntity response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(q => q.UId == UId && q.DocumentType == Credentials.EmployeeDataType && q.Active && !q.Archieved).AsEnumerable().FirstOrDefault();
            return response;
        }

        public async Task ReplaceAsync(string UId, EmployeeBasicDetailsEntity existingUser)
        {
            await _container.ReplaceItemAsync(existingUser, UId);
        }


        //Additional Details Part 

        public async Task<EmployeeAdditionalDetailsEntity> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsEntity additionalDetailsEntity)
        {
            return await _container.CreateItemAsync(additionalDetailsEntity);
        }

        public async Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmployeeAdditionalDetails()
        {
            var response = _container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true)
                .Where(q => q.DocumentType == "AdditionalDetails" && q.Active && !q.Archieved)
                .AsEnumerable()
                .ToList();

            return response;
        }

        public async Task<EmployeeAdditionalDetailsEntity> GetEmployeeAdditionalDetailsByBasicDetailsUId(string basicDetailsUId)
        {
            var response = _container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true)
                .Where(q => q.EmployeeBasicDetailsUId == basicDetailsUId && q.Active && !q.Archieved)
                .AsEnumerable()
                .FirstOrDefault();

            return response;
        }

        public async Task ReplaceAdditionalDetailsAsync(string basicDetailsUId, EmployeeAdditionalDetailsEntity additionalDetailsEntity)
        {
            await _container.ReplaceItemAsync(additionalDetailsEntity, basicDetailsUId);
        }


        private  Container GetContainer()
        {
            string URI = Environment.GetEnvironmentVariable("cosmosUrl");
            string PrimaryKey = Environment.GetEnvironmentVariable("primaryKey");
            string DatabaseName = Environment.GetEnvironmentVariable("databaseName");
            string ContainerName = Environment.GetEnvironmentVariable("containerName");

            CosmosClient cosmosclient = new CosmosClient(URI, PrimaryKey);
            Database database = cosmosclient.GetDatabase(DatabaseName);
            Container container = database.GetContainer(ContainerName);
            return container;
        }

        public async Task<EmployeeBasicDetailsDTO> AddEmployeeBasicDetails(EmployeeBasicDetailsDTO employeeBasicDetailsDTO)
        {
            var response = await _container.CreateItemAsync(employeeBasicDetailsDTO);
            return response;
        }

       
    }
}
