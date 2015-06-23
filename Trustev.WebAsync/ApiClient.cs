using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trustev.Domain;
using Trustev.Domain.Entities;
using Trustev.Domain.Exceptions;

namespace Trustev.WebAsync
{
    /// <summary>
    /// The ApiClient Class is used to store you trustev credentials
    /// </summary>
    public static class ApiClient
    {
        private static string UserName { get; set; }
        private static string Password { get; set; }
        private static string Secret { get; set; }
        private static string BaseUrl { get; set; }
        private static string APIToken { get; set; }
        private static DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Initialize the trustev class by passing in you UserName, Secret and Password. If you do not have these then please contact integrationteam@trustev.com.
        /// </summary>
        /// <param name="userName">You ApiClient UserName</param>
        /// <param name="password">You ApiClient Password</param>
        /// <param name="secret">You ApiClient Secret</param>
        public static void SetUp(string userName, string password, string secret)
        {
            UserName = userName;
            Password = password;
            Secret = secret;
            BaseUrl = "https://app.trustev.com/api/v2.0";
        }

        /// <summary>
        /// Post your Case to the TrustevClient Api asynchronously
        /// </summary>
        /// <param name="kase">Your Case which you want to post</param>
        /// <returns>The Case along with the Id that TrustevClient have assigned it</returns>
        public static async Task<Case> PostCaseAsync(Case kase)
        {
            string uri = String.Format(Constants.URI_CASE_POST, BaseUrl);

            Case responseCase = await PerformHttpCallAsync<Case>(uri, HttpMethod.Post, kase);

            return responseCase;
        }


        /// <summary>
        /// Update your Case with caseId provided with the new Case object asynchronously
        /// </summary>
        /// <param name="kase">Your Case which you want to Put and update the exisiting case with</param>
        /// <param name="caseId">The Case Id of the case you want to update. TrustevClient will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static async Task<Case> UpdateCaseAsync(Case kase, string caseId)
        {
            string uri = String.Format(Constants.URI_CASE_UPDATE, BaseUrl, caseId);

            Case response = await PerformHttpCallAsync<Case>(uri, HttpMethod.Put, kase);

            return response;
        }

        /// <summary>
        /// Get the Case with the Id caseId
        /// </summary>
        /// <param name="caseId">The case Id of the Case you want to get. TrustevClient will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static async Task<Case> GetCaseAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_CASE_GET, BaseUrl, caseId);

            Case response = await PerformHttpCallAsync<Case>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a Decision on a Case with Id caseId.
        /// </summary>
        /// <param name="caseId">The Id of a Case which you have already posted to the TrustevClient API.</param>
        /// <returns></returns>
        public static async Task<Decision> GetDecisionAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_DECISON_GET, BaseUrl, caseId);

            Decision decision = await PerformHttpCallAsync<Decision>(uri, HttpMethod.Get, null);

            decision.CaseId = caseId;

