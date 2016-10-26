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
    public class CaseTests : TestBase
    {
        [TestMethod]
        public void CaseTest_Post_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.IsFalse(returnCase.Customer == null);
            Assert.IsFalse(returnCase.Customer.Id == Guid.Empty);

            Assert.AreEqual("John", returnCase.Customer.FirstName);
            Assert.AreEqual("Doe", returnCase.Customer.LastName);

        }

        [TestMethod]
        public void CaseTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Case getCase = ApiClient.GetCase(returnCase.Id);

            Assert.IsFalse(string.IsNullOrEmpty(getCase.Id));
            Assert.IsFalse(getCase.Customer == null);
            Assert.IsFalse(getCase.Customer.Id == Guid.Empty);

            Assert.AreEqual("John", getCase.Customer.FirstName);
            Assert.AreEqual("Doe", getCase.Customer.LastName);

        }

        [TestMethod]
        public void CaseTest_Update_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            returnCase.Customer.FirstName = "Joe";

            ApiClient.UpdateCase(returnCase, returnCase.Id);

            Case getCase = ApiClient.GetCase(returnCase.Id);

            Assert.AreEqual("Joe", getCase.Customer.FirstName);
        }

        [TestMethod]
        public void CaseTest_Get_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                string dummyCaseId = string.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Case getCase = ApiClient.GetCase(dummyCaseId);
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
