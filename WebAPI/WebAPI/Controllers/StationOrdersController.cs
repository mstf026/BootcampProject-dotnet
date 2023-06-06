using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationOrdersController : ControllerBase
    {
        private readonly IStationOrderService _stationOrderService;

        public StationOrdersController(IStationOrderService stationOrderService)
        {
            _stationOrderService = stationOrderService;
        }

        // GET: api/stationorders
        [HttpGet("getallsubpieces")]
        public IActionResult GetAllSubpiecesByStationId()
        {
            var result = _stationOrderService.GetAllSubpiecesByStationId();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
