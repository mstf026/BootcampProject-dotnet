using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // GET: api/orders/5
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // POST: api/orders
        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
