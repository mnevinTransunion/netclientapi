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
    public class PaymentTests
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
        public void PaymentTest_Post_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Payment payment = new Payment();
            payment.BINNumber = "456789";

            Payment returnPayment = ApiClient.PostPayment(returnCase.Id, payment);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
            Assert.AreEqual(payment.BINNumber, returnPayment.BINNumber);
        }

        [TestMethod]
        public void PaymentTest_Update_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Payment payment = new Payment();
            payment.BINNumber = "456789";

            Payment returnPayment = ApiClient.UpdatePayment(returnCase.Id, payment, returnCase.Payments[0].Id);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
            Assert.AreEqual(payment.BINNumber, returnPayment.BINNumber);
        }

        [TestMethod]
        public void PaymentTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Payment returnPayment = ApiClient.GetPayment(returnCase.Id, returnCase.Payments[0].Id);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
            Assert.AreEqual(returnCase.Payments[0].BINNumber, returnPayment.BINNumber);
        }

        [TestMethod]
        public void PaymentTest_GetAll_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Payment payment = new Payment();
            payment.BINNumber = "445566";
            sampleCase.Payments.Add(payment);

            Case returnCase = ApiClient.PostCase(sampleCase);

            IList<Payment> returnPayments = ApiClient.GetPayments(returnCase.Id);

            Assert.IsTrue(returnPayments.Count > 1);
            Assert.AreEqual("123456", returnPayments[0].BINNumber);
            Assert.AreEqual("445566", returnPayments[1].BINNumber);
        }

        [TestMethod]
        public void PaymentTest_GetAll_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateBlankCase();
                Case returnCase = ApiClient.PostCase(sampleCase);

                IList<Payment> payments = ApiClient.GetPayments(returnCase.Id);
            }
            catch (TrustevHttpException ex)
            {
                string message = ex.Message;
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.BadRequest, responseCode);
        }

        #region SetCaseContents
        private Case GenerateBlankCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString()){};

            return sampleCase;
        }

        private Case GenerateSampleCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Payments = new List<Payment>()
                {
                    new Payment()
                    {
                        BINNumber = "123456"
                    }
                }
            };

            return sampleCase;
        }
    }
        #endregion
}
