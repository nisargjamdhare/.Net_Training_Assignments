using AutoMapper;
using EmployeeManagementSystem.CosmoDB;
using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Interface;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeAdditionalDetailsService : IEmployeeAdditionalDetailsService
    {
        private readonly ICosmoDBService _cosmoDBService;
        private readonly IMapper _autoMapper;

        public EmployeeAdditionalDetailsService(ICosmoDBService cosmoDBService, IMapper mapper)
        {
            _cosmoDBService = cosmoDBService;
            _autoMapper = mapper;
        }

        public async Task<EmployeeAdditionalDetailsDTO> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsDTO employeeAdditionalDetails)
        {
            var entity = _autoMapper.Map<EmployeeBasicDetails>(employeeAdditionalDetails);
            entity.Intialize(true, "employeeAdditionalDetails", "nisarga", "nisarga");
            var response = await _cosmoDBService.Add(entity);
            return _autoMapper.Map<EmployeeAdditionalDetailsDTO>(response);
        }

        public async Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDetailsById(string id)
        {
            var entity = await _cosmoDBService.GetEmployeeAdditionalDetailsById(id);
            return _autoMapper.Map<EmployeeAdditionalDetailsDTO>(entity);
        }
        public async Task<EmployeeAdditionalDetailsDTO> UpdateEmployeeAdditionalDetails(string id, EmployeeAdditionalDetailsDTO employeeAdditionalDetails)
        {
            var entity = await _cosmoDBService.GetEmployeeAdditionalDetailsById(id);
            if (entity == null) throw new Exception("Employee not found");

            _autoMapper.Map(employeeAdditionalDetails, entity);
            entity.Intialize(false, "employeeBasicDetails", "default", "default");

            var response = await _cosmoDBService.Update(id, entity);
            return _autoMapper.Map<EmployeeAdditionalDetailsDTO>(response);

        }

        public async Task DeleteEmployeeAdditionalDetails(string id)
        {
            var entity = await _cosmoDBService.GetEmployeeAdditionalDetailsById(id);
            if (entity == null) throw new Exception("Employee not found");

            await _cosmoDBService.DeleteAdditionalDetails(id);
        }

        public async Task<IEnumerable<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalDetails()
        {
            var entities = await _cosmoDBService.GetAll<EmployeeAdditionalDetailsEntity>();
            return _autoMapper.Map<IEnumerable<EmployeeAdditionalDetailsDTO>>(entities);
        }
    }
}
