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
    public class SubpiecesController : ControllerBase
    {
        private readonly ISubpieceService _subpieceService;
        private readonly IMapper _mapper;

        public SubpiecesController(ISubpieceService subpieceService,IMapper mapper)
        {
            _subpieceService = subpieceService;
            _mapper = mapper;
        }

        // GET: api/subpieces
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _subpieceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // GET: api/subpieces/5
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _subpieceService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // POST: api/subpieces
        [HttpPost("add")]
        public IActionResult Add([FromQuery]SubpieceDto subpieceDto)
        {
            var subpiece = _mapper.Map<Subpiece>(subpieceDto);
            var result = _subpieceService.Add(subpiece);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
