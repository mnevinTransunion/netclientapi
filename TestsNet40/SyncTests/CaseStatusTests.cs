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
using Trustev.Web;

namespace TestsNet40.SyncTests
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

            Enums.BaseUrl baseURL;
            Enum.TryParse(ConfigurationManager.AppSettings["BaseURL"], out baseURL);

            ApiClient.SetUp(userName, password, secret, baseURL);
        }

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
