    using System;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using BusinessLogic.Entities;
using AutoMapper;

namespace BusinessLogic
{
    public class BL : IDisposable
    {
        private UnitOfWork DB { get; }

        public BL()
        {
            DB = new UnitOfWork();
        }

        public void AddClient(ClientBl element)
        {
            DB.Clients.Create(Mapper.Map<Client>(element));
            DB.Save();
        }
        public void AddOperation(OperationBl element)
        {
            Client client = Mapper.Map<Client>(element.Clients);
            Operator opertor = Mapper.Map<Operator>(element.Operators);

            Operation operation = new Operation()
            {
                Clients = client,
                Operators = opertor,
                Date = element.Date,
                TypeOperations = (DataAccessLayer.Entities.TypeOperation)element.TypeOperations
            };

            DB.Operations.Create(operation);
            DB.Save();
        }
        public void AddOperator(OperatorBl element)
        {
            DB.Operators.Create(Mapper.Map<Operator>(element));
            DB.Save();
        }

        public void RemoveClient(int id)
        {
            DB.Clients.Delete(id);
            DB.Save();
        }
        public void RemoveOperarion(int id)
        {
            DB.Operations.Delete(id);
            DB.Save();
        }
        public void RemoveOperator(int id)
        {
            DB.Operators.Delete(id);
            DB.Save();
        }

        public void UpdateClient(ClientBl element)
        {
            Client toUpdate = DB.Clients.Read(element.Id);

            if (toUpdate != null)
            {
                toUpdate = Mapper.Map<Client>(element);
                DB.Clients.Update(toUpdate);
                DB.Save();
            }
        }
        public void UpdateOperation(OperatorBl element)
        {
            Operation toUpdate = DB.Operations.Read(element.Id);

            if (toUpdate != null)
            {
                toUpdate.Clients = DB.Clients.Read(element.Id);
                toUpdate.Operators = DB.Operators.Read(element.Id);
                //toUpdate.Date = element.Date;
                toUpdate.TypeOperations = toUpdate.TypeOperations;

                DB.Operations.Update(toUpdate);
                DB.Save();
            }
        }
        public void UpdateOperator(OperatorBl element)
        {
            Operator toUpdate = DB.Operators.Read(element.Id);

            if (toUpdate != null)
            {
                toUpdate = Mapper.Map<Operator>(element);
                DB.Operators.Update(toUpdate);
                DB.Save();
            }
        }

        public IEnumerable<ClientBl> GetClient()
        {
            List<ClientBl> result = new List<ClientBl>();

            foreach (var item in DB.Clients.ReadAll())
                result.Add(Mapper.Map<ClientBl>(item));

            return result;
        }
        public IEnumerable<OperationBl> GetOperation()
        {
            List<OperationBl> result = new List<OperationBl>();

            foreach (var item in DB.Operations.ReadAll())
            {
                result.Add(new OperationBl
                {
                        Clients = Mapper.Map<ClientBl>(item.Clients),
                        Operators = Mapper.Map<OperatorBl>(item.Operators),
                        //Date = item.Date,
                        TypeOperations = (BusinessLogic.Entities.TypeOperation)item.TypeOperations,
                        Id = item.Id
                    });;
            }

            return result;
        }
        public IEnumerable<OperatorBl> GetOperator()
        {
            List<OperatorBl> result = new List<OperatorBl>();

            foreach (var item in DB.Operators.ReadAll())
                result.Add(Mapper.Map<OperatorBl>(item));

            return result;
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
