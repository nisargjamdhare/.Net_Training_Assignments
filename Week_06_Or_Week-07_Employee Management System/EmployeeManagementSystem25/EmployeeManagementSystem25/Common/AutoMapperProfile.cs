using AutoMapper;
using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;

namespace EmployeeManagementSystem25.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeBasicDetailsEntity, EmployeeBasicDetailsDTO>().ReverseMap();
            CreateMap<ManagerEntity, ManagerDTO>().ReverseMap();
            CreateMap<EmployeeAdditionalDetailsDTO, EmployeeAdditionalDetailsEntity>().ReverseMap();
        }
    }
}
