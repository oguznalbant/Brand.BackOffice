namespace Brand.AdvertManagement.Entities
{
    public class AdvertVisit
    {
        public int Id { get; set; }
        public int AdvertId { get; set; }
        public string IPAdress { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
