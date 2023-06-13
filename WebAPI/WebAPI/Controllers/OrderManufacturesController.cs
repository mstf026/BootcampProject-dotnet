using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderManufacturesController : ControllerBase
    {
        private readonly IOrderManufactureService _orderManufactureService;

        public OrderManufacturesController(IOrderManufactureService stationOrderService)
        {
            _orderManufactureService = stationOrderService;
        }

        [HttpPost("manufacture/1/{orderId}")]
        public IActionResult ManufactureOrderSubpieceAtStationA(int orderId)
        {

            var result = _orderManufactureService.Add(orderId, 1);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("manufacture/2/{orderId}")]
        public IActionResult ManufactureOrderSubpieceAtStationB(int orderId)
        {

            var result = _orderManufactureService.Add(orderId, 2);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("manufacture/3/{orderId}")]
        public IActionResult ManufactureOrderSubpieceAtStationC(int orderId)
        {

            var result = _orderManufactureService.Add(orderId, 3);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("manufacture/4/{orderId}")]
        public IActionResult ManufactureOrderSubpieceAtStationD(int orderId)
        {

            var result = _orderManufactureService.Add(orderId, 4);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("manufacture/5/{orderId}")]
        public IActionResult ManufactureOrderSubpieceAtStationE(int orderId)
        {

            var result = _orderManufactureService.Add(orderId, 5);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


    }
}
