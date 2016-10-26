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
    public class CaseTestsAsync : TestBase
    {
        [TestMethod]
        public async Task CaseTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Assert.IsFalse(string.IsNullOrEmpty(returnCase.Id));
            Assert.IsFalse(returnCase.Customer == null);
            Assert.IsFalse(returnCase.Customer.Id == Guid.Empty);

            Assert.AreEqual("John", returnCase.Customer.FirstName);
            Assert.AreEqual("Doe", returnCase.Customer.LastName);

        }

        [TestMethod]
        public async Task CaseTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Case getCase = await ApiClient.GetCaseAsync(returnCase.Id);

            Assert.IsFalse(string.IsNullOrEmpty(getCase.Id));
            Assert.IsFalse(getCase.Customer == null);
            Assert.IsFalse(getCase.Customer.Id == Guid.Empty);

            Assert.AreEqual("John", getCase.Customer.FirstName);
            Assert.AreEqual("Doe", getCase.Customer.LastName);

        }

        [TestMethod]
        public async Task CaseTest_UpdateAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            returnCase.Customer.FirstName = "Joe";

            await ApiClient.UpdateCaseAsync(returnCase, returnCase.Id);

            Case getCase = await ApiClient.GetCaseAsync(returnCase.Id);

            Assert.AreEqual("Joe", getCase.Customer.FirstName);
        }

        [TestMethod]
        public async Task CaseTest_GetAsync_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                string dummyCaseId = string.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Case getCase = await ApiClient.GetCaseAsync(dummyCaseId);
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
