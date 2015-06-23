using System;

namespace Trustev.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Enums.PaymentType PaymentType { get; set; }
        public string BINNumber { get; set; }
    }
}
