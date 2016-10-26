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
    public class CustomerAddressTests : TestBase
    {
        [TestMethod]
        public void CustomerAddressTest_Post_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CustomerAddress address = new CustomerAddress();
            address.City = "Cork";

            CustomerAddress returnAddress = ApiClient.PostCustomerAddress(returnCase.Id, address);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.AreEqual("Cork", returnAddress.City);
        }

        [TestMethod]
        public void CustomerAddressTest_Update_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.City = "Dublin";

            CustomerAddress returnAddress = ApiClient.UpdateCustomerAddress(returnCase.Id, customerAddress,
                returnCase.Customer.Addresses.First().Id);
                

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.AreEqual("Dublin", returnAddress.City);
        }

        [TestMethod]
        public void CustomerAddressTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            Case returnCase = ApiClient.PostCase(sampleCase);

            CustomerAddress returnAddress = ApiClient.GetCustomerAddress(returnCase.Id,
                returnCase.Customer.Addresses.First().Id);

            Assert.IsTrue(returnAddress.Id != Guid.Empty);
            Assert.IsNotNull(returnAddress);
        }

        [TestMethod]
        public void CustomerAddressTest_GetAll_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithAddress();

            CustomerAddress address = new CustomerAddress();
            address.City = "Dublin";
            sampleCase.Customer.Addresses.Add(address);
            
            Case returnCase = ApiClient.PostCase(sampleCase);

            IList<CustomerAddress> returnCustomerAddresses = ApiClient.GetCustomerAddresses(returnCase.Id);

            Assert.IsTrue(returnCustomerAddresses.Count > 1);
        }

        [TestMethod]
        public void CustomerAddressTest_GetAll_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();
                Case returnCase = ApiClient.PostCase(sampleCase);

                IList<CustomerAddress> customerAddresses = ApiClient.GetCustomerAddresses(returnCase.Id);
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
