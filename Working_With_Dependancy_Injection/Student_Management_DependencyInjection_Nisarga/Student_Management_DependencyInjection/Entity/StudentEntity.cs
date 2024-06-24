using Newtonsoft.Json;
using Student_Management_DependencyInjection.Common;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;

namespace Student_Management_DependencyInjection.Entity
{
    public class StudentEntity:BaseEntity
    {
        
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
