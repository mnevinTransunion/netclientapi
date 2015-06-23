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
    public class CaseStatusTests
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
        public async Task CaseStatus_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Dummy Comment",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus returnStatus = await CaseStatus.PostAsync(returnCase.Id, status);

            Assert.IsTrue(returnStatus.Id != Guid.Empty);
        }

        [TestMethod]
        public void CaseStatus_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Dummy Comment",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus returnStatus = CaseStatus.Post(returnCase.Id, status);

            Assert.IsTrue(returnStatus.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task CaseStatus_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Statuses.Add(new CaseStatus()
            {
                Comment = "Dummy Comment",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            });

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid statusId = returnCase.Statuses.First().Id;

            CaseStatus returnStatus = await CaseStatus.GetAsync(returnCase.Id, statusId);

            Assert.IsTrue(returnStatus.Id != Guid.Empty);
        }

        [TestMethod]
        public void CaseStatus_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Statuses.Add(new CaseStatus()
            {
                Comment = "Dummy Comment",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            });

            Case returnCase = Case.Post(sampleCase);

            Guid statusId = returnCase.Statuses.First().Id;

            CaseStatus returnStatus = CaseStatus.Get(returnCase.Id, statusId);

            Assert.IsTrue(returnStatus.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task CaseStatus_GetAsync_200_MultipleStatuses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Statuses.Add(new CaseStatus()
            {
                Comment = "Dummy Comment",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            });

            sampleCase.Statuses.Add(new CaseStatus()
            {
                Comment = "Dummy Comment",
                Status = Enums.CaseStatusType.RejectedFraud,
                Timestamp = DateTime.UtcNow
            });

            Case returnCase = await Case.PostAsync(sampleCase);

            IList<CaseStatus> returnStatuses = await CaseStatus.GetAsync(returnCase.Id);

            Assert.IsTrue(returnStatuses.Count > 1);
        }

        [TestMethod]
        public void CaseStatus_Get_200_MultipleStatuses()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Statuses.Add(new CaseStatus()
            {
                Comment = "Dummy Comment",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            });

            sampleCase.Statuses.Add(new CaseStatus()
            {
                Comment = "Dummy Comment",
                Status = Enums.CaseStatusType.RejectedFraud,
                Timestamp = DateTime.UtcNow
            });

            Case returnCase = Case.Post(sampleCase);

            IList<CaseStatus> returnStatuses = CaseStatus.Get(returnCase.Id);

            Assert.IsTrue(returnStatuses.Count > 1);
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
