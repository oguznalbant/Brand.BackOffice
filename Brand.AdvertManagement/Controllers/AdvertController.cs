using Brand.AdvertManagement.Entities;
using Brand.AdvertManagement.Model.DTO.Request;
using Brand.AdvertManagement.Model.DTO.Response;
using Brand.AdvertManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Brand.AdvertManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertRepository _advertRepository;

        public AdvertController(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<AdvertListResponseDto>> GetAdvertList([FromQuery] GetAdvertListByFilterRequestDto request)
        {
            var list = await _advertRepository.GetAdvertList(request);
            if (list != null)
            {
                return NoContent();
            }

            return Ok(list);
        }

        [HttpGet("get")]
        public async Task<ActionResult<AdvertResponseDto>> GetAdvert([FromQuery] GetAdvertRequestDto request)
        {
            var advert = await _advertRepository.GetAdvert(request);
            if (advert != null)
            {
                return NoContent();
            }

            return Ok(advert);
        }

        [HttpPost("visit")]
        public async Task<ActionResult> VisitAdvert([FromQuery] VisitAdvertRequestDto request)
        {
            return Created("test","asd");
            //var requestedIP = Request.Headers;
        }
    }
}