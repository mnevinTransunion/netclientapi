using System;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// The CustomerAddress object outlines the customer address details.
    /// </summary>
    public class CustomerAddress
    {
        public CustomerAddress()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// This is the Address Id. This Id is returned when Address Information has been added to the Transaction object. This Id is required should you wish to update the Address details after a Trustev Case has been added. Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// The First Name for the Standard/Billing/Delivery Address.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The Last Name for the Standard/Billing/Delivery Address.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Address Line 1 for the Standard/Billing/Delivery Address.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address Line 2 for the Standard/Billing/Delivery Address.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Address Line 3 for the Standard/Billing/Delivery Address.
        /// </summary>
        public string Address3 { get; set; }

        /// <summary>
        /// City for the Standard/Billing/Delivery Address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State for the Standard/Billing/Delivery Address.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The Postal Code for the Standard/Billing/Delivery Address.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The Address Type – Standard (0), Billing (1), or Delivery (2)
        /// </summary>
        public Enums.AddressType Type { get; set; }

        /// <summary>
        /// These are the 2 letter country codes published by ISO. Details can be found at http://www.nationsonline.org/oneworld/countrycodes.htm
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Current UTC DateTime. Defaults to DateTime.UtcNow;
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Is this the default address?
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
