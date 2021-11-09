using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ExchangerLastVersion.Models
{
    public class OperationModel
    {
        public int Id { get; set; }
        public ClientModel Clients { get; set; }
        public DateTime Date { get; set; }
        public OperatorModel Operators { get; set; }
        public TypeOperation TypeOperations { get; set; }
    }

    public enum TypeOperation
    {
        Sell, Buy
    }
}
