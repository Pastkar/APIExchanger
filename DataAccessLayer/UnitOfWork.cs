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
        private ClientRepository clientRepository;
        private OperationRepository operationRepository;
        private OperatorRepository operatorRepository;

        public UnitOfWork()
        {
            DataBase = new Context();
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(DataBase);
                return clientRepository;
            }
        }
        public IRepository<Operation> Operations
        {
            get
            {
                if (operationRepository == null)
                    operationRepository = new OperationRepository(DataBase);
                return operationRepository;
            }
        }
        public IRepository<Operator> Operators
        {
            get
            {
                if (operatorRepository == null)
                    operatorRepository = new OperatorRepository(DataBase);
                return operatorRepository;
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
