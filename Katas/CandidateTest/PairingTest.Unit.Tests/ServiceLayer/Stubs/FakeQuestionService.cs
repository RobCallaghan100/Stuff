namespace PairingTest.Unit.Tests.ServiceLayer.Stubs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::ServiceLayer;
    using global::ServiceLayer.Models;

    public class FakeQuestionService : IQuestionService
    {
        public async Task<Questionaire> GetAll()
        {
            return new Questionaire
            {
                QuestionnaireTitle = "My expected quesitons",
                QuestionsText = new List<string>() { "Question 1", "Question 2" }
            };
        }

        public Uri BaseUri { get; set; }
    }
}