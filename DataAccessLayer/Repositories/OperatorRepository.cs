using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.EF;

namespace DataAccessLayer.Repositories
{
    public class OperatorRepository  : IRepository<Operator>
    {
        private readonly Context _dB;

        public OperatorRepository(Context context)
        {
            _dB = context;
        }

        public IEnumerable<Operator> ReadAll()
        {
            return _dB.Operators;
        }
        public Operator Read(int id)
        {
            return _dB.Operators.Find(id);
        }
        public void Create(Operator operetor)
        {
            _dB.Operators.Add(operetor);
        }
        public void Update(Operator operetor, int id)
        {
            var previousOperator = _dB.Operators.Find(id);

            if (previousOperator != null)
            {
                _dB.Operators.Remove(previousOperator);
                Operator newOperator = new Operator()
                {
                    Name = operetor.Name,
                    Surname = operetor.Surname,
                    Adress = operetor.Adress,
                    Phone = operetor.Phone
                };

                _dB.Operators.Add(newOperator);
            }
        }
        public void Delete(int id)
        {
            var operetor = _dB.Operators.Find(id);
            if (operetor != null)
                _dB.Operators.Remove(operetor);
        }
    }
}
