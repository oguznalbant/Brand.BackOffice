namespace Brand.AdvertManagement.Model.DTO.Request
{
    public class GetAdvertListByFilterRequestDto : IPaginationRequest
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

        public IList<string>? CategoryId { get; set; }
        public IList<string>? Fuel { get; set; }
        public IList<string>? Gear { get; set; }

        public string? Sort { get; set; }

        /* Pagination */
        public int? Page { get; set; } = 1;
    }
}