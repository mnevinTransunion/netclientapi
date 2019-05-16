﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain;
using Trustev.Domain.Entities;
using Trustev.Domain.Exceptions;
using Trustev.WebAsync;

namespace Tests.AsyncTests
{
    [TestClass]
    public class DetailedDecisionTestsAsync : TestBase
    {
        [TestMethod]
        public async Task DetailedDecisionTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            DetailedDecision decision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            Assert.IsFalse(decision.Id == Guid.Empty);
            Assert.IsTrue(decision.AuthenticatedDataRequest==null);
            Assert.AreEqual(returnCase.CaseNumber, decision.CaseNumber);
        }

        [TestMethod]
        [Ignore()]
        [Description("2018-10-18: This was ignored because the configuration was not valid to return ADR, needs to be pick up by ULF")]
        public async Task DetailedDecisionADRTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();
            //selecting casetype ADR
            sampleCase.CaseType = Enums.CaseType.ADR;
            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);
            DetailedDecision decision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);
            Assert.IsFalse(decision.Id == Guid.Empty);
            // checking that there is ADR info available
            Assert.AreEqual(decision.AuthenticatedDataRequest.Details.FirstName,"AARON");
            Assert.AreEqual(returnCase.CaseNumber, decision.CaseNumber);
        }

        [TestMethod]
        public async Task DetailedDecisionTest_Get_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                string dummyCaseId = string.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Decision getDecision = await ApiClient.GetDetailedDecisionAsync(dummyCaseId);
            }
            catch (TrustevHttpException ex)
            {
                string message = ex.Message;
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);
        }

        #region SetCaseContents
        private Case GenerateSampleCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                IdentityConsentId = "I Solely Consent To Whatever",
                Timestamp = DateTime.Now,
                Transaction = new Transaction()
                {
                    TotalTransactionValue = (decimal)21.78,
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
                            City = string.Empty,
                            CountryCode = "US",
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
                    SocialSecurityNumber = "666010001",
                    Emails = new List<Email>()
                    {
                        new Email()
                        {
                            IsDefault = true,
                            EmailAddress = Guid.NewGuid() + "test@test.com"
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
                            City = "Cork",
                            CountryCode = "US",
                            State = "Cork",
                            PostalCode = "Cork",
                            Type = 0
                        }
                    }
                },
                Payments = new List<Payment>()
                {
                    new Payment()
                    {
                        BINNumber = "123456"
                    }
                },
                Statuses = new List<CaseStatus>()
                {
                }
            };

            return sampleCase;
        }
        #endregion
    }
}
