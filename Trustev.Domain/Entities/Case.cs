using System;
using System.Collections.Generic;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// The Case Object is the what Trustev bases its decision on. It is a container for all the information that can be provided.
    /// The more information that you provide us with the more accurate or decision so please populate as much as possible
    /// </summary>
    public class Case
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Case"/> class
        /// </summary>
        /// <param name="sessionId">This is your TrustevClient sessionId, This is available from the TrustevClient JavaScript as a public variable TrustevV2.SessionId. It will need to be sent server side.</param>
        /// <param name="caseNumber">Your caseNumber. This is you unique identifier for this Case.</param>
        public Case(Guid sessionId, string caseNumber)
        {
            this.SessionId = sessionId;
            this.CaseNumber = caseNumber;
            this.Statuses = new List<CaseStatus>();
            this.Payments = new List<Payment>();
            this.Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// This is the Case Id. The CaseId is returned once a Trustev Case has been created. It is required when getting a Trustev Decision on a Trustev Case, when updating a Case Status, and anytime you wish to update Trustev Case information.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Case Type of Current Case - E.g. Default, Account Creation, Application
        /// </summary>
        public Enums.CaseType CaseType { get; set; }

        /// <summary>
        /// SessionId is required when adding a Trustev Case. SessionId is available through Trustev.js as a publicly accessible variable - TrustevV2.SessionId
        /// </summary>
        public Guid SessionId { get; set; }

        /// <summary>
        /// The CaseNumber is chosen by the Merchant to uniquely identify the Trustev Case. It can be an alphanumeric string of your liking. Please see our Testing Guide to find out how to use the CaseNumber to get expected Trustev Decisions during Integration.
        /// </summary>
        public string CaseNumber { get; set; }

        /// <summary>
        /// Transaction Object - includes details such as Transaction Amount, Currency, Items and Transaction delivery/billing address.
        /// </summary>
        public Transaction Transaction { get; set; }

        /// <summary>
        /// Customer Object - includes details like First/Last name of Customer, address details, phone numbers, email addresses. Social details may also be included here where available. Please see Customer object for further parameter information.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// A Status includes the Order Status and a Comment section. Trustev require that a Status is attached to a Trustev Case so that we can learn from the decision that you make on a Trustev Case.
        /// </summary>
        public IList<CaseStatus> Statuses { get; set; }

        /// <summary>
        /// Payments includes forwarding the Payment Type (Credit/Debit Card, PayPal…), and the BIN/IIN Number of the relevant card should it be available.
        /// </summary>
        public IList<Payment> Payments { get; set; }

        /// <summary>
        /// Current UTC DateTime. Defaults to DateTime.UtcNow;
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
