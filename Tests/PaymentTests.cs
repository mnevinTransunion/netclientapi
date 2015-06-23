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
    public class PaymentTests
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
        public async Task PaymentTests_PostAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await Case.PostAsync(sampleCase);

            Payment payment = new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            };

            Payment returnPayment = await Payment.PostAsync(returnCase.Id, payment);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
        }

        [TestMethod]
        public void PaymentTests_Post_200()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = Case.Post(sampleCase);

            Payment payment = new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            };

            Payment returnPayment = Payment.Post(returnCase.Id, payment);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task PaymentTests_UpdateAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Payments.Add(new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            });

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid paymentId = returnCase.Payments.First().Id;

            Payment payment = new Payment()
            {
                BINNumber = "654321",
                PaymentType = Enums.PaymentType.CreditCard
            };

            Payment returnPayment = await Payment.UpdateAsync(returnCase.Id, payment, paymentId);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
        }

        [TestMethod]
        public void PaymentTests_Update_200()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Payments.Add(new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            });

            Case returnCase = Case.Post(sampleCase);

            Guid paymentId = returnCase.Payments.First().Id;

            Payment payment = new Payment()
            {
                BINNumber = "654321",
                PaymentType = Enums.PaymentType.CreditCard
            };

            Payment returnPayment = Payment.Update(returnCase.Id, payment, paymentId);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task PaymentTests_GetAsync_200()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Payments.Add(new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            });

            Case returnCase = await Case.PostAsync(sampleCase);

            Guid paymentId = returnCase.Payments.First().Id;

            Payment returnPayment = await Payment.GetAsync(returnCase.Id, paymentId);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
        }

        [TestMethod]
        public void PaymentTests_Get_200()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Payments.Add(new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            });

            Case returnCase = Case.Post(sampleCase);

            Guid paymentId = returnCase.Payments.First().Id;

            Payment returnPayment = Payment.Get(returnCase.Id, paymentId);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
        }

        [TestMethod]
        public async Task PaymentTests_GetAsync_200_MultiplePayments()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Payments.Add(new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            });

            sampleCase.Payments.Add(new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            });

            Case returnCase = await Case.PostAsync(sampleCase);

            IList<Payment> returnStatuses = await Payment.GetAsync(returnCase.Id);

            Assert.IsTrue(returnStatuses.Count > 1);
        }

        [TestMethod]
        public void PaymentTests_Get_200_MultiplePayments()
        {
            Case sampleCase = GenerateSampleCase();

            sampleCase.Payments.Add(new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            });

            sampleCase.Payments.Add(new Payment()
            {
                BINNumber = "123456",
                PaymentType = Enums.PaymentType.DebitCard
            });

            Case returnCase = Case.Post(sampleCase);

            IList<Payment> returnStatuses = Payment.Get(returnCase.Id);

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
