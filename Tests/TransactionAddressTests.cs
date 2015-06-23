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
    public class TransactionAddressTests
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
        public async Task TransactionAddressTests_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            TransactionAddress transactionAddress = new TransactionAddress()
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

            TransactionAddress returntTransactionAddress = await TransactionAddress.PostAsync(returnCase.Id, transactionAddress);

            Assert.IsTrue(returntTransactionAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public void TransactionAddressTests_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            TransactionAddress transactionAddress = new TransactionAddress()
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

            TransactionAddress returntTransactionAddress = TransactionAddress.Post(returnCase.Id, transactionAddress);

            Assert.IsTrue(returntTransactionAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task TransactionAddressTests_UpdateAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid transactionAddressId = returnCase.Transaction.Addresses.First().Id;

            TransactionAddress transactionAddress = new TransactionAddress()
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

            TransactionAddress returnTransactionAddress = await TransactionAddress.UpdateAsync(returnCase.Id, transactionAddress, transactionAddressId);

            Assert.IsTrue(returnTransactionAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public void TransactionAddressTests_Update_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Guid transactionAddressId = returnCase.Transaction.Addresses.First().Id;

            TransactionAddress transactionAddress = new TransactionAddress()
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

            TransactionAddress returnTransactionAddress = TransactionAddress.Update(returnCase.Id, transactionAddress, transactionAddressId);

            Assert.IsTrue(returnTransactionAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task TransactionAddressTests_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid transactionAddressId = returnCase.Transaction.Addresses.First().Id;

            TransactionAddress returnTransactionAddress = await TransactionAddress.GetAsync(returnCase.Id, transactionAddressId);

            Assert.IsTrue(returnTransactionAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public void TransactionAddressTests_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Guid transactionAddressId = returnCase.Transaction.Addresses.First().Id;

            TransactionAddress returnTransactionAddress = TransactionAddress.Get(returnCase.Id, transactionAddressId);

            Assert.IsTrue(returnTransactionAddress.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task TransactionAddressTests_Get_200Async_MultipleAddresses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Transaction.Addresses.Add(new TransactionAddress()
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

            IList<TransactionAddress> returnTransactionAddresses = await TransactionAddress.GetAsync(returnCase.Id);

            Assert.IsTrue(returnTransactionAddresses.Count > 1);
        }

        [TestMethod]
        public void TransactionAddressTests_Get_200_MultipleAddresses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Transaction.Addresses.Add(new TransactionAddress()
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

            IList<TransactionAddress> returnTransactionAddresses = TransactionAddress.Get(returnCase.Id);

            Assert.IsTrue(returnTransactionAddresses.Count > 1);
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
