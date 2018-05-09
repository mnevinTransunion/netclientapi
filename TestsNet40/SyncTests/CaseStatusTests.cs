using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain;
using Trustev.Domain.Entities;
using Trustev.Domain.Exceptions;
using Trustev.Web;

namespace TestsNet40.SyncTests
{
    [TestClass]
    public class CaseStatusTests : TestBase
    {
        [TestMethod]
        public void StatusTest_Post_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "TestStatus",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus returnCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            Assert.IsTrue(returnCaseStatus.Id != Guid.Empty);
            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Completed);
        }

        [TestMethod]
        public void StatusTest_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "TestStatus",
                Status = Enums.CaseStatusType.Completed,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Completed);
        }

		[TestMethod]
        public void StatusTest_Ato_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test Ato Status",
                Status = Enums.CaseStatusType.Ato,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Ato);
        }

        [TestMethod]
        public void StatusTest_AtoChargeback_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.AtoChargeback,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.AtoChargeback);
        }

        [TestMethod]
        public void StatusTest_RejectedFraud_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.RejectedFraud,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.RejectedFraud);
        }

        [TestMethod]
        public void StatusTest_RejectedSuspicious_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.RejectedSuspicious,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.RejectedSuspicious);
        }

        [TestMethod]
        public void StatusTest_RejectedAuthFailure_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.RejectedAuthFailure,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.RejectedAuthFailure);
        }

        [TestMethod]
        public void StatusTest_Cancelled_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.Cancelled,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Cancelled);
        }

        [TestMethod]
        public void StatusTest_ChargebackFraud_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.ChargebackFraud,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.ChargebackFraud);
        }

        [TestMethod]
        public void StatusTest_ChargebackOther_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.ChargebackOther,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.ChargebackOther);
        }

        [TestMethod]
        public void StatusTest_OnHoldReview_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.OnHoldReview,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.OnHoldReview);
        }

        [TestMethod]
        public void StatusTest_Refunded_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.Refunded,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.Refunded);
        }

        [TestMethod]
        public void StatusTest_ReportedFraud_Get_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "Test AtoChargeback Status",
                Status = Enums.CaseStatusType.ReportedFraud,
                Timestamp = DateTime.UtcNow
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            CaseStatus returnCaseStatus = ApiClient.GetCaseStatus(returnCase.Id, postCaseStatus.Id);

            Assert.IsTrue(returnCaseStatus.Status == Enums.CaseStatusType.ReportedFraud);
        }

        [TestMethod]
        public void StatusTest_GetAll_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CaseStatus status = new CaseStatus()
            {
                Comment = "TestStatus",
                Status = Enums.CaseStatusType.ReportedFraud
            };

            CaseStatus postCaseStatus = ApiClient.PostCaseStatus(returnCase.Id, status);

            IList<CaseStatus> returnCaseStatuses = ApiClient.GetCaseStatuses(returnCase.Id);

            Assert.IsTrue(returnCaseStatuses.Count > 1);
        }

        [TestMethod]
        public void StatusTest_GetAll_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                string dummyCaseId = string.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                IList<CaseStatus> returnCaseStatuses = ApiClient.GetCaseStatuses(dummyCaseId);
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
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString()){};

            return sampleCase;
        }
        #endregion
    }
}
