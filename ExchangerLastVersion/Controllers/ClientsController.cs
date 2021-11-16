using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using BusinessLogic.Entities;
using AutoMapper;
using ExchangerLastVersion.Models;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using System.Net;

namespace ExchangerLastVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private IClientServices _clientService;
        private readonly IMapper _mapper;
        public ClientsController(IMapper mapper, IClientServices clientService)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            List<ClientModel> list = null;
            list = _mapper.Map<List<ClientModel>>(_clientService.ReadAll());

            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = _mapper.Map<ClientModel>(_clientService.ReadById(id));
            return Ok(client);
        }
        [HttpPost]
        public IActionResult AddClients([FromBody] ClientCreateModel model)
        {
            if (model == null)
                return BadRequest();

            var mappedCarBrand = _mapper.Map<ClientCreateBl>(model);
            _clientService.Create(mappedCarBrand);
            //_clientService client = new ClientCreateModel()
            //{
            //    Name = name,
            //    Surname = surname,
            //    BirthDay = birthDay,
            //    Adress = adress,
            //    Phone = phone,
            //    Passport = passport
            //};
            //_clientService.Create(_mapper.Map<ClientCreateBl>(client));
            //string name, string surname, string birthDay, string adress, int phone, int passport
            return StatusCode((int)HttpStatusCode.Created);    
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            if (_clientService.ReadById(id) == null)
                return NotFound();
            _clientService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientCreateModel model)
        {
            if (_clientService.ReadById(id) == null)
                return NotFound();
            //var newClient = new ClientCreateModel()
            //{
            //    Name = name,
            //    Surname = surname,
            //    BirthDay = birthDay,
            //    Adress = adress,
            //    Passport = passport,
            //    Phone = phone
            //};
            _clientService.UpdateClient(_mapper.Map<ClientCreateBl>(model),id);
            return Ok();
        }
    }
}
