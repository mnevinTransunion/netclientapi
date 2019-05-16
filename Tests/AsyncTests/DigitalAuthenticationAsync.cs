namespace Tests.AsyncTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Trustev.Domain;
    using Trustev.Domain.Entities;
    using Trustev.WebAsync;

    [TestClass]
    public class DigitalAuthenticationAsync: TestBase
    {

        // This is going to fail if you do not have the configuration set up or use a correct phone number 
        [TestMethod]
        [Ignore]
        [TestCategory("Disabled-Needs specific Configs")]
        public async Task SentOtpAsync()
        {
            Case sampleCase = GenerateSampleCase();
            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            var detailedDecision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);
            Assert.IsTrue(detailedDecision.Authentication.OTP.Status == Enums.OTPStatus.Offered);

            DigitalAuthenticationResult auth = GenerateDigitalAuthenticationResult();
            OTPResult checkAuthenticationResult = await ApiClient.PostOtpAsync(returnCase.Id, auth.OTP);
            Assert.IsTrue(checkAuthenticationResult.Status == Enums.OTPStatus.InProgress);
        }

        // This is going to fail if you do not have the configuration set up or use a correct phone number 
        [TestMethod]
        [Ignore]
        [TestCategory("Disabled-Needs specific Configs")]
        public async Task VerifyOtpAsync()
        {
            Case sampleCase = GenerateSampleCase();
            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            var detailedDecision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);
            Assert.IsTrue(detailedDecision.Authentication.OTP.Status == Enums.OTPStatus.Offered);

            DigitalAuthenticationResult auth = GenerateDigitalAuthenticationResult();
            var checkAuthenticationResult = await ApiClient.PostOtpAsync(returnCase.Id, auth.OTP);
            Assert.IsTrue(checkAuthenticationResult.Status == Enums.OTPStatus.InProgress);

            // if you want this to pass then change the passcode to the code received from the sms
            var verificationCode = new OTPResult() { Passcode = "1234", Timestamp = DateTime.Now} ;
            var checkPasswordDigitalAuthenticationResult = await ApiClient.PutOtpAsync(returnCase.Id, verificationCode);
            Assert.IsTrue(checkPasswordDigitalAuthenticationResult.Status == Enums.OTPStatus.Fail);
        }

        #region SetDigitalAuthentication
        private static DigitalAuthenticationResult GenerateDigitalAuthenticationResult()
        {
            return new DigitalAuthenticationResult()
            {
                OTP = new OTPResult()
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
                                      Customer =
                                          new Customer()
                                              {
                                                  FirstName =
                                                      "John",
                                                  LastName =
                                                      "Doe",

                                                  PhoneNumber
                                                      = "353878767543"
                                              }
                                  };
             
        }
        #endregion
    }
}