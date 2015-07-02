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
            /// <summary>
            /// This result should not be returned to you. It means that an error has occurred and a Trustev Decision has not been made on your Trustev Case.
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// This result indicates that the Trustev Case shows no signs for suspicion and the 'transaction' should be accepted.
            /// </summary>
            Pass,

            /// <summary>
            /// This result indicates that the Trustev Case contains elements for suspicion which should be reviewed before a final decision is made.
            /// </summary>
            Flag,

            /// <summary>
            /// This result indicates that the Trustev Case contains a number of fraudulent features and the 'transaction' should be rejected.
            /// </summary>
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
            /// <summary>
            /// None Payment Type
            /// </summary>
            None,

            /// <summary>
            /// Credit Card Payment
            /// </summary>
            CreditCard,

            /// <summary>
            /// Debit Card Payment
            /// </summary>
            DebitCard,

            /// <summary>
            /// Direct Debit Payment
            /// </summary>
            DirectDebit,

            /// <summary>
            /// PayPal Payment
            /// </summary>
            PayPal,

            /// <summary>
            /// BitCoin Payment
            /// </summary>
            Bitcoin
        }

        public enum SocialNetworkType
        {
            /// <summary>
            /// Facebook Social Network
            /// </summary>
            Facebook,

            /// <summary>
            /// Twitter Social Network
            /// </summary>
            Twitter,

            /// <summary>
            /// LinkedIn Social Network
            /// </summary>
            LinkedIn,

            /// <summary>
            /// Trustev Social Network
            /// </summary>
            Trustev,

            /// <summary>
            /// TrustevSession Social Network
            /// </summary>
            TrustevSession
        }

        public enum AddressType
        {
            /// <summary>
            /// Standard Address Type
            /// </summary>
            Standard,

            /// <summary>
            /// Billing Address Type
            /// </summary>
            Billing,

            /// <summary>
            /// Delivery Address Type
            /// </summary>
            Delivery
        }
    }
}
