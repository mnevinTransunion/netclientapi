using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev_DotNet;
using Trustev_DotNet.Entities;

namespace Tests
{
    [TestClass]
    public class TransactionItemTests
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
        public async Task TransactionItemTests_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            TransactionItem transactionItem = new TransactionItem()
            {
                ItemValue = 10,
                Name = "TrustevTeeShirt",
                Quantity = 10
            };

            TransactionItem returntTransactionItem = await TransactionItem.PostAsync(returnCase.Id, transactionItem);

            Assert.IsTrue(returntTransactionItem.Id != Guid.Empty);
        }

        [TestMethod]
        public void TransactionItemTests_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            TransactionItem transactionItem = new TransactionItem()
            {
                ItemValue = 10,
                Name = "TrustevTeeShirt",
                Quantity = 10
            };

            TransactionItem returntTransactionItem = TransactionItem.Post(returnCase.Id, transactionItem);

            Assert.IsTrue(returntTransactionItem.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task TransactionItemTests_UpdateAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid transactionItemId = returnCase.Transaction.Items.First().Id;

            TransactionItem transactionItem = new TransactionItem()
            {
                ItemValue = 10,
                Name = "TrustevTeeShirt",
                Quantity = 10
            };

            TransactionItem returnTransactionItem = await TransactionItem.UpdateAsync(returnCase.Id, transactionItem, transactionItemId);

            Assert.IsTrue(returnTransactionItem.Id != Guid.Empty);
        }

        [TestMethod]
        public void TransactionItemTests_Update_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Guid transactionItemId = returnCase.Transaction.Items.First().Id;

            TransactionItem transactionItem = new TransactionItem()
            {
                ItemValue = 10,
                Name = "TrustevTeeShirt",
                Quantity = 10
            };

            TransactionItem returnTransactionItem = TransactionItem.Update(returnCase.Id, transactionItem, transactionItemId);

            Assert.IsTrue(returnTransactionItem.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task TransactionItemTests_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid transactionItemId = returnCase.Transaction.Items.First().Id;

            TransactionItem returnTransactionItem = await TransactionItem.GetAsync(returnCase.Id, transactionItemId);

            Assert.IsTrue(returnTransactionItem.Id != Guid.Empty);
        }

        [TestMethod]
        public void TransactionItemTests_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Guid transactionItemId = returnCase.Transaction.Items.First().Id;

            TransactionItem returnTransactionItem = TransactionItem.Get(returnCase.Id, transactionItemId);

            Assert.IsTrue(returnTransactionItem.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task TransactionItemTests_Get_200Async_MultipleAddresses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Transaction.Items.Add(new TransactionItem()
            {
                ItemValue = 10,
                Name = "TrustevTeeShirt",
                Quantity = 10
            });

            Case returnCase = await Case.PostAsync(sampleCase);

            IList<TransactionItem> returnTransactionItems = await TransactionItem.GetAsync(returnCase.Id);

            Assert.IsTrue(returnTransactionItems.Count > 1);
        }

        [TestMethod]
        public void TransactionItemTests_Get_200_MultipleAddresses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Transaction.Items.Add(new TransactionItem()
            {
                ItemValue = 10,
                Name = "TrustevTeeShirt",
                Quantity = 10
            });

            Case returnCase = Case.Post(sampleCase);

            IList<TransactionItem> returnTransactionItems = TransactionItem.Get(returnCase.Id);

            Assert.IsTrue(returnTransactionItems.Count > 1);
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
