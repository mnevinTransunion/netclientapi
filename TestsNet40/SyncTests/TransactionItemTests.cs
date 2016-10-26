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
    public class TransactionItemTests : TestBase
    {
        [TestMethod]
        public void TransactionItemTest_Post_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            TransactionItem transactionItem = new TransactionItem();
            transactionItem.ItemValue = (decimal)4.99;

            TransactionItem returnItem = ApiClient.PostTransactionItem(returnCase.Id, transactionItem);

            Assert.IsTrue(returnItem.Id != Guid.Empty);
            Assert.AreEqual((decimal)4.99, returnItem.ItemValue);
        }

        [TestMethod]
        public void TransactionItemTest_Update_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithItem();

            Case returnCase = ApiClient.PostCase(sampleCase);

            TransactionItem transactionItem = new TransactionItem();
            transactionItem.ItemValue = (decimal)4.99;

            TransactionItem returnItem = ApiClient.UpdateTransactionItem(returnCase.Id, transactionItem,
                returnCase.Transaction.Items[0].Id);
                
            Assert.IsTrue(returnItem.Id != Guid.Empty);
            Assert.AreEqual((decimal)4.99, returnItem.ItemValue);
        }

        [TestMethod]
        public void TransactionItemTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithItem();

            Case returnCase = ApiClient.PostCase(sampleCase);

            TransactionItem returnItem = ApiClient.GetTransactionItem(returnCase.Id,
                returnCase.Transaction.Items[0].Id);

            Assert.IsTrue(returnItem.Id != Guid.Empty);
            Assert.IsNotNull(returnItem);
        }

        [TestMethod]
        public void TransactionItemTest_GetAll_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithItem();

            TransactionItem transactionItem = new TransactionItem();
            transactionItem.ItemValue = (decimal) 8.99;
            sampleCase.Transaction.Items.Add(transactionItem);
            
            Case returnCase = ApiClient.PostCase(sampleCase);

            IList<TransactionItem> returnTransactionItems = ApiClient.GetTransactionItems(returnCase.Id);

            Assert.IsTrue(returnTransactionItems.Count > 1);
            Assert.AreEqual((decimal)6.99, returnTransactionItems[0].ItemValue);
            Assert.AreEqual((decimal)8.99, returnTransactionItems[1].ItemValue);
        }

        [TestMethod]
        public void TransactionItemTest_GetAll_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();
                Case returnCase = ApiClient.PostCase(sampleCase);

                IList<TransactionItem> transactionItems = ApiClient.GetTransactionItems(returnCase.Id);
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
