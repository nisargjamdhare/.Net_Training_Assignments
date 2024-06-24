using Newtonsoft.Json;

namespace EmployeeManagementSystem25.DTO
{
    public class ManagerDTO
    {
        [JsonProperty (PropertyName = "uId",NullValueHandling = NullValueHandling.Ignore)]
        
        public string UId { get; set; }
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

    }
}
