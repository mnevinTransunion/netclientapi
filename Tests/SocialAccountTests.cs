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
    public class SocialAccountTests
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
        public async Task SocialAccountTests_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            SocialAccount socialAccount = new SocialAccount()
            {
                LongTermAccessToken = "LongTermAccessToken",
                LongTermAccessTokenExpiry = DateTime.UtcNow.AddDays(30),
                Secret = "Secret",
                ShortTermAccessToken = "ShortTermAccessToken",
                ShortTermAccessTokenExpiry = DateTime.UtcNow.AddMinutes(30),
                SocialId = 123456789,
                Timestamp = DateTime.UtcNow,
                Type = Enums.SocialNetworkType.Facebook
            };

            SocialAccount returnSocailAccount = await SocialAccount.PostAsync(returnCase.Id, socialAccount);

            Assert.IsTrue(returnSocailAccount.Id != Guid.Empty);
        }

        [TestMethod]
        public void SocialAccountTests_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            SocialAccount socialAccount = new SocialAccount()
            {
                LongTermAccessToken = "LongTermAccessToken",
                LongTermAccessTokenExpiry = DateTime.UtcNow.AddDays(30),
                Secret = "Secret",
                ShortTermAccessToken = "ShortTermAccessToken",
                ShortTermAccessTokenExpiry = DateTime.UtcNow.AddMinutes(30),
                SocialId = 123456789,
                Timestamp = DateTime.UtcNow,
                Type = Enums.SocialNetworkType.Facebook
            };

            SocialAccount returnSocailAccount = SocialAccount.Post(returnCase.Id, socialAccount);

            Assert.IsTrue(returnSocailAccount.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task SocialAccountTests_UpdateAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid socialAccountId = returnCase.Customer.SocialAccounts.First().Id;

            SocialAccount socialAccount = new SocialAccount()
            {
                LongTermAccessToken = "LongTermAccessToken",
                LongTermAccessTokenExpiry = DateTime.UtcNow.AddDays(30),
                Secret = "Secret",
                ShortTermAccessToken = "ShortTermAccessToken",
                ShortTermAccessTokenExpiry = DateTime.UtcNow.AddMinutes(30),
                SocialId = 123456789,
                Timestamp = DateTime.UtcNow,
                Type = Enums.SocialNetworkType.Facebook
            };

            SocialAccount returnSocailAccount = await SocialAccount.UpdateAsync(returnCase.Id, socialAccount, socialAccountId);

            Assert.IsTrue(returnSocailAccount.Id != Guid.Empty);
        }

        [TestMethod]
        public void SocialAccountTests_Update_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Guid socialAccountId = returnCase.Customer.SocialAccounts.First().Id;

            SocialAccount socialAccount = new SocialAccount()
            {
                LongTermAccessToken = "LongTermAccessToken",
                LongTermAccessTokenExpiry = DateTime.UtcNow.AddDays(30),
                Secret = "Secret",
                ShortTermAccessToken = "ShortTermAccessToken",
                ShortTermAccessTokenExpiry = DateTime.UtcNow.AddMinutes(30),
                SocialId = 123456789,
                Timestamp = DateTime.UtcNow,
                Type = Enums.SocialNetworkType.Facebook
            };

            SocialAccount returnSocailAccount = SocialAccount.Update(returnCase.Id, socialAccount, socialAccountId);

            Assert.IsTrue(returnSocailAccount.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task SocialAccountTests_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid socialAccountId = returnCase.Customer.SocialAccounts.First().Id;

            SocialAccount returnSocialAccount = await SocialAccount.GetAsync(returnCase.Id, socialAccountId);

            Assert.IsTrue(returnSocialAccount.Id != Guid.Empty);
        }

        [TestMethod]
        public void SocialAccountTests_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Guid socialAccountId = returnCase.Customer.SocialAccounts.First().Id;

            SocialAccount returnSocialAccount = SocialAccount.Get(returnCase.Id, socialAccountId);

            Assert.IsTrue(returnSocialAccount.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task SocialAccountTests_GetAsync_200_MultipleAddresses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Customer.SocialAccounts.Add(new SocialAccount()
            {
                LongTermAccessToken = "LongTermAccessToken",
                LongTermAccessTokenExpiry = DateTime.UtcNow.AddDays(30),
                Secret = "Secret",
                ShortTermAccessToken = "ShortTermAccessToken",
                ShortTermAccessTokenExpiry = DateTime.UtcNow.AddMinutes(30),
                SocialId = 123456789,
                Timestamp = DateTime.UtcNow,
                Type = Enums.SocialNetworkType.Facebook
            });

            Case returnCase = await Case.PostAsync(sampleCase);

            IList<SocialAccount> returnSocailAccounts = await SocialAccount.GetAsync(returnCase.Id);

            Assert.IsTrue(returnSocailAccounts.Count > 1);
        }

        [TestMethod]
        public void SocialAccountTests_Get_200_MultipleAddresses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Customer.SocialAccounts.Add(new SocialAccount()
            {
                LongTermAccessToken = "LongTermAccessToken",
                LongTermAccessTokenExpiry = DateTime.UtcNow.AddDays(30),
                Secret = "Secret",
                ShortTermAccessToken = "ShortTermAccessToken",
                ShortTermAccessTokenExpiry = DateTime.UtcNow.AddMinutes(30),
                SocialId = 123456789,
                Timestamp = DateTime.UtcNow,
                Type = Enums.SocialNetworkType.Facebook
            });

            Case returnCase = Case.Post(sampleCase);

            IList<SocialAccount> returnSocailAccounts = SocialAccount.Get(returnCase.Id);

            Assert.IsTrue(returnSocailAccounts.Count > 1);
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
