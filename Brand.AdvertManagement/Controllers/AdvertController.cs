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
        public async Task<ActionResult<AdvertListResponseDto>> GetAdvertList([FromQuery] GetAdvertListByFilterRequestDto request)
        {
            AdvertListResponseDto response = new AdvertListResponseDto();
            return Ok(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<AdvertResponseDto>> GetAdvert([FromQuery] GetAdvertRequestDto request)
        {
            AdvertResponseDto response = new AdvertResponseDto();
            return Ok(response);
        }

        [HttpPost("visit")]
        public async Task<ActionResult> VisitAdvert([FromQuery] VisitAdvertRequestDto request)
        {
            return Ok();
            //var requestedIP = Request.Headers;
        }
    }
}