using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.EF;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class UnitOfWork: IUnitOfWork
    {
        private Context DataBase { get; }
        private ClientRepository _clientRepository;
        private OperationRepository _operationRepository;
        private OperatorRepository _operatorRepository;

        public UnitOfWork()
        {
            DataBase = new Context();
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new ClientRepository(DataBase);
                return _clientRepository;
            }
        }
        public IRepository<Operation> Operations
        {
            get
            {
                if (_operationRepository == null)
                    _operationRepository = new OperationRepository(DataBase);
                return _operationRepository;
            }
        }
        public IRepository<Operator> Operators
        {
            get
            {
                if (_operatorRepository == null)
                    _operatorRepository = new OperatorRepository(DataBase);
                return _operatorRepository;
            }
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
