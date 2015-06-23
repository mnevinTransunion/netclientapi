using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trustev.Domain
{
    public class Enums
    {
        public enum DecisionResult
        {
            Unknown = 0,

            Pass,

            Flag,

            Fail
        }

        public enum CaseStatusType
        {
            /// <summary>
            /// Order Completed
            /// </summary>
            Completed,

            /// <summary>
            /// Order Rejected due to Fraud
            /// </summary>
            RejectedFraud,

            /// <summary>
            /// Order Rejected due to Card Authentication Failure
            /// </summary>
            RejectedAuthFailure,

            /// <summary>
            /// Order Rejected due to suspect Fraud
            /// </summary>
            RejectedSuspicious,

            /// <summary>
            /// Order Cancelled
            /// </summary>
            Cancelled,

            /// <summary>
            /// Return of funds to customer due to Fraud
            /// </summary>
            ChargebackFraud,

            /// <summary>
            /// Return of funds to customer for other reasons
            /// </summary>
            ChargebackOther,

            /// <summary>
            /// Customer refunded
            /// </summary>
            Refunded,

            /// <summary>
            /// Order has been placed on system
            /// </summary>
            Placed,

            /// <summary>
            /// Order is under review, no decision made yet
            /// </summary>
            OnHoldReview
        }

        public enum PaymentType
        {
            None,
            CreditCard,
            DebitCard,
            DirectDebit,
            PayPal,
            Bitcoin
        }

        public enum SocialNetworkType
        {
            Facebook,
            Twitter,
            LinkedIn,
            Trustev,
            TrustevSession
        }
    }
}
