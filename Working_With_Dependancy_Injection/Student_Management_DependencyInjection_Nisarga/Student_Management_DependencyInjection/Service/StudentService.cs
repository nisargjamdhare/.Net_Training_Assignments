using AutoMapper;
using Student_Management_DependencyInjection.Common;
using Student_Management_DependencyInjection.CosmosDB;
using Student_Management_DependencyInjection.DTO;
using Student_Management_DependencyInjection.Entity;
using Student_Management_DependencyInjection.Interface;
using System.Net.Cache;

namespace Student_Management_DependencyInjection.Service
{
    public class StudentService : IStudentService
    {
        public readonly ICosmosDBService _cosmosDBService;
        private readonly IMapper _mapper;

        public StudentService(ICosmosDBService cosmosDBService, IMapper mapper)
        {
            _cosmosDBService = cosmosDBService;
            _mapper = mapper;
        }

        public async Task<StudentDTO> AddStudent(StudentDTO studentDTO)
        {


            /* StudentEntity student = new StudentEntity();
             student.RollNo = studentDTO.RollNo;
             student.StudentName = studentDTO.StudentName;
             student.Age = studentDTO.Age;
             student.PhoneNumber = studentDTO.PhoneNumber;*/

            var student = _mapper.Map<StudentEntity>(studentDTO);




            student.Intialize(true, Credentials.StudentDocumentType, "Nisarga", "Nisarga");


            var response = await _cosmosDBService.AddStudent(student);

           /* var responseModel = new StudentDTO();
            responseModel.UId = response.UId;
            responseModel.RollNo = response.RollNo;
            responseModel.StudentName = response.StudentName;
            responseModel.Age = response.Age;
            responseModel.PhoneNumber = response.PhoneNumber;*/
           var responseModel = _mapper.Map<StudentDTO>(response);


            return responseModel;

        }

        public async Task<List<StudentDTO>> GetAllStudent()
        {
            var students = await _cosmosDBService.GetAllStudent();

            var studentDtos = new List<StudentDTO>();
            foreach (var student in students)
            {
                var studentDto = _mapper.Map<StudentDTO>(student);
                studentDtos.Add(studentDto);
            }
            return studentDtos;
        }

        public async Task<StudentDTO> GetStudentByUId(string UId)
        {
            var response = await _cosmosDBService.GetStudentByUId(UId);
             
            var studentDTO = _mapper.Map<StudentDTO>(response);
            return studentDTO;
        }

        public async Task<StudentDTO> UpdateStudent(StudentDTO studentDTO)
        {
            var existingStudent = await _cosmosDBService.GetStudentByUId(studentDTO.UId);
            existingStudent.Active = false;
            existingStudent.Archived = true;
            await _cosmosDBService.ReplaceAsync(existingStudent);
           
            
            // Reinitialize the student entity and map properties from the DTO
            existingStudent.Intialize(false, Credentials.StudentDocumentType, "Nisarga", "Nisarga");
            _mapper.Map(studentDTO, existingStudent);
            var response = await _cosmosDBService.AddStudent(existingStudent);

            var responseModel = _mapper.Map<StudentDTO>(response);
            return responseModel;


        }

        public async Task<string> DeleteStudent(string uId)
        {
            //get student by uid
            var student = await _cosmosDBService.GetStudentByUId(uId);
            student.Active=false;
            student.Archived=true;
            await _cosmosDBService.ReplaceAsync(student);

            student.Intialize(false, Credentials.StudentDocumentType, "nish", "nish");
            student.Archived = true;
            var response = await _cosmosDBService.AddStudent(student);
               return "Record Deleted Successfully";

        }
    }
}
