using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain;
using Trustev.Domain.Entities;
using Trustev.Domain.Exceptions;
using Trustev.WebAsync;

namespace Tests.AsyncTests
{
    [TestClass]
    public class CaseTypeTestsAsync : TestBase
    {
        [TestMethod]
        public async Task CaseDefaultTestAsync()
        {
            Case sampleCase = this.GenerateDefaultCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.AreEqual(returnCase.CaseType, Enums.CaseType.Default);
            Assert.IsFalse(returnCase.Customer == null);

        }

        [TestMethod]
        public async Task CaseAccountCreationTestAsync()
        {
            Case sampleCase = this.GenerateAccountCreationCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.AreEqual(returnCase.CaseType, Enums.CaseType.AccountCreation);
            Assert.IsFalse(returnCase.Customer == null);

        }

        [TestMethod]
        public async Task CaseApplicationTestAsync()
        {
            Case sampleCase = this.GenerateApplicationCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.AreEqual(returnCase.CaseType, Enums.CaseType.Application);
            Assert.IsFalse(returnCase.Customer == null);
        }

        [TestMethod]
        public async Task CaseADRTestAsync()
        {
            Case sampleCase = this.GenerateADRCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.AreEqual(returnCase.CaseType, Enums.CaseType.ADR);
            Assert.IsFalse(returnCase.Customer == null);
        }

        #region SetCaseContents
        private Case GenerateDefaultCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                }
            };

            return sampleCase;
        }

        private Case GenerateAccountCreationCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                CaseType = Enums.CaseType.AccountCreation,
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    AccountNumber = "AccountNumber456"
                }
            };

            return sampleCase;
        }

        private Case GenerateApplicationCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                CaseType = Enums.CaseType.Application,
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                }
            };

            return sampleCase;
        }

        private Case GenerateADRCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                CaseType = Enums.CaseType.ADR,
                Customer = new Customer()
                {
                    FirstName = "Aaron",
                    LastName = "Joe",
                }
            };

            return sampleCase;
        }

        #endregion
    }
}
