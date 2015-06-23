using System;

namespace Trustev.Domain.Entities
{
    public class Email
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public Boolean IsDefault { get; set; }
    }
}
