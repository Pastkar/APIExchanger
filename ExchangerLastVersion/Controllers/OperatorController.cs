using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using ExchangerLastVersion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExchangerLastVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : Controller
    {
        private IOperatorServices _operatorService;
        private readonly IMapper _mapper;
        public OperatorController(IMapper mapper, IOperatorServices operatorService)
        {
            _operatorService = operatorService;
            _mapper = mapper;
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            List<OperatorModel> list = null;
            list = _mapper.Map<List<OperatorModel>>(_operatorService.ReadAll());

            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _mapper.Map<OperatorModel>(_operatorService.ReadById(id));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddClients([FromBody] OperatorCreateModel model)
        {
            if (model == null)
                return BadRequest();

            var result = _mapper.Map<OperatorCreateBl>(model);
            _operatorService.Create(result);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOperaotr(int id)
        {
            if (_operatorService.ReadById(id) == null)
                return NotFound();
            _operatorService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] OperatorCreateModel model)
        {
            if (_operatorService.ReadById(id) == null)
                return NotFound();
            _operatorService.UpdateClient(_mapper.Map<OperatorCreateBl>(model), id);
            return Ok();
        }
    }
}
