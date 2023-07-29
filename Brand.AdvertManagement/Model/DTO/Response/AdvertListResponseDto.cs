namespace Brand.AdvertManagement.Model.DTO.Response
{
    public class AdvertListResponseDto : IPaginationResponse
    {
        public AdvertListResponseDto()
        {
        }

        public AdvertListResponseDto(IEnumerable<AdvertDto> Adverts)
        {
            this.Adverts = Adverts;
        }

        public IEnumerable<AdvertDto> Adverts { get; set; }

        /* Pagination */
        public int Page { get; set; }
        public int Total { get; set; }
    }
}