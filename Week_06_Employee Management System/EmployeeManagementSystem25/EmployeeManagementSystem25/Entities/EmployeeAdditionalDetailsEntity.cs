using EmployeeManagementSystem25.Entities;
using Newtonsoft.Json;

namespace EmployeeManagementSystem25.Entities
{
    public class EmployeeAdditionalDetailsEntity : BaseEntity
    {
        [JsonProperty (PropertyName = "employeeBasicDetailsUId", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeBasicDetailsUId { get; set; }

        [JsonProperty(PropertyName = "alternateEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateEmail { get; set; }

        [JsonProperty(PropertyName = "alternateMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateMobile { get; set; }

        [JsonProperty(PropertyName = "workInformation", NullValueHandling = NullValueHandling.Ignore)]
        public WorkInfo_ WorkInformation { get; set; }

        [JsonProperty(PropertyName = "personalDetails", NullValueHandling = NullValueHandling.Ignore)]
        public PersonalDetails_ PersonalDetails { get; set; }

        [JsonProperty(PropertyName = "identityInformation", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityInfo_ IdentityInformation { get; set; }
    }

    public class WorkInfo_
    {
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public string LocationName { get; set; }
        public string EmployeeStatus { get; set; } // Terminated, Active, Resigned etc
        public string SourceOfHire { get; set; }
        public DateTime DateOfJoining { get; set; }
    }

    public class IdentityInfo_
    {
        public string PAN { get; set; }
        public string Aadhar { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public string PFNumber { get; set; }
    }

    public class PersonalDetails_
    { 
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }

}
