using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev_DotNet;
using Trustev_DotNet.Entities;
using Trustev_DotNet.Exceptions;

namespace Tests
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

            Trustev.SetUp(userName, password, secret);
        }

        [TestMethod]
        public async Task DecisionTest_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Decision decision = await Decision.GetAsync(returnCase.Id);

            Assert.IsNotNull(decision.Result);
        }

        [TestMethod]
        public void DecisionTest_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Decision decision = Decision.Get(returnCase.Id);

            Assert.IsNotNull(decision.Result);
        }

        [TestMethod]
        public async Task DecisionTest_GetAsync_404()
        {

            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = GenerateSampleCase();

                Case returnCase = await Case.PostAsync(sampleCase);

                String randomCaseId = String.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Decision decision = await Decision.GetAsync(randomCaseId);

                Assert.IsNotNull(decision.Result);
            }
            catch (TrustevHttpException ex)
            {
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);
        }

        [TestMethod]
        public void DecisionTest_Get_404()
        {

            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = GenerateSampleCase();

                Case returnCase = Case.Post(sampleCase);

                String randomCaseId = String.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Decision decision = Decision.Get(randomCaseId);

                Assert.IsNotNull(decision.Result);
            }
            catch (TrustevHttpException ex)
            {
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);
        }

        [TestMethod]
        public async Task DecisionTest_GetAsync_200_NewCase()
        {
            Case sampleCase = GenerateSampleCase();

            Decision decision = await Decision.GetAsync(sampleCase);

            Assert.IsNotNull(decision.Result);
            Assert.IsFalse(String.IsNullOrEmpty(decision.CaseId));
        }

        [TestMethod]
        public void DecisionTest_Get_200_NewCase()
        {
            Case sampleCase = GenerateSampleCase();

            Decision decision = Decision.Get(sampleCase);

            Assert.IsNotNull(decision.Result);
            Assert.IsFalse(String.IsNullOrEmpty(decision.CaseId));
        }

        private Case GenerateSampleCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                #region SetCaseContents
                Timestamp = DateTime.Now,
                Transaction = new Transaction()
                {
                    TotalTransactionValue = (Decimal)21.78,
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
                            City = "",
                            CountryCode = "",
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
                #endregion
            };

            return sampleCase;
        }
    }
}
