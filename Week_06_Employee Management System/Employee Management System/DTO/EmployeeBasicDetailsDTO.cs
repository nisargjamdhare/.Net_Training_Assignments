using Microsoft.Owin.BuilderProperties;
using Newtonsoft.Json;

namespace EmployeeManagementSystem.DTO
{
    public class EmployeeBasicDetailsDTO 
    {
        [JsonProperty("salutory")]
        public string Salutory { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("nickName")]
        public string NickName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("employeeID")]
        public string EmployeeID { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("reportingManagerUId")]
        public string ReportingManagerUId { get; set; }

        [JsonProperty("reportingManagerName")]
        public string ReportingManagerName { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty(PropertyName = "dateOfJoining")]
        public DateTime DateOfJoining { get; set; }
    }
}
