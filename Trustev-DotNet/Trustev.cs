using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trustev_DotNet
{
    /// <summary>
    /// The Trustev Class is used to store you trustev credentials
    /// </summary>
    public abstract class Trustev
    {
        internal static string UserName { get; set; }
        internal static string Password { get; set; }
        internal static string Secret { get; set; }
        internal static string BaseUrl { get; set; }
        /// <summary>
        /// Initialize the trustev class by passing in you UserName, Secret and Password. If you do not have these then please contact integrationteam@trustev.com.
        /// </summary>
        /// <param name="userName">You Trustev UserName</param>
        /// <param name="password">You Trustev Password</param>
        /// <param name="secret">You Trustev Secret</param>
        public static void SetUp(string userName, string password, string secret)
        {
            UserName = userName;
            Password = password;
            Secret = secret;
            BaseUrl = "https://app.trustev.com/api/v2.0";
        }
    }
}
