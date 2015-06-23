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
    public class TransactionTests
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
        public async Task TransactionTest_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Transaction sampleTransaction = sampleCase.Transaction;

            sampleCase.Transaction = null;

            Case returnCase = await Case.PostAsync(sampleCase);

            Transaction returnTransaction = await Transaction.PostAsync(returnCase.Id, sampleTransaction);

            Assert.AreNotEqual(Guid.Empty, returnTransaction.Id);
        }

        [TestMethod]
        public void TransactionTest_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Transaction sampleTransaction = sampleCase.Transaction;

            sampleCase.Transaction = null;

            Case returnCase = Case.Post(sampleCase);

            Transaction returnTransaction = Transaction.Post(returnCase.Id, sampleTransaction);

            Assert.AreNotEqual(Guid.Empty, returnTransaction.Id);
        }

        [TestMethod]
        public async Task TransactionTest_UpdateAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Transaction sampleTransaction = returnCase.Transaction;

            sampleTransaction.Currency = "USD";

            Transaction returnTransaction = await Transaction.UpdateAsync(returnCase.Id, sampleTransaction);

            Assert.AreEqual(sampleTransaction.Currency, returnTransaction.Currency);
        }

        [TestMethod]
        public void TransactionTest_Update_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Transaction sampleTransaction = returnCase.Transaction;

            sampleTransaction.Currency = "USD";

            Transaction returnTransaction = Transaction.Update(returnCase.Id, sampleTransaction);

            Assert.AreEqual(sampleTransaction.Currency, returnTransaction.Currency);
        }

        [TestMethod]
        public async Task TransactionTest_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Transaction returnCustomer = await Transaction.GetAsync(returnCase.Id);

            Assert.IsNotNull(returnCustomer.Id);
        }

        [TestMethod]
        public void TransactionTest_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Transaction returnCustomer = Transaction.Get(returnCase.Id);

            Assert.IsNotNull(returnCustomer.Id);
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
