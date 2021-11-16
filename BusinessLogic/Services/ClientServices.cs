
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer;

namespace BusinessLogic.Services
{
    public class ClientServices : IDisposable, IClientServices
    {
        private IUnitOfWork _dB;
        private readonly IMapper _mapper;
        public ClientServices(IMapper mapper)
        {
            _mapper = mapper;
            _dB = new UnitOfWork();
        }
        public void Create(ClientCreateBl clientToCreate)
        {
            var brand = _mapper.Map<Client>(clientToCreate);
            _dB.Clients.Create(brand);
            _dB.Save();
            //_dB.Clients.Create(_mapper.Map<Client>(item));
            //_dB.Save();
        }

        public void Dispose()
        {
            _dB.Dispose();
        }

        public IEnumerable<ClientBl> ReadAll()
        {
            //List<ClientBl> result = new List<ClientBl>();

            //foreach (var item in _dB.Clients.ReadAll())
            //{

            //    var test = _mapper.Map<ClientBl>(item);
            //    result.Add(_mapper.Map<ClientBl>(item));
            //    var t = true;
            //}
            var test = _dB.Clients.ReadAll();
            var result = _mapper.Map<IEnumerable<ClientBl>>(test);

            return result;
        }

        public void Delete(int id)
        {
            _dB.Clients.Delete(id);
            _dB.Save();
        }
        public ClientBl ReadById(int id)
        {
            var client = _dB.Clients.Read(id);
            var mapperClient = _mapper.Map<ClientBl>(client);
            return mapperClient;
        }

        public void UpdateClient(ClientCreateBl element,int id)
        {
            Client toUpdate = _dB.Clients.Read(id);

            if (toUpdate != null)
            {
                toUpdate = _mapper.Map<Client>(element);
                _dB.Clients.Update(toUpdate);
                _dB.Save();
            }
        }
    }
}
