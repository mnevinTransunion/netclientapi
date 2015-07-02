using System;
using System.Collections.Generic;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// The Customer object include the information on a customer such as address, names, email, phone number and social information
    /// </summary>
    public class Customer
    {
        public Customer()
        {
            this.Emails = new List<Email>();
            this.Addresses = new List<CustomerAddress>();
            this.SocialAccounts = new List<SocialAccount>();
        }

        /// <summary>
        /// This is the Customer Id. This Id is returned when Customer Information has been added. This Id is required should you wish to update the Customer details after a Trustev Case has been added. Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// The First Name of the Customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The Last Name of the Customer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// A collection of Emails. Please see Emails object for further parameter information.
        /// </summary>
        public IList<Email> Emails { get; set; }

        /// <summary>
        /// The Phone Number for the Customer.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The Date of Birth of the Customer
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Addresses Object – Contains standard/delivery/billing information. Please see Address Object for further parameter information.
        /// </summary>
        public IList<CustomerAddress> Addresses { get; set; }

        /// <summary>
        /// Social Account Object – Contains Short Term and Long Term Access Tokens, along with Social Account Ids and Types. See Trustev Integration Documentation, http://developers.trustev.com/v2 for more information.
        /// </summary>
        public IList<SocialAccount> SocialAccounts { get; set; }
    }
}
