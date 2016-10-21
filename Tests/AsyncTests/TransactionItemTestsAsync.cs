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
    public class TransactionItemTestsAsync
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
        public async Task TransactionItemTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            TransactionItem transactionItem = new TransactionItem();
            transactionItem.ItemValue = (decimal)4.99;

            TransactionItem returnItem = await ApiClient.PostTransactionItemAsync(returnCase.Id, transactionItem);

            Assert.IsTrue(returnItem.Id != Guid.Empty);
            Assert.AreEqual((decimal)4.99, returnItem.ItemValue);
        }

        [TestMethod]
        public async Task TransactionItemTest_UpdateAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithItem();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            TransactionItem transactionItem = new TransactionItem();
            transactionItem.ItemValue = (decimal)4.99;

            TransactionItem returnItem = await ApiClient.UpdateTransactionItemAsync(returnCase.Id, transactionItem,
                returnCase.Transaction.Items[0].Id);

            Assert.IsTrue(returnItem.Id != Guid.Empty);
            Assert.AreEqual((decimal)4.99, returnItem.ItemValue);
        }

        [TestMethod]
        public async Task TransactionItemTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithItem();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            TransactionItem returnItem = await ApiClient.GetTransactionItemAsync(returnCase.Id,
                returnCase.Transaction.Items[0].Id);

            Assert.IsTrue(returnItem.Id != Guid.Empty);
            Assert.IsNotNull(returnItem);
        }

        [TestMethod]
        public async Task TransactionItemTest_GetAllAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithItem();

            TransactionItem transactionItem = new TransactionItem();
            transactionItem.ItemValue = (decimal)8.99;
            sampleCase.Transaction.Items.Add(transactionItem);

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            IList<TransactionItem> returnTransactionItems = await ApiClient.GetTransactionItemsAsync(returnCase.Id);

            Assert.IsTrue(returnTransactionItems.Count > 1);
            Assert.AreEqual((decimal)6.99, returnTransactionItems[0].ItemValue);
            Assert.AreEqual((decimal)8.99, returnTransactionItems[1].ItemValue);
        }

        [TestMethod]
        public async Task TransactionItemTest_GetAllAsync_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();
                Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

                IList<TransactionItem> transactionItems = await ApiClient.GetTransactionItemsAsync(returnCase.Id);
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

        private Case GenerateSampleCaseWithItem()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Transaction = new Transaction()
                {
                    Items =
                    {
                        new TransactionItem()
                        {
                            ItemValue = (decimal)6.99
                        }
                    }
                }
            };

            return sampleCase;
        }
    }
    #endregion
}
