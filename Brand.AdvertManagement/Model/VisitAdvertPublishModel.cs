namespace Brand.AdvertManagement.Model.DTO.Request
{
    public class VisitAdvertPublishModel
    {
        public VisitAdvertPublishModel(string advertId, string? ipAddress, DateTime visitDate)
        {
            AdvertId = advertId;
            IPAddress = ipAddress;
            VisitDate = visitDate;
        }

        public string AdvertId { get; set; }

        public string? IPAddress { get; set; }

        public DateTime VisitDate { get; set; }
    }
}