            return decision;
        }

        /// <summary>
        /// Post your Customer to an existing Case
        /// </summary>
        /// <param name="customer">Your Customer which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns>The Customer along with the Id that TrustevClient have assigned it</returns>
        public static async Task<Customer> PostCustomerAsync(string caseId, Customer customer)
        {
            string uri = String.Format(Constants.URI_CUSTOMER_POST, BaseUrl, caseId);

            Customer response = await PerformHttpCallAsync<Customer>(uri, HttpMethod.Post, customer);

            return response;
        }

        /// <summary>
        /// Update the Customer on a Case which already contains a customer
        /// </summary>
        /// <param name="customer">Your Customer which you want to Put and update the exisiting Customer with</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Customer> UpdateCustomerAsync(string caseId, Customer customer)
        {
            string uri = String.Format(Constants.URI_CUSTOMER_UDPATE, BaseUrl, caseId);

            Customer response = await PerformHttpCallAsync<Customer>(uri, HttpMethod.Put, customer);

            return response;
        }

        /// <summary>
        /// Get the Customer attached to the Case
        /// </summary>
        /// <param name="caseId">The case Id of the the Case with the Customer you want to get</param>
        /// <returns></returns>
        public static async Task<Customer> GetCustomerAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_CUSTOMER_GET, BaseUrl, caseId);

            Customer response = await PerformHttpCallAsync<Customer>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Post your Transaction to an existing Case
        /// </summary>
        /// <param name="transaction">Your Transaction which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns>The Transaction along with the Id that TrustevClient have assigned it</returns>
        public static async Task<Transaction> PostTransactionAsync(string caseId, Transaction transaction)
        {
            string uri = String.Format(Constants.URI_TRANSACTION_POST, BaseUrl, caseId);

            Transaction response = await PerformHttpCallAsync<Transaction>(uri, HttpMethod.Post, transaction);

            return response;
        }


        /// <summary>
        /// Update the Transaction on a Case which already contains a transaction
        /// </summary>
        /// <param name="transaction">Your Transaction which you want to Put and update the exisiting Transaction with</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Transaction> UpdateTransactionAsync(string caseId, Transaction transaction)
        {
            string uri = String.Format(Constants.URI_TRANSACTION_UDPATE, BaseUrl, caseId);

            Transaction response = await PerformHttpCallAsync<Transaction>(uri, HttpMethod.Put, transaction);

            return response;
        }

        /// <summary>
        /// Get the Transaction attached to the Case
        /// </summary>
        /// <param name="caseId">The case Id of the the Case with the Transaction you want to get</param>
        /// <returns></returns>
        public static async Task<Transaction> GetTransactionAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_TRANSACTION_GET, BaseUrl, caseId);

            Transaction response = await PerformHttpCallAsync<Transaction>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Post your CaseStatus to an existing Case
        /// </summary>
        /// <param name="caseStatus">Your CaseStatus which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<CaseStatus> PostCaseStatusAsync(string caseId, CaseStatus caseStatus)
        {
            string uri = String.Format(Constants.URI_CASESTATUS_POST, BaseUrl, caseId);

            CaseStatus response = await PerformHttpCallAsync<CaseStatus>(uri, HttpMethod.Post, caseStatus);

            return response;
        }

        /// <summary>
        /// Get a specific status from a Case
        /// </summary>
        /// <param name="caseStatusId">The Id of the CaseStatus you want to get</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<CaseStatus> GetCaseStatusAsync(string caseId, Guid caseStatusId)
        {
            string uri = String.Format(Constants.URI_CASESTATUS_GET, BaseUrl, caseId, caseStatusId);

            CaseStatus response = await PerformHttpCallAsync<CaseStatus>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<CaseStatus>> GetCaseStatusesAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_CASESTATUS_GET, BaseUrl, caseId, "");

            IList<CaseStatus> response = await PerformHttpCallAsync<IList<CaseStatus>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Post your CustomerAddress to an existing Customer on an existing Case
        /// </summary>
        /// <param name="customerAddress">Your CustomerAddress which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<CustomerAddress> PostCustomerAddressAsync(string caseId, CustomerAddress customerAddress)
        {
            string uri = String.Format(Constants.URI_CUSTOMERADDRESS_POST, BaseUrl, caseId);

            CustomerAddress response = await PerformHttpCallAsync<CustomerAddress>(uri, HttpMethod.Post, customerAddress);

            return response;
        }

        /// <summary>
        /// Update a specific CustomerAddress on a Case which already contains a CustomerAddresses
        /// </summary>
        /// <param name="customerAddressId">The id of the CustomerAddress you want to update</param>
        /// <param name="customerAddress">The CustomerAddress you want to update the exisiting CustomerAddress to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<CustomerAddress> UpdateCustomerAddressAsync(string caseId, CustomerAddress customerAddress, Guid customerAddressId)
        {
            string uri = String.Format(Constants.URI_CUSTOMERADDRESS_UPDATE, BaseUrl, caseId, customerAddressId);

            CustomerAddress response = await PerformHttpCallAsync<CustomerAddress>(uri, HttpMethod.Put, customerAddress);

            return response;
        }

        /// <summary>
        /// Get a specific customerAddress from a Case
        /// </summary>
        /// <param name="customerAddressId">The Id of the CustomerAddress you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<CustomerAddress> GetCustomerAddressAsync(string caseId, Guid customerAddressId)
        {
            string uri = String.Format(Constants.URI_CUSTOMERADDRESS_GET, BaseUrl, caseId, customerAddressId);

            CustomerAddress response = await PerformHttpCallAsync<CustomerAddress>(uri, HttpMethod.Get, null);

            return response;
        }


        /// <summary>
        /// Get a all the addresses from a Customer on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<CustomerAddress>> GetCustomerAddressesAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_CUSTOMERADDRESS_GET, BaseUrl, caseId, "");

            IList<CustomerAddress> response = await PerformHttpCallAsync<IList<CustomerAddress>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Post your Email to an existing Customer on an existing Case
        /// </summary>
        /// <param name="email">Your Email which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<Email> PostEmailAsync(string caseId, Email email)
        {
            string uri = String.Format(Constants.URI_EMAIL_POST, BaseUrl, caseId);

            Email response = await PerformHttpCallAsync<Email>(uri, HttpMethod.Post, email);

            return response;
        }

        /// <summary>
        /// Update a specific Email on a Case which already contains a Email
        /// </summary>
        /// <param name="emailId">The id of the Email you want to update</param>
        /// <param name="email">The Email you want to update the exisiting Email to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Email> UpdateAsync(string caseId, Email email, Guid emailId)
        {
            string uri = String.Format(Constants.URI_EMAIL_UDPATE, BaseUrl, caseId, emailId);

            Email response = await PerformHttpCallAsync<Email>(uri, HttpMethod.Put, email);

            return response;
        }

        /// <summary>
        /// Get a specific Email from a Case
        /// </summary>
        /// <param name="emailId">The Id of the Email you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<Email> GetEmailAsync(string caseId, Guid emailId)
        {
            string uri = String.Format(Constants.URI_EMAIL_GET, BaseUrl, caseId, emailId);

            Email response = await PerformHttpCallAsync<Email>(uri, HttpMethod.Get, null);

            return response;
        }
        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<Email>> GetEmailsAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_EMAIL_GET, BaseUrl, caseId, "");

            IList<Email> response = await PerformHttpCallAsync<IList<Email>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Post your Payment to an existing Case
        /// </summary>
        /// <param name="payment">Your Payment which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Payment> PostPaymentAsync(string caseId, Payment payment)
        {
            string uri = String.Format(Constants.URI_PAYMENT_POST, BaseUrl, caseId);

            Payment response = await PerformHttpCallAsync<Payment>(uri, HttpMethod.Post, payment);

            return response;
        }

        /// <summary>
        /// Update a specific Payment on a Case which already contains a Payments
        /// </summary>
        /// <param name="paymentId">The id of the Payment you want to update</param>
        /// <param name="payment">The Payment you want to update the exisiting Payment to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Payment> UpdatePaymentAsync(string caseId, Payment payment, Guid paymentId)
        {
            string uri = String.Format(Constants.URI_PAYMENT_UPDATE, BaseUrl, caseId, paymentId);

            Payment response = await PerformHttpCallAsync<Payment>(uri, HttpMethod.Put, payment);

            return response;
        }

        /// <summary>
        /// Get a specific Payment from a Case
        /// </summary>
        /// <param name="paymentId">The Id of the Payment you want to get</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Payment> GetPaymentAsync(string caseId, Guid paymentId)
        {
            string uri = String.Format(Constants.URI_PAYMENT_GET, BaseUrl, caseId, paymentId);

            Payment response = await PerformHttpCallAsync<Payment>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the Payments from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<Payment>> GetPaymentAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_PAYMENT_GET, BaseUrl, caseId, "");

            IList<Payment> response = await PerformHttpCallAsync<IList<Payment>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Post your SocialAccount to an existing Customer on an existing Case
        /// </summary>
        /// <param name="socialAccount">Your SocialAccount which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<SocialAccount> PostSocialAccountAsync(string caseId, SocialAccount socialAccount)
        {
            string uri = String.Format(Constants.URI_SOCIALACCOUNT_POST, BaseUrl, caseId);

            SocialAccount response = await PerformHttpCallAsync<SocialAccount>(uri, HttpMethod.Post, socialAccount);

            return response;
        }

        /// <summary>
        /// Update a specific SocialAccount on a Case which already contains a SocialAccount
        /// </summary>
        /// <param name="socialAccountId">The id of the SocialAccount you want to update</param>
        /// <param name="socialAccount">The SocialAccount you want to update the exisiting SocialAccount to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<SocialAccount> UpdateSocialAccountAsync(string caseId, SocialAccount socialAccount, Guid socialAccountId)
        {
            string uri = String.Format(Constants.URI_SOCIALACCOUNT_UPDATE, BaseUrl, caseId, socialAccountId);

            SocialAccount response = await PerformHttpCallAsync<SocialAccount>(uri, HttpMethod.Put, socialAccount);

            return response;
        }

        /// <summary>
        /// Get a specific SocialAccount from a Case
        /// </summary>
        /// <param name="socialAccountId">The Id of the SocialAccount you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<SocialAccount> GetSocialAccountAsync(string caseId, Guid socialAccountId)
        {
            string uri = String.Format(Constants.URI_SOCIALACCOUNT_GET, BaseUrl, caseId, socialAccountId);

            SocialAccount response = await PerformHttpCallAsync<SocialAccount>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the socialAccounts from a Customer on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<SocialAccount>> GetSocialAccountsAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_SOCIALACCOUNT_GET, BaseUrl, caseId, "");

            IList<SocialAccount> response = await PerformHttpCallAsync<IList<SocialAccount>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Post your TransactionAddress to an existing Transaction on an existing Case
        /// </summary>
        /// <param name="transactionAddress">Your TransactionAddress which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionAddress> PostTransactionAddressAsync(string caseId, TransactionAddress transactionAddress)
        {
            string uri = String.Format(Constants.URI_TRANSACTIONADDRESS_POST, BaseUrl, caseId);

            TransactionAddress response = await PerformHttpCallAsync<TransactionAddress>(uri, HttpMethod.Post, transactionAddress);

            return response;
        }

        /// <summary>
        /// Update a specific TransactionAddress on a Case which already contains a TransactionAddress
        /// </summary>
        /// <param name="transactionAddressId">The id of the TransactionAddress you want to update</param>
        /// <param name="transactionAddress">The TransactionAddress you want to update the exisiting TransactionAddress to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionAddress> UpdateTransactionAddressAsync(string caseId, TransactionAddress transactionAddress, Guid transactionAddressId)
        {
            string uri = String.Format(Constants.URI_TRANSACTIONADDRESS_UPDATE, BaseUrl, caseId, transactionAddressId);

            TransactionAddress response = await PerformHttpCallAsync<TransactionAddress>(uri, HttpMethod.Put, transactionAddress);

            return response;
        }


        /// <summary>
        /// Get a specific TransactionAddress from a Case
        /// </summary>
        /// <param name="transactionAddressId">The Id of the TransactionAddress you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionAddress> GetTransactionAddressAsync(string caseId, Guid transactionAddressId)
        {
            string uri = String.Format(Constants.URI_TRANSACTIONADDRESS_GET, BaseUrl, caseId, transactionAddressId);

            TransactionAddress response = await PerformHttpCallAsync<TransactionAddress>(uri, HttpMethod.Get, null);

            return response;
        }


        /// <summary>
        /// Get a all the addresses from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<TransactionAddress>> GetTransactionAddresssesAsync(string caseId)
        {
            string uri = String.Format(Constants.URI_TRANSACTIONADDRESS_GET, BaseUrl, caseId, "");

            IList<TransactionAddress> response = await PerformHttpCallAsync<IList<TransactionAddress>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Post your TransactionItem to an existing Transaction on an existing Case
        /// </summary>
        /// <param name="transactionItem">Your TransactionItem which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionItem> PostTransactionItemAsync(string caseId, TransactionItem transactionItem)
        {
            string uri = String.Format(Constants.URI_TRANSACTIONITEM_POST, BaseUrl, caseId);

            TransactionItem response = await PerformHttpCallAsync<TransactionItem>(uri, HttpMethod.Post, transactionItem);

            return response;
        }

        /// <summary>
        /// Update a specific TransactionItem on a Case which already contains a TransactionItem
        /// </summary>
        /// <param name="transactionItemId">The id of the TransactionItem you want to update</param>
        /// <param name="transactionItem">The TransactionAddress you want to update the exisiting TransactionItem to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionItem> UpdateTransactionItemAsync(string caseId, TransactionItem transactionItem, Guid transactionItemId)
        {
            string uri = String.Format(Constants.URI_TRANSACTIONITEM_UPDATE, BaseUrl, caseId, transactionItemId);

            TransactionItem response = await PerformHttpCallAsync<TransactionItem>(uri, HttpMethod.Put, transactionItem);

            return response;
        }

        /// <summary>
        /// Get a specific TransactionItem from a Case
        /// </summary>
        /// <param name="transactionItemId">The Id of the TransactionItem you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionItem> GetTransactionItemAsync(string caseId, Guid transactionItemId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_GET, BaseUrl, caseId, transactionItemId);

            TransactionItem response = await PerformHttpCallAsync<TransactionItem>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the TransacitonItems from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<TransactionItem>> GetTransactionItemsAsync(string caseId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_GET, BaseUrl, caseId, "");

            IList<TransactionItem> response = await PerformHttpCallAsync<IList<TransactionItem>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// This method asynchronously performs the Http Request to the Trustev API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="entity"></param>
        /// <param name="IsAuthenticationNeeded"></param>
        /// <returns></returns>
        private static async Task<T> PerformHttpCallAsync<T>(string uri, HttpMethod method, object entity, bool IsAuthenticationNeeded = true)
        {
            HttpClient client = new HttpClient();

            if (IsAuthenticationNeeded)
            {
                client.DefaultRequestHeaders.Add("X-Authorization", UserName + " " + await GetTokenAsync());
            }

            HttpResponseMessage response = new HttpResponseMessage();

            string json = "";

            if (entity != null && entity.GetType() != typeof(string))
            {
                json = JsonConvert.SerializeObject(entity);
            }
            else
            {
                json = (string)entity;
            }

            if (method == HttpMethod.Post)
            {
                response = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            }
            else if (method == HttpMethod.Put)
            {
                response = await client.PutAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            }
            else if (method == HttpMethod.Get)
            {
                response = await client.GetAsync(uri);
            }

            string resultstring = "";

            if (response.IsSuccessStatusCode)
            {
                resultstring = await response.Content.ReadAsStringAsync();
            }
            else
            {
                resultstring = await response.Content.ReadAsStringAsync();

                throw new TrustevHttpException(response.StatusCode, resultstring);
            }

            return JsonConvert.DeserializeObject<T>(resultstring); ;
        }

        #region Private Methods

        internal async static Task<string> GetTokenAsync()
        {
            if (string.IsNullOrEmpty(APIToken) || ExpiryDate > DateTime.UtcNow)
            {
                await SetTokenAsync();
            }

            return APIToken;
        }

        private async static Task SetTokenAsync()
        {
            CheckCredentials();

            DateTime currentTime = DateTime.UtcNow;

            TokenRequest requestObject = new TokenRequest()
            {
                UserName = UserName,
                PasswordHash = PasswordHashHelper(Password, Secret, currentTime),
                UserNameHash = UserNameHashHelper(UserName, Secret, currentTime),
                TimeStamp = currentTime.ToString("o")
            };

            string requestJson = JsonConvert.SerializeObject(requestObject);

            string uri = string.Format("{0}/token", BaseUrl);

            TokenResponse response = await PerformHttpCallAsync<TokenResponse>(uri, HttpMethod.Post, requestJson, false);

            APIToken = response.APIToken;
            ExpiryDate = response.ExpiryDate;
        }

        /// <summary>
        /// TrustevClient token response object
        /// </summary>
        private class TokenRequest
        {
            public string UserName { get; set; }
            public string PasswordHash { get; set; }
            public string UserNameHash { get; set; }
            public string TimeStamp { get; set; }
        }

        private class TokenResponse
        {
            public string APIToken { get; set; }
            public DateTime ExpiryDate { get; set; }
        }

        /// <summary>
        /// Check that the user has set the TrustevClient Credentials correctly
        /// </summary>
        private static void CheckCredentials()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Secret) || string.IsNullOrEmpty(Password))
            {
                throw new TrustevGeneralException("You have not set your TrustevClient credentials correctly. You need to set these by calling the SetUp method on the TrustevClient Class providing your UserName, Password and Secret as the paramters before you can access the TrustevClient API");
            }
        }

        /// <summary>
        /// Has password, secret and timestamp for GetToken request
        /// </summary>
        /// <param name="password"></param>
        /// <param name="sharedsecret"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        private static string PasswordHashHelper(string password, string sharedsecret, DateTime timestamp)
        {
            sharedsecret = sharedsecret.Replace("\"", "");
            password = password.Replace("\"", "");
            return Create256Hash(Create256Hash(timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + "." + password) + "." + sharedsecret);
        }

        /// <summary>
        /// Has username, secret and timestamp for GetToken request
        /// </summary>
        /// <param name="username"></param>
        /// <param name="sharedsecret"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>

        private static string UserNameHashHelper(string username, string sharedsecret, DateTime timestamp)
        {
            sharedsecret = sharedsecret.Replace("\"", "");
            username = username.Replace("\"", "");
            return Create256Hash(Create256Hash(timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + "." + username) + "." + sharedsecret);
        }


        private static string Create256Hash(string toHash)
        {
            HashAlgorithm sha = new SHA256Managed();

            byte[] tohashBytes = Encoding.UTF8.GetBytes(toHash);
            byte[] resultBytes = sha.ComputeHash(tohashBytes);

            return HexEncode(resultBytes);
        }

        private static string HexEncode(byte[] data)
        {
            string result = "";
            foreach (byte b in data)
            {
                result += b.ToString("X2");
            }
            result = result.ToLower();

            return (result);

        }

        #endregion
    }
}
