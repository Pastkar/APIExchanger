using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IClientServices
    {
        void Create(ClientCreateBl clientToCreate);
        ClientBl ReadById(int id);
        IEnumerable<ClientBl> ReadAll();
        void Delete(int id);
        void UpdateClient(ClientCreateBl element,int id);
    }
}
