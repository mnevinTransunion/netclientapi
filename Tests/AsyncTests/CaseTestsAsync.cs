using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain.Entities;
using Trustev.Domain.Exceptions;
using Trustev.WebAsync;

namespace Tests.AsyncTests
{
    [TestClass]
    public class CaseTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            var userName = ConfigurationManager.AppSettings["UserName"];
            var password = ConfigurationManager.AppSettings["Password"];
            var secret = ConfigurationManager.AppSettings["Secret"];

            ApiClient.SetUp(userName, password, secret);
        }

        [TestMethod]
        public async Task CaseTest_PostAsync_200()
        {
            var sampleCase = this.GenerateSampleCase();

            var returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
        }

        [TestMethod]
        public async Task CaseTest_Get_200()
        {
            var sampleCase = this.GenerateSampleCase();

            var returnCase = await ApiClient.PostCaseAsync(sampleCase);

            var getCase = await ApiClient.GetCaseAsync(returnCase.Id);

            Assert.IsFalse(string.IsNullOrEmpty(getCase.Id));
        }

        [TestMethod]
        public async Task CaseTest_Update_200()
        {
            var sampleCase = this.GenerateSampleCase();

            var returnCase = await ApiClient.PostCaseAsync(sampleCase);

            returnCase.Customer = null;

            await ApiClient.UpdateCaseAsync(returnCase, returnCase.Id);

            var getCase = await ApiClient.GetCaseAsync(returnCase.Id);

            Assert.IsNull(getCase.Customer);
        }

        [TestMethod]
        public async Task CaseTest_Get_404()
        {
            var responseCode = HttpStatusCode.OK;

            try
            {
                var dummyCaseId = string.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                var getCase = await ApiClient.GetCaseAsync(dummyCaseId);
            }
            catch (TrustevHttpException ex)
            {
                var message = ex.Message;
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);
        }

        #region SetCaseContents
        private Case GenerateSampleCase()
        {
            var sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Timestamp = DateTime.Now,
                Transaction = new Transaction
                {
                    TotalTransactionValue = (decimal)21.78,
                    Addresses = new List<TransactionAddress>
                    {
                        new TransactionAddress
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
                    Items = new List<TransactionItem>
                    {
                        new TransactionItem
                        {
                            Name = "Item 1",
                            Quantity = 1,
                            ItemValue = 10.99m
                        }
                    }
                },
                Customer = new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-24),
                    PhoneNumber = "0878767543",
                    Emails = new List<Email>
                    {
                        new Email
                        {
                            IsDefault = true,
                            EmailAddress = "clasf@gdasf.com"
                        }
                    },
                    Addresses = new List<CustomerAddress>
                    {
                        new CustomerAddress
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
                    SocialAccounts = new List<SocialAccount>
                    {
                        new SocialAccount
                        {
                            Type = 0,
                            SocialId = 9999,
                            LongTermAccessToken = "token",
                            LongTermAccessTokenExpiry = DateTime.UtcNow.AddYears(1)
                        }
                    }
                },
                Payments = new List<Payment>(),
                Statuses = new List<CaseStatus>()
            };

            return sampleCase;
        }
        #endregion
    }
}