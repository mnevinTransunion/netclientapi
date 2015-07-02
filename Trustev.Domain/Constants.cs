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
        public const string UriCustomerUdpate = "{0}/case/{1}/customer";

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
        public const string UriTransactionUdpate = "{0}/case/{1}/transaction";

        /// <summary>
        /// Get Transaction Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriTransactionGet = "{0}/case/{1}/transaction";

        /// <summary>
        /// Post Email Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriEmailPost = "{0}/case/{1}/customer/email";

        /// <summary>
        /// Update Email Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Email you want to Update
        /// </summary>
        public const string UriEmailUdpate = "{0}/case/{1}/customer/email/{2}";

        /// <summary>
        /// Get Email Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Email you want to Get
        /// </summary>
        public const string UriEmailGet = "{0}/case/{1}/customer/email/{2}";

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
        /// Post Social Account Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        public const string UriSocialAccountPost = "{0}/case/{1}/customer/socialaccount";

        /// <summary>
        /// Update Social Account Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Social Account you want to Update
        /// </summary>
        public const string UriSocialAccountUpdate = "{0}/case/{1}/customer/socialaccount/{2}";

        /// <summary>
        /// Get Social Account Api Endpoint
        /// 0 : The TrustevClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Social Account you want to Get
        /// </summary>
        public const string UriSocialAccountGet = "{0}/case/{1}/customer/socialaccount/{2}";

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
    }
}
