using AutoMapper;
using EmployeeManagementSystem.CosmoDB;
using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeBasicDetailsService : IEmployeeBasicDetailsService
    {
        private readonly ICosmoDBService _cosmoDBService;
        private readonly IMapper _autoMapper;

        public EmployeeBasicDetailsService(ICosmoDBService cosmoDBService, IMapper mapper)
        {
            _cosmoDBService = cosmoDBService;
            _autoMapper = mapper;
        }

        public async Task<EmployeeBasicDetailsDTO> AddEmployeeBasicDetails(EmployeeBasicDetailsDTO employeeBasicDetails)
        {
            var entity = _autoMapper.Map<EmployeeBasicDetails>(employeeBasicDetails);
            entity.Intialize(true, "employeeBasicDetails", "default", "default");
            var response = await _cosmoDBService.Add(entity);
            return _autoMapper.Map<EmployeeBasicDetailsDTO>(response);
        }

        public async Task<IEnumerable<EmployeeBasicDetailsDTO>> GetAllEmployeeBasicDetails()
        {
            var entities = await _cosmoDBService.GetAll<EmployeeBasicDetails>();
            return _autoMapper.Map<IEnumerable<EmployeeBasicDetailsDTO>>(entities);
        }

        public async Task<EmployeeBasicDetailsDTO> GetEmployeeBasicDetailsById(string id)
        {
            var entity = await _cosmoDBService.GetEmployeeBasicDetailsById(id);
            return _autoMapper.Map<EmployeeBasicDetailsDTO>(entity);
        }

        public async Task<EmployeeBasicDetailsDTO> UpdateEmployeeBasicDetails(string id, EmployeeBasicDetailsDTO employeeBasicDetails)
        {
            var entity = await _cosmoDBService.GetEmployeeBasicDetailsById(id);
            if (entity == null) throw new Exception("Employee not found");

            _autoMapper.Map(employeeBasicDetails, entity);
            entity.Intialize(false, "employeeBasicDetails", "default", "default");

            var response = await _cosmoDBService.Update(id, entity);
            return _autoMapper.Map<EmployeeBasicDetailsDTO>(response);
        }

        public async Task DeleteEmployeeBasicDetails(string id)
        {
            var entity = await _cosmoDBService.GetEmployeeBasicDetailsById(id);
            if (entity == null) throw new Exception("Employee not found");

            await _cosmoDBService.DeleteBasicDetails(id);
        }
    }

}
