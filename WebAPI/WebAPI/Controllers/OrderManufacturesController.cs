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
        private readonly IOrderManufactureService _stationOrderService;
        private readonly IProductService _productService;
        private readonly IDepartmentService _departmentService;

        public OrderManufacturesController(
            IOrderManufactureService stationOrderService,
            IProductService productService,
            IDepartmentService departmentService)
        {
            _stationOrderService = stationOrderService;
            _productService = productService;
            _departmentService = departmentService;
        }

        [HttpPost("manufacture/{orderId}/{stationId}")]
        public IActionResult ManufactureOrderSubpieceAtStation(int orderId, int stationId)
        {

            var result = _stationOrderService.Add(orderId, stationId);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
