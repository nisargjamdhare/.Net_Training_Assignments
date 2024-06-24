using Student_Management_DependencyInjection.DTO;

namespace Student_Management_DependencyInjection.Interface
{
    public interface IStudentService
    {
        Task<StudentDTO> AddStudent(StudentDTO studentDTO);
        Task <List<StudentDTO>> GetAllStudent();

        Task<StudentDTO> GetStudentByUId(String uId);

        Task<StudentDTO> UpdateStudent(StudentDTO studentDTO);

        Task<string> DeleteStudent(string uId);
    }
}
