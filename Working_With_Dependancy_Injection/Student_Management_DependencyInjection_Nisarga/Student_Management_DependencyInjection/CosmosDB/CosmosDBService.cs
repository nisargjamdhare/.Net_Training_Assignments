using Microsoft.Azure.Cosmos;
using Student_Management_DependencyInjection.Common;
using Student_Management_DependencyInjection.Entity;
using System.ComponentModel;
using Container = Microsoft.Azure.Cosmos.Container;

namespace Student_Management_DependencyInjection.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        public readonly CosmosClient _cosmosClient;
        private readonly Container _container;
        public CosmosDBService()

        {
            _cosmosClient=new CosmosClient(Credentials.CosmosEndPoint,Credentials.PrimaryKey);
            _container =_cosmosClient.GetContainer(Credentials.databaseName,Credentials.containerName);
        }


        public async Task<StudentEntity> AddStudent(StudentEntity student)
        {
            var response = await _container.CreateItemAsync(student);
            return response;
        }

        public async Task<List<StudentEntity>> GetAllStudent()
        {
            var response = _container.GetItemLinqQueryable<StudentEntity>(true).Where(a=> a.Active== true && a.Archived == false
            && a.DocumentType==Credentials.StudentDocumentType).ToList();
            return response; 
        }
        public async Task<StudentEntity> GetStudentByUId(string uId)
        {
            var student = _container.GetItemLinqQueryable<StudentEntity>(true).Where(a => a.UId == uId && !a.Archived
            && a.Active && a.DocumentType== Credentials.StudentDocumentType).FirstOrDefault();
            return student;
        }

       

        public async Task ReplaceAsync(dynamic entity)
        {
            var response = await _container.ReplaceItemAsync(entity, entity.Id);
        }

    }
}
