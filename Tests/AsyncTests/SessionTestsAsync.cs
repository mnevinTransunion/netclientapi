using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trustev.Domain;
using Trustev.Domain.Entities;
using Trustev.WebAsync;

namespace Tests.AsyncTests
{
    [TestClass]
    public class SessionTestsAsync : TestBase
    {
        [TestMethod]
        public async Task SessionTest_PostAsync_200()
        {
            Session sampleSessione = this.GenerateSampleSession();

            Session returnSession = await ApiClient.PostSessionAsync(sampleSessione);

            Assert.IsNotNull(returnSession.SessionId);
            Assert.AreNotEqual(Guid.Empty, returnSession.SessionId);
        }

        [TestMethod]
        public async Task SessionTest_PostDetail_200()
        {
            Session sampleSessione = this.GenerateSampleSession();

            Session returnSession = await ApiClient.PostSessionAsync(sampleSessione);

            Detail detail = GenerateSampleDetail();

            Detail returnDetail = await ApiClient.PostDetailAsync(returnSession.SessionId, detail);

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
