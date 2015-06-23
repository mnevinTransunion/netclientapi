using System;

namespace Trustev.Domain.Entities
{
    public class TransactionItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal ItemValue { get; set; }

    }
}
