using Brand.AdvertManagement.Model.DTO.Request;
using Brand.AdvertManagement.Model.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace Brand.AdvertManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertController : ControllerBase
    {
        public AdvertController()
        {
        }

        [HttpGet("all")]
        public async Task<AdvertListResponseDto> GetAdvertList([FromQuery] GetAdvertListByFilterRequestDto request)
        {
            AdvertListResponseDto response = new AdvertListResponseDto();
            return response;
        }
    }
}