using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain;
using Trustev.Domain.Entities;
using Trustev.Domain.Exceptions;
using Trustev.Web;

namespace TestsNet40.SyncTests
{
    [TestClass]
    public class CaseTypeTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            string userName = ConfigurationManager.AppSettings["UserName"];
            string password = ConfigurationManager.AppSettings["Password"];
            string secret = ConfigurationManager.AppSettings["Secret"];

            Enums.BaseUrl baseURL;
            Enum.TryParse(ConfigurationManager.AppSettings["BaseURL"], out baseURL);

            ApiClient.SetUp(userName, password, secret, baseURL);
        }

        [TestMethod]
        public void CaseDefaultTest()
        {
            Case sampleCase = this.GenerateDefaultCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.AreEqual(returnCase.CaseType, Enums.CaseType.Default);
            Assert.IsFalse(returnCase.Customer == null);

        }

        [TestMethod]
        public void CaseAccountCreationTest()
        {
            Case sampleCase = this.GenerateAccountCreationCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.AreEqual(returnCase.CaseType, Enums.CaseType.AccountCreation);
            Assert.IsFalse(returnCase.Customer == null);

        }

        [TestMethod]
        public void CaseApplicationTest()
        {
            Case sampleCase = this.GenerateApplicationCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.AreEqual(returnCase.CaseType, Enums.CaseType.Application);
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
        #endregion
    }
}
