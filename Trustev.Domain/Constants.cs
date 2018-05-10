using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trustev.Domain
{
    public class Constants
    {
        /// <summary>
        /// The GetDecision Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you want a Decision on.
        /// </summary>
        public const string UriDecisionGet = "{0}/decision/{1}";

        /// <summary>
        /// The GetDetailedDecision Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you want a DetailedDecision on.
        /// </summary>
        public const string UriDetailedDecisionGet = "{0}/detaileddecision/{1}";

        /// <summary>
        /// The OTP Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you want a DetailedDecision on.
        /// </summary>
        public const string UriOtp = "{0}/case/{1}/authentication/otp";

        /// <summary>
        /// Post Case Api Endpoint.
        /// 0 : The TrustevClient Base Url
        /// </summary>
        public const string UriSessionPost = "{0}/session";

        /// <summary>
        /// Post Case Api Endpoint.
        /// 0 : The TrustevClient Base Url
        /// </summary>
        public const string UriDetailPost = "{0}/session/{1}/detail";

        /// <summary>
        /// Post Case Api Endpoint.
        /// 0 : The TrustevClient Base Url
        /// </summary>
        public const string UriCasePost = "{0}/case";

        /// <summary>
        /// Update Case Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you want to Update.
        /// </summary>
        public const string UriCaseUpdate = "{0}/case/{1}";

        /// <summary>
        /// Get Case Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you want to Get.
        /// </summary>
        public const string UriCaseGet = "{0}/case/{1}";

        /// <summary>
        /// Post Customer Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCustomerPost = "{0}/case/{1}/customer";

        /// <summary>
        /// Update Customer Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCustomerUpdate = "{0}/case/{1}/customer";

        /// <summary>
        /// Get Customer Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCustomerGet = "{0}/case/{1}/customer";

        /// <summary>
        /// Post Transaction Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriTransactionPost = "{0}/case/{1}/transaction";

        /// <summary>
        /// Update Transaction Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriTransactionUpdate = "{0}/case/{1}/transaction";

        /// <summary>
        /// Get Transaction Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriTransactionGet = "{0}/case/{1}/transaction";

        /// <summary>
        /// Post Customer Email Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCustomerEmailPost = "{0}/case/{1}/customer/email";

        /// <summary>
        /// Update Customer Email Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Email you want to Update
        /// </summary>
        public const string UriCustomerEmailUpdate = "{0}/case/{1}/customer/email/{2}";

        /// <summary>
        /// Get Customer Email Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Email you want to Get
        /// </summary>
        public const string UriCustomerEmailGet = "{0}/case/{1}/customer/email/{2}";

        /// <summary>
        /// Get Customer Email Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCustomerEmailsGet = "{0}/case/{1}/customer/email";

        /// <summary>
        /// Post CaseStatus Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCaseStatusPost = "{0}/case/{1}/status";

        /// <summary>
        /// Get CaseStatus Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Email you want to Get
        /// </summary>
        public const string UriCaseStatusGet = "{0}/case/{1}/status/{2}";

        /// <summary>
        /// Get CaseStatuses Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCaseStatusesGet = "{0}/case/{1}/status";

        /// <summary>
        /// Post Payment Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriPaymentPost = "{0}/case/{1}/payment";

        /// <summary>
        /// Update Payment Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Payment you want to Update
        /// </summary>
        public const string UriPaymentUpdate = "{0}/case/{1}/payment/{2}";

        /// <summary>
        /// Get Payment Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Payment you want to Get
        /// </summary>
        public const string UriPaymentGet = "{0}/case/{1}/payment/{2}";

        /// <summary>
        /// Get Payments Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriPaymentsGet = "{0}/case/{1}/payment";

        /// <summary>
        /// Post Customer Address Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCustomerAddressPost = "{0}/case/{1}/customer/address";

        /// <summary>
        /// Update Customer Address Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Customer Address you want to Update
        /// </summary>
        public const string UriCustomerAddressUpdate = "{0}/case/{1}/customer/address/{2}";

        /// <summary>
        /// Get Customer Address Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Customer Address you want to Get
        /// </summary>
        public const string UriCustomerAddressGet = "{0}/case/{1}/customer/address/{2}";

        /// <summary>
        /// Get Customer Addresses Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriCustomerAddressesGet = "{0}/case/{1}/customer/address";

        /// <summary>
        /// Post Transaction Item Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriTransactionItemPost = "{0}/case/{1}/transaction/item";

        /// <summary>
        /// Update Transaction Item Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Transaction Item you want to Update
        /// </summary>
        public const string UriTransactionItemUpdate = "{0}/case/{1}/transaction/item/{2}";

        /// <summary>
        /// Get Transaction Item Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Transaction Item you want to Get
        /// </summary>
        public const string UriTransactionItemGet = "{0}/case/{1}/transaction/item/{2}";

        /// <summary>
        /// Get Transaction Items Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriTransactionItemsGet = "{0}/case/{1}/transaction/item";

        /// <summary>
        /// Post Transaction Address Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriTransactionAddressPost = "{0}/case/{1}/transaction/address";

        /// <summary>
        /// Update Transaction Address Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Transaction Address you want to Update
        /// </summary>
        public const string UriTransactionAddressUpdate = "{0}/case/{1}/transaction/address/{2}";

        /// <summary>
        /// Get Transaction Address Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Transaction Address you want to Get
        /// </summary>
        public const string UriTransactionAddressGet = "{0}/case/{1}/transaction/address/{2}";

        /// <summary>
        /// Get Transaction Addresses Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriTransactionAddressesGet = "{0}/case/{1}/transaction/address";

        /// <summary>
        /// Post KBA Answer Api Endpoint.
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriKBAResultPost = "{0}/case/{1}/authentication/kba";
    }
}
