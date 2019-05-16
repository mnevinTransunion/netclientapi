using System;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// Payments includes forwarding the Payment Type (Credit/Debit Card, PayPal…), and the BIN/IIN Number of the relevant card should it be available.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// This is the Payment Id. This Id is returned when a Payment has been added. This Id is required should you wish to update the Payment details after a Trustev Case has been added. Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// The type of Payment method used
        /// </summary>
        public Enums.PaymentType PaymentType { get; set; }

        /// <summary>
        /// The BIN Number - the first 6 digits of a Debit/Credit Card Number.
        /// </summary>
        public string BINNumber { get; set; }
    }
}
