using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Update(T item,int id);
        void Delete(int id);
    }
}
