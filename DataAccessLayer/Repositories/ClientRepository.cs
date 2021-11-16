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
        private Context DB;

        public ClientRepository(Context context)
        {
            DB = context;
        }

        public IEnumerable<Client> ReadAll()
        {
            return DB.Clients;
        }
        public Client Read(int id)
        {
            return DB.Clients.Find(id);
        }
        public void Create(Client client)
        {
            DB.Clients.Add(client);
        }
        public void Update(Client client, int id)
        {
            var previousClient= DB.Clients.Find(id);

            if (previousClient != null)
            {
                DB.Clients.Remove(previousClient);
                Client newClient = new Client()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    BirthDay = client.BirthDay,
                    Adress = client.Adress,
                    Phone = client.Phone
                };

                DB.Clients.Add(newClient);
            }
        }
        public void Delete(int id)
        {
            Client client = DB.Clients.Find(id);
            if (client != null)
                DB.Clients.Remove(client);
        }
    }
}
