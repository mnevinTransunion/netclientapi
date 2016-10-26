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
    public class DecisionTests : TestBase
    {
        [TestMethod]
        public void DecisionTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Decision decision = ApiClient.GetDecision(returnCase.Id);

            Assert.IsFalse(decision.Id == Guid.Empty);
            Assert.IsFalse(decision.Result == Enums.DecisionResult.Unknown);
        }

        [TestMethod]
        public void Decision_Pass()
        {
            Case sampleCase = this.GenerateTestPass();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Decision decision = ApiClient.GetDecision(returnCase.Id);

            Assert.IsFalse(decision.Id == Guid.Empty);
            Assert.IsTrue(decision.Result == Enums.DecisionResult.Pass);
        }

        [TestMethod]
        public void Decision_Flag()
        {
            Case sampleCase = this.GenerateTestFlag();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Decision decision = ApiClient.GetDecision(returnCase.Id);

            Assert.IsFalse(decision.Id == Guid.Empty);
            Assert.IsTrue(decision.Result == Enums.DecisionResult.Flag);
        }

        [TestMethod]
        public void Decision_Fail()
        {
            Case sampleCase = this.GenerateTestFail();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Decision decision = ApiClient.GetDecision(returnCase.Id);

            Assert.IsFalse(decision.Id == Guid.Empty);
            Assert.IsTrue(decision.Result == Enums.DecisionResult.Fail);
        }

        [TestMethod]
        public void DecisionTest_Get_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                string dummyCaseId = string.Format("{0}|{1}", Guid.NewGuid(), Guid.NewGuid());

                Decision getDecision = ApiClient.GetDecision(dummyCaseId);
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

        private Case GenerateTestPass()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString() + "pass")
            {
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe"
                }
            };

            return sampleCase;

        }

        private Case GenerateTestFlag()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString() + "flag")
            {
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe"
                }
            };

            return sampleCase;

        }

        private Case GenerateTestFail()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString() + "fail")
            {
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe"
                }
            };

            return sampleCase;

        }

        #endregion
    }
}
