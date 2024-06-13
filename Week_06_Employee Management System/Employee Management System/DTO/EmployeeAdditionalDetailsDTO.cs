using EmployeeManagementSystem.Entities;
using Newtonsoft.Json;

namespace EmployeeManagementSystem.DTO
{
    public class EmployeeAdditionalDetailsDTO
    {
        [JsonProperty("employeeBasicDetailsUId")]
        public string EmployeeBasicDetailsUId { get; set; }

        [JsonProperty("alternateEmail")]
        public string AlternateEmail { get; set; }

        [JsonProperty("alternateMobile")]
        public string AlternateMobile { get; set; }

        [JsonProperty("workInformation")]
        public WorkInfo_ WorkInformation { get; set; }

        [JsonProperty("personalDetails")]
        public PersonalDetails_ PersonalDetails { get; set; }

        [JsonProperty("identityInformation")]
        public IdentityInfo_ IdentityInformation { get; set; }
    }
}
