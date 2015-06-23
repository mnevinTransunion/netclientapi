using System;
using System.Collections.Generic;

namespace Trustev.Domain.Entities
{
    public class Case
    {
        /// <summary>
        /// Case constructor takes you sessionId and caseNumber as these are compulsory fields
        /// </summary>
        /// <param name="sessionId">This is your TrustevClient sessionId, This is available from the TrustevClient Javascript as a public variable TrustevV2.SessionId. It will need to be sent server side.</param>
        /// <param name="caseNumber">Your caseNumber. This is you unique idenitfier for thie Case.</param>
        public Case(Guid sessionId, string caseNumber)
        {
            SessionId = sessionId;
            CaseNumber = caseNumber;
            Statuses = new List<CaseStatus>();
            Payments = new List<Payment>();
        }

        public string Id { get; set; }
        public Guid SessionId { get; set; }
        public string CaseNumber { get; set; }
        public Transaction Transaction { get; set; }
        public Customer Customer { get; set; }
        public IList<CaseStatus> Statuses { get; set; }
        public IList<Payment> Payments { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
