using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Entities
{
    public class OperationBl
    {
        public int Id { get; set; }
        public ClientBl Clients { get; set; }
        public DateTime Date { get; set; }
        public OperatorBl Operators { get; set; }
        public TypeOperation TypeOperations { get; set; }
    }

    public enum TypeOperation
    {
        Sell, Buy
    }
}
