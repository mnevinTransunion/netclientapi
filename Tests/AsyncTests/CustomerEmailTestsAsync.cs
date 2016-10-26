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
    public class CustomerEmailTestsAsync : TestBase
    {
        [TestMethod]
        public async Task CustomerEmailTest_PostAsync_200()
        {
            Case sampleCase = this.GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Email email = new Email();
            email.EmailAddress = "test@test.com";

            Email returnEmailAddress = await ApiClient.PostEmailAsync(returnCase.Id, email);

            Assert.IsTrue(returnEmailAddress.Id != Guid.Empty);
            Assert.AreEqual("test@test.com", returnEmailAddress.EmailAddress);
        }

        [TestMethod]
        public async Task CustomerEmailTest_UpdateAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithEmailAddress();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Email email = new Email();
            email.EmailAddress = "test2@test.com";

            Email returnEmailAddress = await ApiClient.UpdateEmailAsync(returnCase.Id, email,
                returnCase.Customer.Emails.First().Id);


            Assert.IsTrue(returnEmailAddress.Id != Guid.Empty);
            Assert.AreEqual("test2@test.com", returnEmailAddress.EmailAddress);
        }

        [TestMethod]
        public async Task CustomerEmailTest_GetAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithEmailAddress();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            Email returnEmailAddress = await ApiClient.GetEmailAsync(returnCase.Id,
                returnCase.Customer.Emails.First().Id);

            Assert.IsTrue(returnEmailAddress.Id != Guid.Empty);
            Assert.AreEqual("test@test.com", returnEmailAddress.EmailAddress);
        }

        [TestMethod]
        public async Task CustomerEmailTest_GetAllAsync_200()
        {
            Case sampleCase = this.GenerateSampleCaseWithEmailAddress();

            Email email = new Email();
            email.EmailAddress = "test2@test.com";
            sampleCase.Customer.Emails.Add(email);

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            IList<Email> returnEmailAddresses = await ApiClient.GetEmailsAsync(returnCase.Id);

            Assert.IsTrue(returnEmailAddresses.Count > 1);
            Assert.AreEqual("test@test.com", returnEmailAddresses[0].EmailAddress);
            Assert.AreEqual("test2@test.com", returnEmailAddresses[1].EmailAddress);
        }

        [TestMethod]
        public async Task CustomerEmailTest_GetAllAsync_400()
        {
            HttpStatusCode responseCode = HttpStatusCode.OK;

            try
            {
                Case sampleCase = this.GenerateSampleCase();
                Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

                IList<Email> customerEmails = await ApiClient.GetEmailsAsync(returnCase.Id);
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
