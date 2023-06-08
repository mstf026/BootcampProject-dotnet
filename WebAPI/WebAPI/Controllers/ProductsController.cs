using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProduct_SubpieceService _productSubpieceService;
        private readonly ISubpieceService _subpieceService;
        private readonly IMapper _mapper;
        public ProductsController(
            IProductService productService,
            IProduct_SubpieceService productSubpieceService,
            IMapper mapper,
            ISubpieceService subpieceService)
        {
            _productService = productService;
            _mapper = mapper;
            _productSubpieceService = productSubpieceService;
            _subpieceService = subpieceService;
        }

        // GET: api/Products
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return  BadRequest(result);
        }

        // GET: api/Products/5
        [HttpGet("getbyunitprice")]
        public IActionResult GetByUnitPrice(decimal min, decimal max)
        {
            var result = _productService.GetByUnitPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // GET: api/Products/5
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // POST: api/Products
        [HttpPost("add")]
        public IActionResult Add([FromQuery]int[] subpieceId, [FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            decimal Cost = 0;
            foreach (var s in subpieceId)
            {
                Cost += _subpieceService.GetById(s).Data.Cost;
            }

            Cost *= (decimal)1.1;
            product.Price = Cost;

            var result = _productService.Add(product);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            foreach (var s in subpieceId)
            {
                var subpieceresult = _productSubpieceService.Add(new Product_Subpiece()
                {
                    ProductId = product.Id,
                    SubpieceId = s
                });
                if (!subpieceresult.Success)
                {
                    return BadRequest(subpieceresult);
                }
                
            }
            
            return Ok(result);
        }

        // POST: api/Products
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
