using System;
using System.Collections.Generic;

namespace Trustev.Domain.Entities
{
    public class Transaction
    {
        public Transaction()
        {
            Addresses = new List<TransactionAddress>();
            Items = new List<TransactionItem>();
        }

        public Guid Id { get; set; }
        public decimal TotalTransactionValue { get; set; }
        public string Currency { get; set; }
        public DateTime Timestamp { get; set; }
        public IList<TransactionAddress> Addresses { get; set; }
        public IList<TransactionItem> Items { get; set; }
    }
}
