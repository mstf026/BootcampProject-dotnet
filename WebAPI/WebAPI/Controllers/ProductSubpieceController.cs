using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSubpieceController : ControllerBase
    {
        private readonly IProductSubpieceService _productSubpieceService;

        public ProductSubpieceController(IProductSubpieceService productSubpieceService)
        {
            _productSubpieceService = productSubpieceService;
        }

        // GET: api/product_subpieces
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productSubpieceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // GET: api/product_subpieces/5
        [HttpGet("getbyid")]
        public IActionResult GetByProductId(int productId)
        {
            var result = _productSubpieceService.GetByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
