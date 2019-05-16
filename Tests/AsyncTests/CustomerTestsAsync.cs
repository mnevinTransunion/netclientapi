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
    public class CustomerTestsAsync : TestBase
    {
        [TestMethod]
        public async Task CustomerTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateBlankCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Customer customer = new Customer();
            customer.FirstName = "Jane";
            customer.LastName = "Doe";

            Customer returnCustomer = await ApiClient.PostCustomerAsync(returnCase.Id, customer);

            Assert.IsTrue(returnCustomer.Id != Guid.Empty);
            Assert.AreEqual("Jane", returnCustomer.FirstName);
            Assert.AreEqual("Doe", returnCustomer.LastName);
        }

        [TestMethod]
        public async Task CustomerTest_UpdateAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Customer customer = returnCase.Customer;

            customer.FirstName = "Jane";
            customer.LastName = "Doe";

            Customer returnCustomer = await ApiClient.UpdateCustomerAsync(returnCase.Id, customer);

            Assert.IsTrue(returnCustomer.Id != Guid.Empty);
            Assert.AreEqual("Jane", returnCustomer.FirstName);
            Assert.AreEqual("Doe", returnCustomer.LastName);
        }

        [TestMethod]
        public async Task CustomerTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Customer returnCustomer = await ApiClient.GetCustomerAsync(returnCase.Id);

            Assert.IsTrue(returnCustomer.Id != Guid.Empty);
            Assert.AreEqual("John", returnCustomer.FirstName);
            Assert.AreEqual("Doe", returnCustomer.LastName);
        }

        [TestMethod]
        public async Task CustomerTest_GetAsync_404()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();

                sampleCase.Customer = null;

                Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

                Customer returnCustomer = await ApiClient.GetCustomerAsync(returnCase.Id);
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
