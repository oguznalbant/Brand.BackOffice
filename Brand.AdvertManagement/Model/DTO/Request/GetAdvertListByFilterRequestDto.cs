namespace Brand.AdvertManagement.Model.DTO.Request
{
    public class GetAdvertListByFilterRequestDto : IPaginationRequest
    {
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Gear { get; set; }
        public string Fuel { get; set; }

        /* Pagination */
        public int Page { get; set; }
    }
}