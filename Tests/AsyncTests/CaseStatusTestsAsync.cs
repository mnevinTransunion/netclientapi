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
        public async Task StatusTest_Ato_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test Ato Status",
                Status = Enums.CaseStatusType.Ato,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Ato);
        }

        [TestMethod]
        public async Task StatusTest_AtoChargeback_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.AtoChargeback,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.AtoChargeback);
        }

        [TestMethod]
        public async Task StatusTest_RejectedFraud_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.RejectedFraud,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.RejectedFraud);
        }

        [TestMethod]
        public async Task StatusTest_RejectedSuspicious_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.RejectedSuspicious,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.RejectedSuspicious);
        }

        [TestMethod]
        public async Task StatusTest_RejectedAuthFailure_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.RejectedAuthFailure,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.RejectedAuthFailure);
        }

        [TestMethod]
        public async Task StatusTest_Cancelled_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.Cancelled,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Cancelled);
        }

        [TestMethod]
        public async Task StatusTest_ChargebackFraud_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.ChargebackFraud,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.ChargebackFraud);
        }

        [TestMethod]
        public async Task StatusTest_ChargebackOther_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.ChargebackOther,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.ChargebackOther);
        }

        [TestMethod]
        public async Task StatusTest_OnHoldReview_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.OnHoldReview,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.OnHoldReview);
        }

        [TestMethod]
        public async Task StatusTest_Refunded_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.Refunded,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Refunded);
        }

        [TestMethod]
        public async Task StatusTest_ReportedFraud_GetAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.ReportedFraud,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = await ApiClient.PostCaseStatusAsync(returnCase.Id, status);

            CaseStatus returnCaseStatus = await ApiClient.GetCaseStatusAsync(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.ReportedFraud);
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
