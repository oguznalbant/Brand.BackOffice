namespace Brand.AdvertManagement.Model
{
    public interface IPaginationResponse
    {
        public int Page { get; set; }

        public int Total { get; set; }
    }
}
