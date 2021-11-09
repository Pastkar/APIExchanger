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
        private Context DB;

        public OperationRepository(Context context)
        {
            DB = context;
        }

        public IEnumerable<Operation> ReadAll()
        {
            return DB.Operations;
        }
        public Operation Read(int id)
        {
            return DB.Operations.Find(id);
        }
        public void Create(Operation game)
        {
            DB.Operations.Add(game);
        }
        public void Update(Operation game)
        {
            
        }
        public void Delete(int id)
        {
            Operation game = DB.Operations.Find(id);
            if (game != null)
                DB.Operations.Remove(game);
        }
    }
}
