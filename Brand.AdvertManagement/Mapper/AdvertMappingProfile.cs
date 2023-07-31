using AutoMapper;
using Brand.AdvertManagement.Entities;
using Brand.AdvertManagement.Model.DTO.Response;

namespace Brand.AdvertManagement.Mapper
{
    public class AdvertMappingProfile : Profile
    {
        public AdvertMappingProfile()
        {
            CreateMap<Advert, AdvertResponseDto>().ReverseMap();
            CreateMap<Advert, AdvertListItemResponseDto>().ReverseMap();
        }
    }
}
