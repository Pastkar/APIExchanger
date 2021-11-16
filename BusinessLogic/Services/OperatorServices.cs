using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class OperatorServices : IRepositoryBl<OperatorBl,OperatorCreateBl>,IDisposable
    {
        private IUnitOfWork _dB;
        private readonly IMapper _mapper;

        public OperatorServices(IMapper mapper)
        {
            _mapper = mapper;
            _dB = new UnitOfWork();
        }
        public void Create(OperatorCreateBl element)
        {
            var @operator = _mapper.Map<Operator>(element);
            _dB.Operators.Create(@operator);
            _dB.Save();
        }

        public void Delete(int id)
        {
            _dB.Operators.Delete(id);
            _dB.Save();
        }

        public IEnumerable<OperatorBl> ReadAll()
        {
            var operators = _dB.Operators.ReadAll();
            var result = _mapper.Map<IEnumerable<OperatorBl>>(operators);

            return result;
        }

        public OperatorBl ReadById(int id)
        {
            var @operator = _dB.Operators.Read(id);
            var result = _mapper.Map<OperatorBl>(@operator);
            return result;
        }

        public void Update(OperatorCreateBl element, int id)
        {
            var toUpdate = _dB.Operators.Read(id);

            if (toUpdate != null)
            {
                toUpdate = _mapper.Map<Operator>(element);
                _dB.Operators.Update(toUpdate, id);
                _dB.Save();
            }
        }

        public void Dispose()
        {
            _dB.Dispose();
        }
    }
}
