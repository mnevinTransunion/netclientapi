using System;
using System.Collections.Generic;

namespace Trustev.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            Emails = new List<Email>();
            Addresses = new List<CustomerAddress>();
            SocialAccounts = new List<SocialAccount>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Email> Emails { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<CustomerAddress> Addresses { get; set; }
        public IList<SocialAccount> SocialAccounts { get; set; }
    }
}
