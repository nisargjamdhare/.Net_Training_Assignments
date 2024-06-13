using Newtonsoft.Json;

namespace Practice_Project_____Bank_Management_System__.DTO
{
    public class UserDTO
    {
        [JsonProperty(PropertyName = "uId")]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "dOB", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DOB { get; set; }
        [JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
    }
}
