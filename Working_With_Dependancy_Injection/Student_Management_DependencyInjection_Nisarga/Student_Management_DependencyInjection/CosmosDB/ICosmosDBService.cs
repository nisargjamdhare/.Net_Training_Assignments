using Student_Management_DependencyInjection.Entity;

namespace Student_Management_DependencyInjection.CosmosDB
{
    public interface ICosmosDBService
    {
        Task<StudentEntity> AddStudent(StudentEntity student);
        Task <List<StudentEntity>> GetAllStudent();
        Task<StudentEntity> GetStudentByUId(string uId);

        Task ReplaceAsync(dynamic student);
    }
}
