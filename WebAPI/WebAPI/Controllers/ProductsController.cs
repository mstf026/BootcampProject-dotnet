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
        private readonly IMapper _mapper;
        private readonly IProductSubpieceService _productSubpieceService;
        public ProductsController(IProductService productService,
            IProductSubpieceService productSubpieceService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
            _productSubpieceService = productSubpieceService;
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

        [HttpGet("getlast")]
        public IActionResult GetLastProduct()
        {
            var result = _productService.GetLastProduct();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // POST: api/Products
        [HttpPost("add")]
        public IActionResult Add([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var result = _productService.Add(product);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("addsubpieces")]
        public IActionResult AddSubpieces(int[] subpieceId)
        {
            var result = _productSubpieceService.Add(subpieceId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST: api/Products
        [HttpPost("update")]
        public IActionResult Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
