namespace ServiceLayer
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;

    public class QuestionApiService : IQuestionService, IDisposable
    {
        public Uri BaseUri { get; set; }

        private readonly HttpClient _client;

        public QuestionApiService(HttpClient client)
        {
            _client = client;
        }

        public QuestionApiService() : this(new HttpClient())
        {
        }

        public async Task<Questionaire> GetAll()
        {
            var resultTask = await _client.GetStringAsync(new Uri(BaseUri, "api/questions"));

            return JsonConvert.DeserializeObject<Questionaire>(resultTask);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
