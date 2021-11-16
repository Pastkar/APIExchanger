using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.EF;

namespace DataAccessLayer.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly Context _dB;

        public ClientRepository(Context context)
        {
            _dB = context;
        }

        public IEnumerable<Client> ReadAll()
        {
            return _dB.Clients;
        }
        public Client Read(int id)
        {
            return _dB.Clients.Find(id);
        }
        public void Create(Client client)
        {
            _dB.Clients.Add(client);
        }
        public void Update(Client client, int id)
        {
            var previousClient= _dB.Clients.Find(id);

            if (previousClient != null)
            {
                _dB.Clients.Remove(previousClient);
                Client newClient = new Client()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    BirthDay = client.BirthDay,
                    Adress = client.Adress,
                    Phone = client.Phone
                };

                _dB.Clients.Add(newClient);
            }
        }
        public void Delete(int id)
        {
            Client client = _dB.Clients.Find(id);
            if (client != null)
                _dB.Clients.Remove(client);
        }
    }
}
