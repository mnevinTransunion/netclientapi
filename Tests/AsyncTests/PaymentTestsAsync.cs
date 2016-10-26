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
    public class PaymentTestsAsync : TestBase
    {
        [TestMethod]
        public async Task PaymentTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Payment payment = new Payment();
            payment.BINNumber = "456789";

            Payment returnPayment = await ApiClient.PostPaymentAsync(returnCase.Id, payment);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
            Assert.AreEqual(payment.BINNumber, returnPayment.BINNumber);
        }

        [TestMethod]
        public async Task PaymentTest_UpdateAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Payment payment = new Payment();
            payment.BINNumber = "456789";

            Payment returnPayment = await ApiClient.UpdatePaymentAsync(returnCase.Id, payment, returnCase.Payments[0].Id);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
            Assert.AreEqual(payment.BINNumber, returnPayment.BINNumber);
        }

        [TestMethod]
        public async Task PaymentTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Payment returnPayment = await ApiClient.GetPaymentAsync(returnCase.Id, returnCase.Payments[0].Id);

            Assert.IsTrue(returnPayment.Id != Guid.Empty);
            Assert.AreEqual(returnCase.Payments[0].BINNumber, returnPayment.BINNumber);
        }

        [TestMethod]
        public async Task PaymentTest_GetAllAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Payment payment = new Payment();
            payment.BINNumber = "445566";
            sampleCase.Payments.Add(payment);

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            IList<Payment> returnPayments = await ApiClient.GetPaymentAsync(returnCase.Id);

            Assert.IsTrue(returnPayments.Count > 1);
            Assert.AreEqual("123456", returnPayments[0].BINNumber);
            Assert.AreEqual("445566", returnPayments[1].BINNumber);
        }

        [TestMethod]
        public async Task PaymentTest_GetAllAsync_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateBlankCase();
                Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

                IList<Payment> payments = await ApiClient.GetPaymentAsync(returnCase.Id);
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
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString()) { };

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
