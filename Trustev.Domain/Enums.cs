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
            OnHoldReview,

            /// <summary>
            /// Order deemed fraudulent after it was fulfilled
            /// </summary>
            ReportedFraud = 12
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

        public enum CaseType
        {
            Default,
            AccountCreation = 2,
            Application
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
		
         /// <summary>
        /// TimeToFulfilment
        /// </summary>
        public enum TimeToFulfilment
        {
            /// <summary>
            /// Undefined
            /// </summary>
            Undefined,
            /// <summary>
            /// Immediate
            /// </summary>
            Immediate,
            /// <summary>
            /// Same Day
            /// </summary>
            SameDay,
            /// <summary>
            ///  Next Day
            /// </summary>
            NextDay,
            /// <summary>
            /// Up To 3 Days,
            /// </summary>
            UpTo3Days,
            /// <summary>
            /// Up To 5 Days
            /// </summary>
            UpTo5Days
        }

        /// <summary>
        /// Fulfilment Method
        /// </summary>
        public enum FulfilmentMethod
        {
            /// <summary>
            /// Undefined
            /// </summary>
            Undefined,
            /// <summary>
            /// Virtual
            /// </summary>
            Virtual,
            /// <summary>
            /// In Person
            /// </summary>
            InPerson,
            /// <summary>
            /// Post
            /// </summary>
            Post,
            /// <summary>
            /// Courier
            /// </summary>
            Courier
        }

        /// <summary>
        /// Fulfilment GeoLocation
        /// </summary>
        public enum FulfilmentGeoLocation
        {
            /// <summary>
            /// Undefined
            /// </summary>
            Undefined,
            /// <summary>
            /// National Location
            /// </summary>
            National,
            /// <summary>
            /// International Location
            /// </summary>
            International
        }

        public enum BaseUrl
        {
            EU,
            US,
            Local
        }

        /// <summary>
        /// Enum for the KBAData Status Codes
        /// </summary>
        public enum KBAStatus
        {
            /// <summary>
            /// KBA Status is NotConfigured
            /// </summary>
            NotConfigured = -1,

            /// <summary>
            /// KBA Status is Offered
            /// </summary>
            Offered = 0,

            /// <summary>
            /// KBA Status is MultiPassOffered
            /// </summary>
            MultiPassOffered = 1,
            /// <summary>
            /// KBA Status is Ineligible
            /// </summary>
            Ineligible = 2,

            /// <summary>
            /// KBA Status is NoData
            /// </summary>
            NoData = 3,

            /// <summary>
            /// KBA Status is Passed
            /// </summary>
            Passed = 4,

            /// <summary>
            /// KBA Status is Failed
            /// </summary>
            Failed = 5,

            /// <summary>
            /// KBA Status is Abbandoned
            /// </summary>
            Abbandoned = 6,
        }

        /// <summary>
        /// Enum for the KBAData MultiPass Status Codes
        /// </summary>
        public enum MultiPassStatus
        {
            /// <summary>
            /// MultiPass is not Enabled or configured
            /// </summary>
            NotEnabled = -1,

            /// <summary>
            /// MultiPass is not Used
            /// </summary>
            NotUsed = 0,

            /// <summary>
            /// MultiPass is Used
            /// </summary>
            Used = 1,

            /// <summary>
            /// MultiPass is in use
            /// </summary>
            Using = 2,
        }
    }
}
