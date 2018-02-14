using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trustev.Domain.Entities;
using Trustev.WebAsync;

namespace Tests.AsyncTests
{
    [TestClass]
    public class AuthenticationKBATests : TestBase
    {
        [TestMethod]
        public async Task IsKBAQuestionsCountGreatherThanZero()
        {
            Case sampleCase = GenerateSampleCase();
            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            var detailedDecision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            var kba = detailedDecision.Authentication.KBA;

            Assert.IsTrue(detailedDecision.Authentication.KBA.Questions.Count > 0);
        }

        [TestMethod]
        public async Task IsKBAStatusFailed()
        {
            Case sampleCase = GenerateSampleCase();
            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            var detailedDecision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            var kba = detailedDecision.Authentication.KBA;

            int i = 0;
            foreach (var question in kba.Questions)
            {
                question.Choices[i].Answer = true;
                i++;
            }

            foreach (var question in kba.MultiPassQuestions)
            {
                question.Choices[0].Answer = true;
            }

            var kbaAnwserResult = await ApiClient.PostKBAAnswersAsync(returnCase.Id, kba);

            var detailedDecisionAfterPostingAnswers = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            Assert.IsTrue(detailedDecision.Authentication.KBA.Status == Trustev.Domain.Enums.KBAStatus.Failed);
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

        #endregion
    }
}
