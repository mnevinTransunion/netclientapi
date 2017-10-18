namespace TestsNet40.SyncTests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Trustev.Domain;
    using Trustev.Domain.Entities;
    using Trustev.Web;

    [TestClass]
    public class DigitalAuthentication : TestBase
    {
        // This is going to fail if you do not have the configuration set up or use a correct phone number 
        [TestMethod]
        public void SentOtpAsync()
        {
            Case sampleCase = GenerateSampleCase();
            Case returnCase = ApiClient.PostCase(sampleCase);

            var detailedDecision = ApiClient.GetDetailedDecision(returnCase.Id);
            Assert.IsTrue(detailedDecision.Authentication.OTP.Status == Enums.OTPStatus.Offered);

            DigitalAuthenticationResult auth = GenerateDigitalAuthenticationResult(returnCase.Id);
            DigitalAuthenticationResult checkAuthenticationResult = ApiClient.PostOtp(returnCase.Id, auth);
            Assert.IsTrue(checkAuthenticationResult.OTP.Status == Enums.OTPStatus.InProgress);
        }

        // This is going to fail if you do not have the configuration set up or use a correct phone number 
        [TestMethod]
        public void VerifyOtpAsync()
        {
            Case sampleCase = GenerateSampleCase();
            Case returnCase = ApiClient.PostCase(sampleCase);

            var detailedDecision = ApiClient.GetDetailedDecision(returnCase.Id);
            Assert.IsTrue(detailedDecision.Authentication.OTP.Status == Enums.OTPStatus.Offered);

            DigitalAuthenticationResult auth = GenerateDigitalAuthenticationResult(returnCase.Id);
            DigitalAuthenticationResult checkAuthenticationResult = ApiClient.PostOtp(returnCase.Id, auth);     
            Assert.IsTrue(checkAuthenticationResult.OTP.Status == Enums.OTPStatus.InProgress);

            // change number to the correct verification code received from sms
            var verificationCode =
                new DigitalAuthenticationResult() { OTP = new OTPResult(returnCase.Id) { Passcode = "1234" } };
            var checkPasswordDigitalAuthenticationResult = ApiClient.PutOtp(returnCase.Id, verificationCode);
            Assert.IsTrue(checkPasswordDigitalAuthenticationResult.OTP.Status == Enums.OTPStatus.Pass);
        }

        #region SetDigitalAuthentication

        private static DigitalAuthenticationResult GenerateDigitalAuthenticationResult(string caseId)
        {
            return new DigitalAuthenticationResult()
                       {
                           OTP = new OTPResult(caseId)
                                     {
                                         DeliveryType =
                                             Enums.PhoneDeliveryType
                                                 .Sms,
                                         Language = Enums
                                             .OTPLanguageEnum.EN
                                     }
                       };
        }

        #endregion

        #region SetCaseContents

        private static Case GenerateSampleCase()
        {
            return new Case(Guid.NewGuid(), Guid.NewGuid().ToString())
                       {
                           Customer = new Customer()
                                          {
                                              FirstName =
                                                  "John",
                                              LastName =
                                                  "Doe",

                                              // TODO change to a legit number
                                              PhoneNumber =
                                                  "3531111111"
                                          }
                       };
        }

        #endregion
    }
}