using AutoMapper;
using EmployeeManagementSystem25.Common;
using EmployeeManagementSystem25.CosmosDB;
using EmployeeManagementSystem25.DTO;
using EmployeeManagementSystem25.Entities;
using EmployeeManagementSystem25.Interfaces;

public class EmployeeAdditionalDetailsService : IEmployeeAdditionalDetailsService
{
    private readonly ICosmosDBService _cosmosDBService;
    private readonly IMapper _mapper;

    public EmployeeAdditionalDetailsService(ICosmosDBService cosmosDBService, IMapper mapper)
    {
        _cosmosDBService = cosmosDBService;
        _mapper = mapper;
    }

    public async Task<EmployeeAdditionalDetailsEntity> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsEntity additionalDetailsEntity)
    {
        additionalDetailsEntity.Initialize(true, "AdditionalDetails", "admin", "admin");
        additionalDetailsEntity = await _cosmosDBService.AddEmployeeAdditionalDetails(additionalDetailsEntity);
        return additionalDetailsEntity;
    }

    public async Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmployeeAdditionalDetails()
    {
        return await _cosmosDBService.GetAllEmployeeAdditionalDetails();
    }

    public async Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDetailsByBasicDetailsUId(string basicDetailsUId)
    {
        var response = await _cosmosDBService.GetEmployeeAdditionalDetailsByBasicDetailsUId(basicDetailsUId);
        return _mapper.Map<EmployeeAdditionalDetailsDTO>(response);
    }

    public async Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalDetailsByBasicDetailsUId(string UId, EmployeeAdditionalDetailsDTO additionalDetailsDTO)
    {
        var existingAdditionalDetails = await _cosmosDBService.GetEmployeeAdditionalDetailsByBasicDetailsUId(UId);
        if (existingAdditionalDetails == null)
        {
            return null;
        }
        existingAdditionalDetails.Active = false;
        existingAdditionalDetails.Archieved = true;

       
        await _cosmosDBService.ReplaceAdditionalDetailsAsync(UId, existingAdditionalDetails);
        existingAdditionalDetails.Initialize(true, Credentials.AdditionalEmployee, "Nisarga", "Nisarga");

        _mapper.Map(additionalDetailsDTO, existingAdditionalDetails);
        existingAdditionalDetails =await _cosmosDBService.AddEmployeeAdditionalDetails(existingAdditionalDetails);
        return _mapper.Map<EmployeeAdditionalDetailsDTO>(existingAdditionalDetails);
    }


    public async Task<EmployeeAdditionalDetailsDTO> DeleteAdditionalDetailsByBasicDetailsUId(string basicDetailsUId)
    {
        var existingAdditionalDetails = await _cosmosDBService.GetEmployeeAdditionalDetailsByBasicDetailsUId(basicDetailsUId);
        if (existingAdditionalDetails == null)
        {
            return null;
        }
        existingAdditionalDetails.Active = false;
        existingAdditionalDetails.Archieved = true;
        await _cosmosDBService.ReplaceAdditionalDetailsAsync(basicDetailsUId, existingAdditionalDetails);

        return _mapper.Map<EmployeeAdditionalDetailsDTO>(existingAdditionalDetails);
    }
}
