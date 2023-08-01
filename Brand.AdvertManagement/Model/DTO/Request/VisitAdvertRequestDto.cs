using System.Text.Json.Serialization;

namespace Brand.AdvertManagement.Model.DTO.Request
{
    public class VisitAdvertRequestDto
    {
        public string AdvertId { get; set; }

        [JsonIgnore]
        public string IPAddress { get; set; }

        [JsonIgnore]
        public DateTime VisitDate { get; set; }
    }
}