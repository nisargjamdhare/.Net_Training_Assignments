using Newtonsoft.Json;

namespace EmployeeManagementSystem25.DTO
{
    public class StudentDTO 
    {
        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)] 
        public string UId { get; set; }

        [JsonProperty(PropertyName = "rollNo", NullValueHandling = NullValueHandling.Ignore)]
        public string RollNo { get; set; }

        [JsonProperty(PropertyName = "studentName", NullValueHandling = NullValueHandling.Ignore)]
        public string StudentName { get; set; }

        [JsonProperty(PropertyName = "age", NullValueHandling = NullValueHandling.Ignore)]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
    }
}
