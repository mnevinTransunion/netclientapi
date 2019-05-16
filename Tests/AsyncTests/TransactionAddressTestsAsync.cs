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
    public class TransactionAddressTestsAsync : TestBase
    {
        [TestMethod]
        public async Task TransactionAddressTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            TransactionAddress transactionAddress = new TransactionAddress();
            transactionAddress.City = "Cork";

            TransactionAddress returnAddress = await ApiClient.PostTransactionAddressAsync(returnCase.Id, transactionAddress);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.AreEqual("Cork", returnAddress.City);
        }

        [TestMethod]
        public async Task TransactionAddressTest_UpdateAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            TransactionAddress transactionAddress = new TransactionAddress();
            transactionAddress.City = "Dublin";

            TransactionAddress returnAddress = await ApiClient.UpdateTransactionAddressAsync(returnCase.Id, transactionAddress,
                returnCase.Transaction.Addresses[0].Id);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.AreEqual("Dublin", returnAddress.City);
        }

        [TestMethod]
        public async Task TransactionAddressTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            TransactionAddress returnAddress = await ApiClient.GetTransactionAddressAsync(returnCase.Id,
                returnCase.Transaction.Addresses[0].Id);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.IsNotNull(returnAddress);
        }

        [TestMethod]
        public async Task TransactionAddressTest_GetAllAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            TransactionAddress transactionAddress = new TransactionAddress();
            transactionAddress.City = "Dublin";
            sampleCase.Transaction.Addresses.Add(transactionAddress);

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            IList<TransactionAddress> returnTransactionAddresses = await ApiClient.GetTransactionAddresssesAsync(returnCase.Id);

            Assert.IsTrue(returnTransactionAddresses.Count > 1);
            Assert.AreEqual("Cork", returnTransactionAddresses[0].City);
            Assert.AreEqual("Dublin", returnTransactionAddresses[1].City);
        }

        [TestMethod]
        public async Task TransactionAddressTest_GetAllAsync_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();
                Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

                IList<TransactionAddress> transactionAddresses = await ApiClient.GetTransactionAddresssesAsync(returnCase.Id);
            }
            catch (TrustevHttpException ex)
            {
                string message = ex.Message;
                responseCode = ex.HttpResponseCode;
            }

            Assert.AreEqual(HttpStatusCode.BadRequest, responseCode);
        }

        #region SetCaseContents
        private Case GenerateSampleCase()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Transaction = new Transaction()
                {
                    TotalTransactionValue = (decimal)10.99
                }
            };

            return sampleCase;
        }

        private Case GenerateSampleCaseWithAddress()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Transaction = new Transaction()
                {
                    Addresses =
                    {
                        new TransactionAddress()
                        {
                            City = "Cork"
                        }
                    }
                }
            };

            return sampleCase;
        }
    }
    #endregion
}
