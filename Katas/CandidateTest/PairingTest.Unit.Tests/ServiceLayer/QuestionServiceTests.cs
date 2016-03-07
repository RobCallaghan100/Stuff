namespace PairingTest.Unit.Tests.ServiceLayer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using global::ServiceLayer;
    using global::ServiceLayer.Models;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class QuestionServiceTests
    {
        [TestCase("questionaire title 1", new string[] {"", "", ""} )]
        [TestCase("questionaire title 2", new string[] { "", "" })]
        public async void GetAllShouldReturnQuestionaire(string title, string[] questions)
        {
            var questionService = GetQuestionApiService(title, questions);

            var questionaire = await questionService.GetAll();
                
            Assert.That(questionaire, Is.Not.Null);
            Assert.That(questionaire.QuestionnaireTitle, Is.EqualTo(title));
            Assert.That(questionaire.QuestionsText.Count(), Is.EqualTo(questions.Length));
        }

        private static QuestionApiService GetQuestionApiService(string title, string[] questions)
        {
            var responseMessage = new HttpResponseMessage
            {
                Content = new FakeHttpContent(GetQuestionaireJson(title, questions))
            };
            var messageHandler = new FakeHttpMessageHandler(responseMessage);
            var client = new HttpClient(messageHandler);
            var questionService = new QuestionApiService(client)
            {
                BaseUri = new Uri("http://baseuri.com")
            };
            return questionService;
        }

        private static string GetQuestionaireJson(string title, string[] questions)
        {
            Questionaire expectedQuestionaire = new Questionaire
            {
                QuestionnaireTitle = title,
                QuestionsText = questions
            };

            return JsonConvert.SerializeObject(expectedQuestionaire);
        }
    }

    public class FakeHttpContent : HttpContent
    {
        private readonly string _content;

        public FakeHttpContent(string content)
        {
            _content = content;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(_content);
            await stream.WriteAsync(byteArray, 0, _content.Length);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _content.Length;

            return true;
        }
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _responseMessage;

        public FakeHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            _responseMessage = responseMessage;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseTask = new TaskCompletionSource<HttpResponseMessage>();
            responseTask.SetResult(_responseMessage);

            return responseTask.Task;
        }
    }
}
