using AutoMapper;
using EmployeeManagementSystem25.CosmosDB;
using EmployeeManagementSystem25.Entities;
using EmployeeManagementSystem25.Interfaces;

namespace EmployeeManagementSystem25.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ICosmosDBService _cosmosDBService;
        private readonly IMapper _mapper;

        public ManagerService(ICosmosDBService cosmosDBService, IMapper mapper)
        {
            _cosmosDBService = cosmosDBService;
            _mapper = mapper;
        }

        public async Task<ManagerEntity> AddManager(ManagerEntity managerEntity)
        {
            managerEntity.Initialize(true, "Manager", "nisarga", "nisarga");
            managerEntity = await _cosmosDBService.AddManager(managerEntity);
            return managerEntity;
        }
    }
}
