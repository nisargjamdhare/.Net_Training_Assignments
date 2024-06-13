using Newtonsoft.Json;

namespace Practice_Project_____Bank_Management_System__.Entities
{
    public class User : BaseEntity
    {
        [JsonProperty (PropertyName = "uId" , NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set;}
        [JsonProperty (PropertyName = "name" , NullValueHandling = NullValueHandling.Ignore)]
         public string Name { get; set; }
        [JsonProperty(PropertyName = "dOB" , NullValueHandling = NullValueHandling.Ignore)]
         public DateTime DOB { get; set; }
        [JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
         public string Username { get; set; }

        [JsonProperty (PropertyName = "password" , NullValueHandling = NullValueHandling.Ignore)]
         public string Password { get; set; }


    }
}
