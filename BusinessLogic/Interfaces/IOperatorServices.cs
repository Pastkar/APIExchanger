using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IOperatorServices 
    {
        void Create(OperatorCreateBl clientToCreate);
        OperatorBl ReadById(int id);
        IEnumerable<OperatorBl> ReadAll();
        void Delete(int id);
        void UpdateClient(OperatorCreateBl element, int id);
    }
}
