using Brand.AdvertManagement.Entities;
using Brand.AdvertManagement.Model.DTO.Request;
using Brand.AdvertManagement.Model.DTO.Response;
using Brand.AdvertManagement.Repository;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Brand.AdvertManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly ICapPublisher _capPublisher;

        public AdvertController(IAdvertRepository advertRepository, ICapPublisher capPublisher)
        {
            _advertRepository = advertRepository;
            _capPublisher = capPublisher;
        }

        [HttpGet("all")]
        public async Task<ActionResult<AdvertListResponseDto>> GetAdvertList([FromQuery] GetAdvertListByFilterRequestDto request)
        {
            var response = await _advertRepository.GetAdvertList(request);
            if (response.Adverts.Count() < 1)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<AdvertResponseDto>> GetAdvert([FromQuery] GetAdvertRequestDto request)
        {
            var advert = await _advertRepository.GetAdvert(request);
            if (advert == null)
            {
                return NoContent();
            }

            return Ok(advert);
        }

        [HttpPost("visit")]
        public async Task<ActionResult> VisitAdvert([FromBody] VisitAdvertRequestDto request)
        {
            request.IPAddress = "127.0.0.1";
            request.VisitDate = DateTime.Now;

            await _capPublisher.PublishAsync("advert.visited", new VisitAdvertPublishModel(request.AdvertId, request.IPAddress, request.VisitDate));

            return Created(request.IPAddress, true);
        }

        [HttpPost("visited")]
        [CapSubscribe("advert.visited")]
        public async Task VisitedAdvert(VisitAdvertPublishModel request)
        {
            await _advertRepository.VisitAdvert(request);
        }
    }
}