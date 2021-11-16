using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class ClientCreateBl
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public int Passport { get; set; }
    }
}
