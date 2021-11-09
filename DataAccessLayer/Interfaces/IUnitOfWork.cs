using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Client> Clients { get; }
        IRepository<Operation> Operations { get; }
        IRepository<Operator> Operators { get; }
        void Save();
    }
}
