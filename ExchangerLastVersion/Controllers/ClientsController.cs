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
        private IClientServices _carBrandService;
        private readonly IMapper _mapper;
        //IRepositoryBL<ClientBl>
        public ClientsController(IMapper mapper, IClientServices carBrandService)
        {
            _carBrandService = carBrandService;
            _mapper = mapper;
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            List<ClientModel> list = null;
            list = _mapper.Map<List<ClientModel>>(_carBrandService.ReadAll());

            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = _mapper.Map<ClientModel>(_carBrandService.ReadById(id));
            return Ok(client);
        }
        [HttpPost]
        public IActionResult AddClients(string name, string surname, string birthDay, string adress, int phone, int passport)
        {
            //[FromBody] ClientCreateModel model
            //if (model == null)
            //    return BadRequest();

            //var mappedCarBrand = _mapper.Map<ClientCreateBl>(model);
            //_carBrandService.Create(mappedCarBrand);
            ClientCreateModel client = new ClientCreateModel()
            {
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Adress = adress,
                Phone = phone,
                Passport = passport
            };
            _carBrandService.Create(_mapper.Map<ClientCreateBl>(client));
            return StatusCode((int)HttpStatusCode.Created);    
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            if (_carBrandService.ReadById(id) == null)
                return NotFound();
            _carBrandService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, string name, string surname, string birthDay, string adress, int phone, int passport)
        {
            if (_carBrandService.ReadById(id) == null)
                return NotFound();
            var newClient = new ClientCreateModel()
            {
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Adress = adress,
                Passport = passport,
                Phone = phone
            };
            _carBrandService.UpdateClient(_mapper.Map<ClientCreateBl>(newClient),id);
            return Ok();
        }
    }
}
