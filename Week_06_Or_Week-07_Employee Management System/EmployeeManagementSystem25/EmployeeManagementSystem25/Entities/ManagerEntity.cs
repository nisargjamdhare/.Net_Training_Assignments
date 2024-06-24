using EmployeeManagementSystem25.Entities;
using Newtonsoft.Json;

namespace EmployeeManagementSystem25.Entities
{
    public class ManagerEntity : BaseEntity
    {
        
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

    }
}
