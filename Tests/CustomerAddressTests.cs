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
    public class CustomerAddressTests
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
        public async Task CustomerAddressTests_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            CustomerAddress customerAddress = new CustomerAddress()
            {
                FirstName = "John",
                LastName = "Doe",
                IsDefault = true,
                Address1 = "Address line 1",
                Address2 = "Address line 2",
                Address3 = "Address line 3",
                City = "Cork",
                CountryCode = "IE",
                State = "Cork",
                PostalCode = "Cork",
                Type = 0 
            };

            CustomerAddress returnCustomerAddress = await CustomerAddress.PostAsync(returnCase.Id, customerAddress);

            Assert.IsTrue(returnCustomerAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task CustomerAddressTests_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            CustomerAddress customerAddress = new CustomerAddress()
            {
                FirstName = "John",
                LastName = "Doe",
                IsDefault = true,
                Address1 = "Address line 1",
                Address2 = "Address line 2",
                Address3 = "Address line 3",
                City = "Cork",
                CountryCode = "IE",
                State = "Cork",
                PostalCode = "Cork",
                Type = 0
            };

            CustomerAddress returnCustomerAddress = CustomerAddress.Post(returnCase.Id, customerAddress);

            Assert.IsTrue(returnCustomerAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task CustomerAddressTests_UpdateAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid customerAddressId = returnCase.Customer.Addresses.First().Id;

            CustomerAddress customerAddress = new CustomerAddress()
            {
                FirstName = "John",
                LastName = "Doe",
                IsDefault = true,
                Address1 = "Address line 1",
                Address2 = "Address line 2",
                Address3 = "Address line 3",
                City = "Cork",
                CountryCode = "IE",
                State = "Cork",
                PostalCode = "Cork",
                Type = 0
            };

            CustomerAddress returnCustomerAddress = await CustomerAddress.UpdateAsync(returnCase.Id, customerAddress, customerAddressId);

            Assert.IsTrue(returnCustomerAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task CustomerAddressTests_Update_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Guid customerAddressId = returnCase.Customer.Addresses.First().Id;

            CustomerAddress customerAddress = new CustomerAddress()
            {
                FirstName = "John",
                LastName = "Doe",
                IsDefault = true,
                Address1 = "Address line 1",
                Address2 = "Address line 2",
                Address3 = "Address line 3",
                City = "Cork",
                CountryCode = "IE",
                State = "Cork",
                PostalCode = "Cork",
                Type = 0
            };

            CustomerAddress returnCustomerAddress = CustomerAddress.Update(returnCase.Id, customerAddress, customerAddressId);

            Assert.IsTrue(returnCustomerAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task CustomerAddressTests_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid customerAddressId = returnCase.Customer.Addresses.First().Id;

            CustomerAddress returnCustomerAddress = await CustomerAddress.GetAsync(returnCase.Id, customerAddressId);

            Assert.IsTrue(returnCustomerAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task CustomerAddressTests_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Guid customerAddressId = returnCase.Customer.Addresses.First().Id;

            CustomerAddress returnCustomerAddress = CustomerAddress.Get(returnCase.Id, customerAddressId);

            Assert.IsTrue(returnCustomerAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task CustomerAddressTests_GetAsync_200_MultipleAddresses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Customer.Addresses.Add(new CustomerAddress()
            {
                FirstName = "John",
                LastName = "Doe",
                IsDefault = true,
                Address1 = "Address line 1",
                Address2 = "Address line 2",
                Address3 = "Address line 3",
                City = "Cork",
                CountryCode = "IE",
                State = "Cork",
                PostalCode = "Cork",
                Type = 0
            });

            Case returnCase = await Case.PostAsync(sampleCase);

            IList<CustomerAddress> returnCustomerAddresses = await CustomerAddress.GetAsync(returnCase.Id);

            Assert.IsTrue(returnCustomerAddresses.Count > 1);
        }

        [TestMethod]
        public async Task CustomerAddressTests_Get_200_MultipleAddresses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Customer.Addresses.Add(new CustomerAddress()
            {
                FirstName = "John",
                LastName = "Doe",
                IsDefault = true,
                Address1 = "Address line 1",
                Address2 = "Address line 2",
                Address3 = "Address line 3",
                City = "Cork",
                CountryCode = "IE",
                State = "Cork",
                PostalCode = "Cork",
                Type = 0
            });

            Case returnCase = Case.Post(sampleCase);

            IList<CustomerAddress> returnCustomerAddresses = CustomerAddress.Get(returnCase.Id);

            Assert.IsTrue(returnCustomerAddresses.Count > 1);
        }

        [TestMethod]
        public async Task CustomerAddressTests_GetAsync_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;
            try
            {
                Case sampleCase = GenerateSampleCase();

                sampleCase.Customer.Addresses = null;

                Case returnCase = await Case.PostAsync(sampleCase);

                IList<CustomerAddress> returnCustomerAddresses = await CustomerAddress.GetAsync(returnCase.Id);
            }
            catch (TrustevHttpException ex)
            {
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.BadRequest, responseCode);
        }

        [TestMethod]
        public async Task CustomerAddressTests_Get_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;
            try
            {
                Case sampleCase = GenerateSampleCase();

                sampleCase.Customer.Addresses = null;

                Case returnCase = Case.Post(sampleCase);

                IList<CustomerAddress> returnCustomerAddresses = CustomerAddress.Get(returnCase.Id);
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
