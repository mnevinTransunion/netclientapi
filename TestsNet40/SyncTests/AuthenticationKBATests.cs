using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Trustev.Domain.Entities;
using Trustev.Web;

namespace TestsNet40.SyncTests
{
    [TestClass]
    public class AuthenticationKBATests : TestBase
    {
        [TestMethod]
        public void GetKBATest()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            var detailedDecision = ApiClient.GetDetailedDecision(returnCase.Id);

            var kba = detailedDecision.Authentication.KBA;

            Assert.IsTrue(detailedDecision.Authentication.KBA.Questions.Count > 0);
        }


        [TestMethod]
        public void PostKBATest()
        {
            Case sampleCase = GenerateSampleCase();

            Case returnCase = ApiClient.PostCase(sampleCase);

            var detailedDecision = ApiClient.GetDetailedDecision(returnCase.Id);

            var kba = detailedDecision.Authentication.KBA;

            kba.Questions.First(x => x.QuestionText == "What is your mother's name?").Choices.First(x => x.ChoiceText == "Kate").Answer = true;

            var kbaAnwserResult = ApiClient.PostKBAResult(returnCase.Id, kba);

            var detailedDecisionAfterPostingAnswers = ApiClient.GetDetailedDecision(returnCase.Id);

            var multipassKBA = detailedDecisionAfterPostingAnswers.Authentication.KBA;

            multipassKBA.MultiPassQuestions.First(x => x.QuestionText == "What was your first car?").Choices.First(x => x.ChoiceText == "Ford Fiesta").Answer = true;

            var multipassKBAAnwserResult = ApiClient.PostKBAResult(returnCase.Id, multipassKBA);

            var detailedDecisionAfterPostingMultipassAnswers = ApiClient.GetDetailedDecision(returnCase.Id);

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
