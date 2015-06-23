using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trustev
{
    public class Constants
    {
        /// <summary>
        /// The GetDecison Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you want a Decision on.
        /// </summary>
        internal const string URI_DECISON_GET = "{0}/decision/{1}";

        /// <summary>
        /// Post Case Api Endpoint.
        /// 0 : The ApiClient Base Url
        /// </summary>
        internal const string URI_CASE_POST = "{0}/case";

        /// <summary>
        /// Update Case Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you want to Update.
        /// </summary>
        internal const string URI_CASE_UPDATE = "{0}/case/{1}";

        /// <summary>
        /// Get Case Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you want to Get.
        /// </summary>
        internal const string URI_CASE_GET = "{0}/case/{1}";

        /// <summary>
        /// Post Customer Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_CUSTOMER_POST = "{0}/case/{1}/customer";

        /// <summary>
        /// Update Customer Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_CUSTOMER_UDPATE = "{0}/case/{1}/customer";

        /// <summary>
        /// Get Customer Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_CUSTOMER_GET = "{0}/case/{1}/customer";

        /// <summary>
        /// Post Transaction Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_TRANSACTION_POST = "{0}/case/{1}/transaction";

        /// <summary>
        /// Update Transaction Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_TRANSACTION_UDPATE = "{0}/case/{1}/transaction";

        /// <summary>
        /// Get Transaction Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_TRANSACTION_GET = "{0}/case/{1}/transaction";

        /// <summary>
        /// Post Email Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_EMAIL_POST = "{0}/case/{1}/customer/email";

        /// <summary>
        /// Update Email Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Email you want to Update
        /// </summary>
        internal const string URI_EMAIL_UDPATE = "{0}/case/{1}/customer/email/{2}";

        /// <summary>
        /// Get Email Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Email you want to Get
        /// </summary>
        internal const string URI_EMAIL_GET = "{0}/case/{1}/customer/email/{2}";

        /// <summary>
        /// Post CaseStatus Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_CASESTATUS_POST = "{0}/case/{1}/status";

        /// <summary>
        /// Get CaseStatus Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Email you want to Get
        /// </summary>
        internal const string URI_CASESTATUS_GET = "{0}/case/{1}/status/{2}";

        /// <summary>
        /// Post Payment Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_PAYMENT_POST = "{0}/case/{1}/payment";

        /// <summary>
        /// Update Payment Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Payment you want to Update
        /// </summary>
        internal const string URI_PAYMENT_UPDATE = "{0}/case/{1}/payment/{2}";

        /// <summary>
        /// Get Payment Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Payment you want to Get
        /// </summary>
        internal const string URI_PAYMENT_GET = "{0}/case/{1}/payment/{2}";

        /// <summary>
        /// Post Customer Address Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_CUSTOMERADDRESS_POST = "{0}/case/{1}/customer/address";

        /// <summary>
        /// Update Customer Address Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Customer Address you want to Update
        /// </summary>
        internal const string URI_CUSTOMERADDRESS_UPDATE = "{0}/case/{1}/customer/address/{2}";

        /// <summary>
        /// Get Customer Address Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Customer Address you want to Get
        /// </summary>
        internal const string URI_CUSTOMERADDRESS_GET = "{0}/case/{1}/customer/address/{2}";

        /// <summary>
        /// Post Transaction Item Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_TRANSACTIONITEM_POST = "{0}/case/{1}/transaction/item";

        /// <summary>
        /// Update Transaction Item Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Transaction Item you want to Update
        /// </summary>
        internal const string URI_TRANSACTIONITEM_UPDATE = "{0}/case/{1}/transaction/item/{2}";

        /// <summary>
        /// Get Transaction Item Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Transaction Item you want to Get
        /// </summary>
        internal const string URI_TRANSACTIONITEM_GET = "{0}/case/{1}/transaction/item/{2}";

        /// <summary>
        /// Post Social Account Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_SOCIALACCOUNT_POST = "{0}/case/{1}/customer/socialaccount";

        /// <summary>
        /// Update Social Account Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Social Account you want to Update
        /// </summary>
        internal const string URI_SOCIALACCOUNT_UPDATE = "{0}/case/{1}/customer/socialaccount/{2}";

        /// <summary>
        /// Get Social Account Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Social Account you want to Get
        /// </summary>
        internal const string URI_SOCIALACCOUNT_GET = "{0}/case/{1}/customer/socialaccount/{2}";

        /// <summary>
        /// Post Transaction Address Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// </summary>
        internal const string URI_TRANSACTIONADDRESS_POST = "{0}/case/{1}/transaction/address";

        /// <summary>
        /// Update Transaction Address Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Transaction Address you want to Update
        /// </summary>
        internal const string URI_TRANSACTIONADDRESS_UPDATE = "{0}/case/{1}/transaction/address/{2}";

        /// <summary>
        /// Get Transaction Address Api Endpoint
        /// 0 : The ApiClient Base Url
        /// 1 : The Case Id of the Case you have already added.
        /// 2 : The Id of the Transaction Address you want to Get
        /// </summary>
        internal const string URI_TRANSACTIONADDRESS_GET = "{0}/case/{1}/transaction/address/{2}";
    }
}
