using Brand.AdvertManagement.Model.DTO.Request;
using Brand.AdvertManagement.Model.DTO.Response;

namespace Brand.AdvertManagement.Repository
{
    public class AdvertRepository : IAdvertRepository
    {
        public async Task<AdvertResponseDto> GetAdvert(GetAdvertRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AdvertListResponseDto> GetAdvertList(GetAdvertListByFilterRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task VisitAdvert(VisitAdvertRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
