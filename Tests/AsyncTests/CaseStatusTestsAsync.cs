using System;
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
    public class CaseStatusTestsAsync : TestBase
    {
        [TestMethod]
        public async Task StatusTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "TestStatus",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus returnCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            Assert.IsTrue(returnCaseStatus.Id != Guid.Empty);
            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Completed);
        }

        [TestMethod]
        public async Task StatusTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "TestStatus",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Completed);
        }

        [TestMethod]
        public async Task StatusTest_GetAllAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "TestStatus",
                Status = Enums.CaseStatusType.ReportedFraud
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            IList<CaseStatus> returnCaseStatuses = await ApiClient.GetCaseStatusesAsync(returnCase.Id);

            Assert.IsTrue(returnCaseStatuses.Count > 1);
        }

        [TestMethod]
        public async Task StatusTest_GetAllAsync_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                string dummyCaseId = string.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                IList<CaseStatus> returnCaseStatuses = await ApiClient.GetCaseStatusesAsync(dummyCaseId);
            }
            catch (TrustevHttpException ex)
            {
                string message = ex.Message;
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.NotFound, responseCode);
        }

        #region SetCaseContents
        private Case GenerateBlankCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString()) { };

            return sampleCase;
        }
        #endregion
    }
}
