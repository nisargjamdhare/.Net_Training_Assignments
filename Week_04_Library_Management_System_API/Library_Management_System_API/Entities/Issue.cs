using Newtonsoft.Json;

namespace Library_Management_System_API.Entities
{
    public class Issue : EntityBase
    {
        [JsonProperty(PropertyName = "bookId", NullValueHandling = NullValueHandling.Ignore)]
        public string BookId { get; set; }

        [JsonProperty(PropertyName = "memberId", NullValueHandling = NullValueHandling.Ignore)]
        public string MemberId { get; set; }

        [JsonProperty(PropertyName = "issueDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime IssueDate { get; set; }

        [JsonProperty(PropertyName = "ReturnDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ReturnDate { get; set; }

        [JsonProperty(PropertyName = "isReturned", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsReturned { get; set; }
    }
}
