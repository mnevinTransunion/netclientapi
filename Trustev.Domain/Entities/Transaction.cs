using System;
using System.Collections.Generic;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// Transaction Object - includes details such as Transaction Amount, Currency, Items and Transaction delivery/billing address.
    /// </summary>
    public class Transaction
    {
        public Transaction()
        {
            this.Addresses = new List<TransactionAddress>();
            this.Items = new List<TransactionItem>();
            this.Emails = new List<Email>();
            this.Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// This is the Transaction Id. This Id is returned when Transaction information has been added to a Trustev Case. This Id is required should you wish to update the Transaction details after a Trustev Case has been added. Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// Total Value of the Transaction.
        /// </summary>
        public decimal TotalTransactionValue { get; set; }

        /// <summary>
        /// Currency Type Code. Standard Currency Type codes can be found at http://www.xe.com/currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Current Utc DateTime. Defaults to DateTime.UtcNow
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Addresses Object – Contains standard/delivery/billing information. Please see Address Object for further parameter information.
        /// </summary>
        public IList<TransactionAddress> Addresses { get; set; }

        /// <summary>
        /// A collection of Emails. Please see Emails object for further parameter information.
        /// </summary>
        public IList<Email> Emails { get; set; }

        /// <summary>
        /// Items Object – contains details on Item Name, Quantity and Item Value. Please see Items Object for further parameter information.
        /// </summary>
        public IList<TransactionItem> Items { get; set; }
    }
}
