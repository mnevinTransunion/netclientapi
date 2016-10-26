using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain;
using Trustev.WebAsync;


namespace Tests.AsyncTests
{
    public class TestBase
    {
        [TestInitialize]
        public void InitializeTest()
        {
            string userName = ConfigurationManager.AppSettings["UserName"];
            string password = ConfigurationManager.AppSettings["Password"];
            string secret = ConfigurationManager.AppSettings["Secret"];
            string altUrl = ConfigurationManager.AppSettings["AltUrl"];

            if (string.IsNullOrEmpty(altUrl))
            {
                Enums.BaseUrl baseURL;
                Enum.TryParse(ConfigurationManager.AppSettings["BaseURL"], out baseURL);
                ApiClient.SetUp(userName, password, secret, baseURL);
            }
            else
            {
                ApiClient.SetUp(userName, password, secret, altUrl);
            }
        }
    }
}
