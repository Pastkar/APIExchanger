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
        private Context _dataBase { get; }
        private IRepository<Client> _clientRepository;
        private IRepository<Operation> _operationRepository;
        private IRepository<Operator> _operatorRepository;

        public UnitOfWork()
        {
            _dataBase = new Context();
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new ClientRepository(_dataBase);
                return _clientRepository;
            }
        }
        public IRepository<Operation> Operations
        {
            get
            {
                if (_operationRepository == null)
                    _operationRepository = new OperationRepository(_dataBase);
                return _operationRepository;
            }
        }
        public IRepository<Operator> Operators
        {
            get
            {
                if (_operatorRepository == null)
                    _operatorRepository = new OperatorRepository(_dataBase);
                return _operatorRepository;
            }
        }

        public void Save()
        {
            _dataBase.SaveChanges();
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }
    }
}
