using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        public Client Clients { get; set; }
        public DateTime Date { get; set; }
        public Operator Operators { get; set; }
        public TypeOperation TypeOperations { get; set; }
    }

    public enum TypeOperation
    {
        Sell, Buy
    }
}
