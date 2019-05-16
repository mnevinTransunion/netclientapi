using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
    public class CustomerAddressTestsAsync : TestBase
    {
        [TestMethod]
        public async Task CustomerAddressTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CustomerAddress address = new CustomerAddress();
            address.City = "Cork";

            CustomerAddress returnAddress = await ApiClient.PostCustomerAddressAsync(returnCase.Id, address);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.AreEqual("Cork", returnAddress.City);
        }

        [TestMethod]
        public async Task CustomerAddressTest_UpdateAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.City = "Dublin";

            CustomerAddress returnAddress = await ApiClient.UpdateCustomerAddressAsync(returnCase.Id, customerAddress,
                returnCase.Customer.Addresses.First().Id);


            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.AreEqual("Dublin", returnAddress.City);
        }

        [TestMethod]
        public async Task CustomerAddressTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            CustomerAddress returnAddress = await ApiClient.GetCustomerAddressAsync(returnCase.Id,
                returnCase.Customer.Addresses.First().Id);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.IsNotNull(returnAddress);
        }

        [TestMethod]
        public async Task CustomerAddressTest_GetAllAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            CustomerAddress address = new CustomerAddress();
            address.City = "Dublin";
            sampleCase.Customer.Addresses.Add(address);

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            IList<CustomerAddress> returnCustomerAddresses = await ApiClient.GetCustomerAddressesAsync(returnCase.Id);

            Assert.IsTrue(returnCustomerAddresses.Count > 1);
        }

        [TestMethod]
        public async Task CustomerAddressTest_GetAllAsync_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();
                Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

                IList<CustomerAddress> customerAddresses = await ApiClient.GetCustomerAddressesAsync(returnCase.Id);
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
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                }
            };

            return sampleCase;
        }

        private Case GenerateSampleCaseWithAddress()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Addresses =
                    {
                        new CustomerAddress()
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
