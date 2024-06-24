using AutoMapper;
using Student_Management_DependencyInjection.DTO;
using Student_Management_DependencyInjection.Entity;

namespace Student_Management_DependencyInjection.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            CreateMap<StudentEntity, StudentDTO>().ReverseMap();
        }
    }
}
