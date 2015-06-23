using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trustev_DotNet.Exceptions;

namespace Trustev_DotNet.Entities.Internal
{
    internal class Token : BaseEntity
    {
        private static string APIToken { get; set; }
        private static DateTime ExpiryDate { get; set; }

        internal async static Task<string> GetTokenAsync()
        {
            if (string.IsNullOrEmpty(APIToken) || ExpiryDate > DateTime.UtcNow)
            {
                await SetTokenAsync();
            }

            return APIToken;
        }

        internal static string GetToken()
        {
            if (string.IsNullOrEmpty(APIToken) || ExpiryDate > DateTime.UtcNow)
            {
                SetToken();
            }

            return APIToken;
        }

        private static void SetToken()
        {
            CheckCredentials();

            DateTime currentTime = DateTime.UtcNow;

            TokenRequest requestObject = new TokenRequest()
            {
                UserName = Trustev.UserName,
                PasswordHash = PasswordHashHelper(Trustev.Password, Trustev.Secret, currentTime),
                UserNameHash = UserNameHashHelper(Trustev.UserName, Trustev.Secret, currentTime),
                TimeStamp = currentTime.ToString("o")
            };

            string requestJson = JsonConvert.SerializeObject(requestObject);

            string uri = string.Format("{0}/token", Trustev.BaseUrl);

            TokenResponse response = PerformHttpCall<TokenResponse>(uri, HttpMethod.Post, requestJson, false);

            APIToken = response.APIToken;
            ExpiryDate = response.ExpiryDate;
        }

        private async static Task SetTokenAsync()
        {
            CheckCredentials();

            DateTime currentTime = DateTime.UtcNow;

            TokenRequest requestObject = new TokenRequest()
            {
                UserName = Trustev.UserName,
                PasswordHash = PasswordHashHelper(Trustev.Password, Trustev.Secret, currentTime),
                UserNameHash = UserNameHashHelper(Trustev.UserName, Trustev.Secret, currentTime),
                TimeStamp = currentTime.ToString("o")
            };

            string requestJson = JsonConvert.SerializeObject(requestObject);

            string uri = string.Format("{0}/token", Trustev.BaseUrl);

            TokenResponse response = await PerformHttpCallAsync<TokenResponse>(uri, HttpMethod.Post, requestJson, false);

            APIToken = response.APIToken;
            ExpiryDate = response.ExpiryDate;
        }

        /// <summary>
        /// Trustev token response object
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

        #region Private Methods

        /// <summary>
        /// Check that the user has set the Trustev Credentials correctly
        /// </summary>
        private static void CheckCredentials()
        {
            if (string.IsNullOrEmpty(Trustev.UserName) || string.IsNullOrEmpty(Trustev.Secret) || string.IsNullOrEmpty(Trustev.Password))
            {
                throw new TrustevGeneralException("You have not set your Trustev credentials correctly. You need to set these by calling the SetUp method on the Trustev Class providing your UserName, Password and Secret as the paramters before you can access the Trustev API");
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
