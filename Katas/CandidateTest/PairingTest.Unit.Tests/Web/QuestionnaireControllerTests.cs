using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web
{
    using global::QuestionServiceWebApi;
    using global::QuestionServiceWebApi.Interfaces;
    using global::ServiceLayer;
    using QuestionServiceWebApi.Stubs;
    using ServiceLayer;
    using ServiceLayer.Stubs;

    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public async void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            IQuestionService fakeQuestionService = new FakeQuestionService();
            var questionnaireController = new QuestionnaireController(fakeQuestionService);

            //Act
            var result = await questionnaireController.Index();
            var viewModelResult = (QuestionnaireViewModel) result.ViewData.Model;

            //Assert
            Assert.That(viewModelResult.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(viewModelResult.QuestionsText.Count, Is.EqualTo(2));
        }
    }
}