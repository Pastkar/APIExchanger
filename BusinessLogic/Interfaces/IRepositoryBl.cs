using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    //T - model
    //N - model for create and update
    public interface IRepositoryBl<T,N> where T : class
        where N : class
    {
        void Create(N element);
        T ReadById(int id);
        IEnumerable<T> ReadAll();
        void Delete(int id);
        void Update(N element, int id);
    }
}
