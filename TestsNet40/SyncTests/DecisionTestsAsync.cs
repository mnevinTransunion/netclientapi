using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain.Entities;
using Trustev.Domain.Exceptions;
using Trustev.Web;

namespace TestsNet40.SyncTests
{
    [TestClass]
    public class DecisionTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            string userName = ConfigurationManager.AppSettings["UserName"];
            string password = ConfigurationManager.AppSettings["Password"];
            string secret = ConfigurationManager.AppSettings["Secret"];

            ApiClient.SetUp(userName, password, secret);
        }

        [TestMethod]
        public void DecisionTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Decision decision = ApiClient.GetDecision(returnCase.Id);

            Assert.IsFalse(decision.Id == Guid.Empty);
        }

        [TestMethod]
        public void DecisionTest_Get_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                string dummyCaseId = string.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Decision decision = ApiClient.GetDecision(dummyCaseId);
            }
            catch (TrustevHttpException ex)
            {
                string message = ex.Message;
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);
        }

        #region SetCaseContents
        private Case GenerateSampleCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Timestamp = DateTime.Now,
                Transaction = new Transaction()
                {
                    TotalTransactionValue = (decimal)21.78,
                    Addresses = new List<TransactionAddress>()
                    {
                        new TransactionAddress()
                        {
                            FirstName = "John",
                            LastName = "Doe",
                            IsDefault = true,
                            Address1 = "Address line 1",
                            Address2 = "Address line 2",
                            Address3 = "Address line 3",
                            City = string.Empty,
                            CountryCode = string.Empty,
                            State = "Cork",
                            PostalCode = "Cork",
                            Type = 0
                        }
                    },
                    Currency = "USD",
                    Timestamp = DateTime.UtcNow,
                    Items = new List<TransactionItem>()
                    {
                        new TransactionItem()
                        {
                            Name = "Item 1",
                            Quantity = 1,
                            ItemValue = 10.99m
                        }
                    }
                },
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-24),
                    PhoneNumber = "0878767543",
                    Emails = new List<Email>()
                    {
                        new Email()
                        {
                            IsDefault = true,
                            EmailAddress = "clasf@gdasf.com"
                        }
                    },
                    Addresses = new List<CustomerAddress>()
                    {
                        new CustomerAddress()
                        {
                            FirstName = "John",
                            LastName = "Doe",
                            IsDefault = true,
                            Address1 = "Address line 1",
                            Address2 = "Address line 2",
                            Address3 = "Address line 3",
                            City = "sdasd",
                            CountryCode = "IE",
                            State = "Cork",
                            PostalCode = "Cork",
                            Type = 0
                        }
                    },
                    SocialAccounts = new List<SocialAccount>()
                    {
                        new SocialAccount()
                        {
                            Type = 0,
                            SocialId = 9999,
                            LongTermAccessToken = "token",
                            LongTermAccessTokenExpiry = DateTime.UtcNow.AddYears(1)
                        }
                    }
                },
                Payments = new List<Payment>()
                {
                },
                Statuses = new List<CaseStatus>()
                {
                }
            };

            return sampleCase;
        }
        #endregion
    }
}
