using AutoMapper;
using Employee_Management_System.Entities;
using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeAdditionalDetailsDTO, EmployeeBasicDetails>().ReverseMap();
            
        }
    }
}