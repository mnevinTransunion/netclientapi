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
    public class CaseTests
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
        public async Task CaseTest_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case.PostAsync(sampleCase);
            await Case.PostAsync(sampleCase);

            //Assert.IsFalse(String.IsNullOrEmpty(returnCase.Id));
        }

        [TestMethod]
        public void CaseTest_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Assert.IsFalse(String.IsNullOrEmpty(returnCase.Id));
        }

        [TestMethod]
        public async Task CaseTest_UpdateAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            returnCase.Customer.FirstName = "NewFirstName";
            returnCase.Customer.LastName = "NewLastName";

            Case updateCase = await Case.UpdateAsync(returnCase, returnCase.Id);

            Assert.IsTrue(updateCase.Customer.FirstName.Equals("NewFirstName"));
        }

        [TestMethod]
        public async Task CaseTest_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Case getCase = await Case.GetAsync(returnCase.Id);

            Assert.IsNotNull(getCase);
            Assert.IsFalse(String.IsNullOrEmpty(getCase.Id));
        }

        [TestMethod]
        public async Task CaseTest_GetAsync_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = GenerateSampleCase();

                String randomCaseId = String.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Case getCase = await Case.GetAsync(randomCaseId);
            }
            catch (TrustevHttpException ex)
            {
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);
        }

        [TestMethod]
        public void CaseTest_Get_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = GenerateSampleCase();

                String randomCaseId = String.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Case getCase = Case.Get(randomCaseId);
            }
            catch (TrustevHttpException ex)
            {
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);
        }

        [TestMethod]
        public async Task CaseTest_PostAsync_400_IncludedACaseId()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = GenerateSampleCase();

                sampleCase.Id = "RandomCaseId";

                Case returnCase = await Case.PostAsync(sampleCase);
            }
            catch (TrustevHttpException ex)
            {
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.BadRequest, responseCode);
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
