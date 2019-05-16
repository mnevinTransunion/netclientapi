using System;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// The Email object
    /// </summary>
    public class Email
    {
        /// <summary>
        /// This is the Email Id. This Id is returned when an Email Address has been added. This Id is required should you wish to update the Email details after a Trustev Case has been added. Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// Email Address of the customer
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Is this is the default email for the customer?
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
