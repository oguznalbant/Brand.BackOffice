namespace Brand.AdvertManagement.Model.DTO.Response
{
    public class AdvertListResponseDto : IPaginationResponse
    {
        public AdvertListResponseDto()
        {
        }

        public AdvertListResponseDto(int? page)
        {
            Page = page;
        }

        public AdvertListResponseDto(IEnumerable<AdvertListItemResponseDto> adverts)
        {
            Adverts = adverts;
        }

        /* Pagination */
        public int? Page { get; set; }
        public int Total { get; set; }

        public IEnumerable<AdvertListItemResponseDto> Adverts { get; set; }
    }
}