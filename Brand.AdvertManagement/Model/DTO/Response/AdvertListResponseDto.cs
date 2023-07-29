namespace Brand.AdvertManagement.Model.DTO.Response
{
    public class AdvertListResponseDto : IPaginationResponse
    {
        public AdvertListResponseDto()
        {
        }

        public AdvertListResponseDto(IEnumerable<AdvertListItemResponseDto> adverts)
        {
            Adverts = adverts;
        }

        public IEnumerable<AdvertListItemResponseDto> Adverts { get; set; }

        /* Pagination */
        public int Page { get; set; }
        public int Total { get; set; }
    }
}