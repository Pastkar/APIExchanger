using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.EF;

namespace DataAccessLayer.Repositories
{
    public class OperationRepository : IRepository<Operation>
    {
        private readonly Context _dB;

        public OperationRepository(Context context)
        {
            _dB = context;
        }

        public IEnumerable<Operation> ReadAll()
        {
            return _dB.Operations;
        }
        public Operation Read(int id)
        {
            return _dB.Operations.Find(id);
        }
        public void Create(Operation game)
        {
            _dB.Operations.Add(game);
        }
        public void Update(Operation game,int id    )
        {
            
        }
        public void Delete(int id)
        {
            Operation game = _dB.Operations.Find(id);
            if (game != null)
                _dB.Operations.Remove(game);
        }
    }
}
