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
        private Context DB;

        public OperatorRepository(Context context)
        {
            DB = context;
        }

        public IEnumerable<Operator> ReadAll()
        {
            return DB.Operators;
        }
        public Operator Read(int id)
        {
            return DB.Operators.Find(id);
        }
        public void Create(Operator operetor)
        {
            DB.Operators.Add(operetor);
        }
        public void Update(Operator operetor)
        {
            var previousOperator = DB.Operators.Find(operetor.Id);

            if (previousOperator != null)
            {
                DB.Operators.Remove(previousOperator);
                Operator newOperator = new Operator()
                {
                   
                };

                DB.Operators.Add(newOperator);
            }
        }
        public void Delete(int id)
        {
            Operator operetor = DB.Operators.Find(id);
            if (operetor != null)
                DB.Operators.Remove(operetor);
        }
    }
}
