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
    public class TransactionTestsAsync : TestBase
    {
        [TestMethod]
        public async Task TransactionTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Transaction transaction = new Transaction();
            transaction.TotalTransactionValue = (decimal)12.99;
            Email email = new Email();
            email.EmailAddress = "test@test.com";
            transaction.Emails.Add(email);


            Transaction returnTransaction = await ApiClient.PostTransactionAsync(returnCase.Id, transaction);

            Assert.IsTrue(returnTransaction.Id != Guid.Empty);
            Assert.AreEqual(transaction.TotalTransactionValue, returnTransaction.TotalTransactionValue);
            Assert.AreEqual(transaction.Emails[0].EmailAddress, returnTransaction.Emails[0].EmailAddress);
        }

        [TestMethod]
        public async Task TransactionTest_UpdateAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Transaction transaction = new Transaction();
            transaction.TotalTransactionValue = (decimal)20.99;
            Email email = new Email();
            email.EmailAddress = "test2@test.com";
            transaction.Emails.Add(email);

            Transaction returnTransaction = await ApiClient.UpdateTransactionAsync(returnCase.Id, transaction);

            Assert.IsTrue(returnTransaction.Id != Guid.Empty);
            Assert.AreEqual(transaction.TotalTransactionValue, returnTransaction.TotalTransactionValue);
            Assert.AreEqual("test2@test.com", returnTransaction.Emails[0].EmailAddress);
        }

        [TestMethod]
        public async Task TransactionTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Transaction returnTransaction = await ApiClient.GetTransactionAsync(returnCase.Id);

            Assert.IsTrue(returnTransaction.Id != Guid.Empty);
            Assert.AreEqual(returnCase.Transaction.TotalTransactionValue, returnTransaction.TotalTransactionValue);
        }

        [TestMethod]
        public async Task TransactionTest_GetAsync_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateBlankCase();

                Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

                Transaction returnTransaction = await ApiClient.GetTransactionAsync(returnCase.Id);
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

        private Case GenerateSampleCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Transaction = new Transaction()
                {
                    TotalTransactionValue = (decimal)10.99,
                    Emails = new List<Email>()
                    {
                        new Email()
                        {
                            EmailAddress = "test@test.com"
                        }
                    }
                }
            };

            return sampleCase;
        }
    }
    #endregion
}
