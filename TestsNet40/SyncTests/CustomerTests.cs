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
    public class CustomerTests : TestBase
    {
        [TestMethod]
        public void CustomerTest_Post_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Customer customer = new Customer();
            customer.FirstName = "Jane";
            customer.LastName = "Doe";
            
            Customer returnCustomer = ApiClient.PostCustomer(returnCase.Id, customer);

            Assert.IsTrue(returnCustomer.Id != Guid.Empty);
            Assert.AreEqual("Jane", returnCustomer.FirstName);
            Assert.AreEqual("Doe", returnCustomer.LastName);
        }

        [TestMethod]
        public void CustomerTest_Update_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Customer customer = returnCase.Customer;

            customer.FirstName = "Jane";
            customer.LastName = "Doe";
                
            Customer returnCustomer = ApiClient.UpdateCustomer(returnCase.Id, customer);

            Assert.IsTrue(returnCustomer.Id != Guid.Empty);
            Assert.AreEqual("Jane", returnCustomer.FirstName);
            Assert.AreEqual("Doe", returnCustomer.LastName);
        }

        [TestMethod]
        public void CustomerTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Customer returnCustomer = ApiClient.GetCustomer(returnCase.Id);

            Assert.IsTrue(returnCustomer.Id != Guid.Empty);
            Assert.AreEqual("John", returnCustomer.FirstName);
            Assert.AreEqual("Doe", returnCustomer.LastName);
        }

        [TestMethod]
        public void CustomerTest_Get_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();

                sampleCase.Customer = null;

                Case returnCase = ApiClient.PostCase(sampleCase);

                Customer returnCustomer = ApiClient.GetCustomer(returnCase.Id);
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
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString()){};

            return sampleCase;
        }

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
    }
        #endregion
}
