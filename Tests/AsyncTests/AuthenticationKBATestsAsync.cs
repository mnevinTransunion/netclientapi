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
    public class AuthenticationKBATestsAsync : TestBase
    {
        [TestMethod]
        [Ignore]
        [TestCategory("Disabled-Needs specific Configs")]
        public async Task IsKBAQuestionsCountGreatherThanZero_Async()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            var detailedDecision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            var kba = detailedDecision.Authentication.KBA;

            Assert.IsTrue(detailedDecision.Authentication.KBA.Questions.Count > 0);
        }

        [TestMethod]
        [Ignore]
        public async Task IsKBAStatusFailed_Async()
        {
            Case sampleCase = GenerateSampleCase();
            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            var detailedDecision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            var kba = detailedDecision.Authentication.KBA;

            var kbaAnwserResult = await ApiClient.PostKBAResultAsync(returnCase.Id, kba);

            var detailedDecisionAfterPostingAnswers = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            Assert.IsTrue(detailedDecisionAfterPostingAnswers.Authentication.KBA.Status == Trustev.Domain.Enums.KBAStatus.Failed);
        }


        [TestMethod]
        [Ignore]
        [TestCategory("Disabled-Needs specific Configs")]
        public async Task IsKBAStatusMultipassed_Async()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = await ApiClient.PostCaseAsync(sampleCase);

            var detailedDecision = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            var kba = detailedDecision.Authentication.KBA;

            kba.Questions.First(x => x.QuestionText == "What is your mother's name?").Choices.First(x => x.ChoiceText == "Kate").Answer = true;

            var kbaAnwserResult = await ApiClient.PostKBAResultAsync(returnCase.Id, kba);

            var detailedDecisionAfterPostingAnswers = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            var multipassKBA = detailedDecisionAfterPostingAnswers.Authentication.KBA;

            multipassKBA.MultiPassQuestions.First(x => x.QuestionText == "What was your first car?").Choices.First(x => x.ChoiceText == "Ford Fiesta").Answer = true;

            var multipassKBAAnwserResult = await ApiClient.PostKBAResultAsync(returnCase.Id, multipassKBA);

            var detailedDecisionAfterPostingMultipassAnswers = await ApiClient.GetDetailedDecisionAsync(returnCase.Id);

            Assert.IsTrue(detailedDecisionAfterPostingAnswers.Authentication.KBA.Status == Trustev.Domain.Enums.KBAStatus.MultiPassOffered);

            Assert.IsTrue(detailedDecisionAfterPostingMultipassAnswers.Authentication.KBA.Status == Trustev.Domain.Enums.KBAStatus.Passed);
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
