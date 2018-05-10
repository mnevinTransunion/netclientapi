using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain;
using Trustev.Domain.Entities;
using Trustev.Web;

namespace TestsNet40.SyncTests
{
    [TestClass]
    public class SessionTests : TestBase
    {
        [TestMethod]
        public void SessionTest_PostAsync_200()
        {
            Session sampleSessione = this.GenerateSampleSession();

            Session returnSession = ApiClient.PostSession(sampleSessione);

            Assert.IsNotNull(returnSession.SessionId);
            Assert.AreNotEqual(Guid.Empty, returnSession.SessionId);
        }

        [TestMethod]
        public void SessionTest_PostDetail_200()
        {
            Session sampleSessione = this.GenerateSampleSession();

            Session returnSession = ApiClient.PostSession(sampleSessione);

            Detail detail = GenerateSampleDetail();

            Detail returnDetail = ApiClient.PostDetail(returnSession.SessionId, detail);

            Assert.IsNotNull(returnDetail.Id);
            Assert.AreNotEqual(Guid.Empty, returnDetail.Id);
        }

        #region Private Methods

        private Detail GenerateSampleDetail()
        {
            return new Detail()
            {
                ClientIp = "10.0.0.31"
            };
        }

        private Session GenerateSampleSession(Enums.SessionType sessionType = Enums.SessionType.JavaScript)
        {
            return new Session()
            {
                SessionType = sessionType
            };
        }

        #endregion
    }
}
