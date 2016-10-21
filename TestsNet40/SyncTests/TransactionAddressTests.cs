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
    public class TransactionAddressTests
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
        public void TransactionAddressTest_Post_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            TransactionAddress transactionAddress = new TransactionAddress();
            transactionAddress.City = "Cork";

            TransactionAddress returnAddress = ApiClient.PostTransactionAddress(returnCase.Id, transactionAddress);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.AreEqual("Cork", returnAddress.City);
        }

        [TestMethod]
        public void TransactionAddressTest_Update_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            Case returnCase = ApiClient.PostCase(sampleCase);

            TransactionAddress transactionAddress = new TransactionAddress();
            transactionAddress.City = "Dublin";

            TransactionAddress returnAddress = ApiClient.UpdateTransactionAddress(returnCase.Id, transactionAddress,
                returnCase.Transaction.Addresses[0].Id);
                
            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.AreEqual("Dublin", returnAddress.City);
        }

        [TestMethod]
        public void TransactionAddressTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            Case returnCase = ApiClient.PostCase(sampleCase);

            TransactionAddress returnAddress = ApiClient.GetTransactionAddress(returnCase.Id,
                returnCase.Transaction.Addresses[0].Id);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.IsNotNull(returnAddress);
        }

        [TestMethod]
        public void TransactionAddressTest_GetAll_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            TransactionAddress transactionAddress = new TransactionAddress();
            transactionAddress.City = "Dublin";
            sampleCase.Transaction.Addresses.Add(transactionAddress);
            
            Case returnCase = ApiClient.PostCase(sampleCase);

            IList<TransactionAddress> returnTransactionAddresses = ApiClient.GetTransactionAddresses(returnCase.Id);

            Assert.IsTrue(returnTransactionAddresses.Count > 1);
            Assert.AreEqual("Cork", returnTransactionAddresses[0].City);
            Assert.AreEqual("Dublin", returnTransactionAddresses[1].City);
        }

        [TestMethod]
        public void TransactionAddressTest_GetAll_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();
                Case returnCase = ApiClient.PostCase(sampleCase);

                IList<TransactionAddress> transactionAddresses = ApiClient.GetTransactionAddresses(returnCase.Id);
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
