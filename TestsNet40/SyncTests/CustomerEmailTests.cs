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
    public class CustomerEmailTests
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
        public void CustomerEmailTest_Post_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Email email = new Email();
            email.EmailAddress = "test@test.com";

            Email returnEmailAddress = ApiClient.PostEmail(returnCase.Id, email);

            Assert.IsTrue(returnEmailAddress.Id != Guid.Empty);
            Assert.AreEqual("test@test.com", returnEmailAddress.EmailAddress);
        }

        [TestMethod]
        public void CustomerEmailTest_Update_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithEmailAddress();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Email email = new Email();
            email.EmailAddress = "test2@test.com";

            Email returnEmailAddress = ApiClient.UpdateEmail(returnCase.Id, email,
                returnCase.Customer.Emails.First().Id);
                

            Assert.IsTrue(returnEmailAddress.Id != Guid.Empty);
            Assert.AreEqual("test2@test.com", returnEmailAddress.EmailAddress);
        }

        [TestMethod]
        public void CustomerEmailTest_Get_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithEmailAddress();

            Case returnCase = ApiClient.PostCase(sampleCase);

            Email returnEmailAddress = ApiClient.GetEmail(returnCase.Id,
                returnCase.Customer.Emails.First().Id);

            Assert.IsTrue(returnEmailAddress.Id != Guid.Empty);
            Assert.AreEqual("test@test.com", returnEmailAddress.EmailAddress);
        }

        [TestMethod]
        public void CustomerEmailTest_GetAll_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithEmailAddress();

            Email email = new Email();
            email.EmailAddress = "test2@test.com";
            sampleCase.Customer.Emails.Add(email);
            
            Case returnCase = ApiClient.PostCase(sampleCase);

            IList<Email> returnEmailAddresses = ApiClient.GetEmails(returnCase.Id);

            Assert.IsTrue(returnEmailAddresses.Count > 1);
            Assert.AreEqual("test@test.com", returnEmailAddresses[0].EmailAddress);
            Assert.AreEqual("test2@test.com", returnEmailAddresses[1].EmailAddress);
        }

        [TestMethod]
        public void CustomerEmailTest_GetAll_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();
                Case returnCase = ApiClient.PostCase(sampleCase);

                IList<Email> customerEmails = ApiClient.GetEmails(returnCase.Id);
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

        private Case GenerateSampleCaseWithEmailAddress()
        {
            Case sampleCase = new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
            {
                Customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
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
