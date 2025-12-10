using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transaction
{
    internal class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType.Type Type { get; set; }
        public string Description { get; set; }
        public Transaction(int id, decimal amount, DateTime date, TransactionType.Type type, string description)
        {
            Id = id;
            Amount = amount;
            Date = date;
            Type = type;
            Description = description;
        }
        public override string ToString()
        {
            return $"{Id}\t{Amount}\t{Date.DayOfYear}\t{Type}\t\t{Description}";
        }


    }
}
