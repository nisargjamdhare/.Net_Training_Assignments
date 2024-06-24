using AutoMapper;
using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;
using EmployeeManagementSystem25.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem25.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IMapper _mapper;

        public ManagerController(IManagerService managerService, IMapper mapper)
        {
            _managerService = managerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ManagerDTO> AddManager(ManagerDTO managerDTO)
        {
            var model = _mapper.Map<ManagerEntity>(managerDTO);
            var response = await _managerService.AddManager(model);
            return _mapper.Map<ManagerDTO>(response);
        }
    }
}
