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
    public class CustomerTests
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
        public async Task CustomerTest_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Customer sampleCustomer = sampleCase.Customer;

            sampleCase.Customer = null;

            Case returnCase = await Case.PostAsync(sampleCase);

            Customer returnCustomer = await Customer.PostAsync(returnCase.Id, sampleCustomer);

            Assert.AreNotEqual(Guid.Empty, returnCustomer.Id);
        }

        [TestMethod]
        public void CustomerTest_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Customer sampleCustomer = sampleCase.Customer;

            sampleCase.Customer = null;

            Case returnCase = Case.Post(sampleCase);

            Customer returnCustomer = Customer.Post(returnCase.Id, sampleCustomer);

            Assert.AreNotEqual(Guid.Empty, returnCustomer.Id);
        }

        [TestMethod]
        public async Task CustomerTest_UpdateAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Customer sampleCustomer = returnCase.Customer;

            sampleCustomer.FirstName = "NewFirstName";
            sampleCustomer.LastName = "NewLastName";

            Customer returnCustomer = await Customer.UpdateAsync(returnCase.Id, sampleCustomer);

            Assert.AreEqual(sampleCustomer.FirstName, returnCustomer.FirstName);
            Assert.AreEqual(sampleCustomer.LastName, returnCustomer.LastName);
        }

        [TestMethod]
        public void CustomerTest_Update_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Customer sampleCustomer = returnCase.Customer;

            sampleCustomer.FirstName = "NewFirstName";
            sampleCustomer.LastName = "NewLastName";

            Customer returnCustomer = Customer.Update(returnCase.Id, sampleCustomer);

            Assert.AreEqual(sampleCustomer.FirstName, returnCustomer.FirstName);
            Assert.AreEqual(sampleCustomer.LastName, returnCustomer.LastName);
        }

        [TestMethod]
        public async Task CustomerTest_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Customer returnCustomer = await Customer.GetAsync(returnCase.Id);

            Assert.IsNotNull(returnCustomer.Id);
        }

        [TestMethod]
        public void CustomerTest_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Customer returnCustomer = Customer.Get(returnCase.Id);

            Assert.IsNotNull(returnCustomer.Id);
        }

        [TestMethod]
        public async Task CustomerTest_GetAsync_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = GenerateSampleCase();

                sampleCase.Customer = null;

                Case returnCase = await Case.PostAsync(sampleCase);

                Customer returnCustomer = await Customer.GetAsync(returnCase.Id);
            }
            catch (TrustevHttpException ex)
            {
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);

        }

        [TestMethod]
        public void CustomerTest_Get_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = GenerateSampleCase();

                sampleCase.Customer = null;

                Case returnCase = Case.Post(sampleCase);

                Customer returnCustomer = Customer.Get(returnCase.Id);
            }
            catch (TrustevHttpException ex)
            {
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);

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
