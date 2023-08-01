using Brand.AdvertManagement.Model.DTO.Request;
using Brand.AdvertManagement.Model.DTO.Response;

namespace Brand.AdvertManagement.Repository
{
    public interface IAdvertRepository
    {
        Task<AdvertResponseDto> GetAdvert(GetAdvertRequestDto requestDto);

        Task<AdvertListResponseDto> GetAdvertList(GetAdvertListByFilterRequestDto requestDto);

        Task VisitAdvert(VisitAdvertPublishModel publishModel);
    }
}
