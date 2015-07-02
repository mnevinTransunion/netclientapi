using System;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// Items Object – contains details on Item Name, Quantity and Item Value. Please see Items Object for further parameter information.
    /// </summary>
    public class TransactionItem
    {
        /// <summary>
        /// This is the Item Id. This Id is returned when Item Information has been added to the Transaction object. This Id is required should you wish to update the Item details after a Trustev Case has been added. Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// The Name of the Item being purchased.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Quantity of the Item being purchased.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The Value of the Item being purchased.
        /// </summary>
        public decimal ItemValue { get; set; }
    }
}
