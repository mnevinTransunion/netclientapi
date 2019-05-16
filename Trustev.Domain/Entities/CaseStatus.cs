using System;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// The CaseStatus class is used to let Trustev know the current status of any case. When the status of a Case changes, please update the status of the case.
    /// </summary>
    public class CaseStatus
    {
        public CaseStatus()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// This is the Status Id. This Id is returned in the response header of the Add a Case method, when Status Information has been added. This Id is required should you wish to retrieve the Status details after a Trustev Case has been added. Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// The Status Type of the Trustev Case
        /// </summary>
        public Enums.CaseStatusType Status { get; set; }

        /// <summary>
        /// Comment on the Status
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Current UTC DateTime. Defaults to DateTime.UtcNow;
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
