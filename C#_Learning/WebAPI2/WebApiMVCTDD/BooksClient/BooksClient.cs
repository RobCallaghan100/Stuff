namespace BooksClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using Models;
    using Newtonsoft.Json;

    public class BooksClient
    {
        private readonly HttpClient _client;
        public Uri BaseUri { get; private set; }

        public BooksClient(HttpClient client)
        {
            _client = client;
            BaseUri = new Uri("http://localhost:65282/");
        }

        public IEnumerable<Book> GetBooks()
        {
            var response = _client.GetAsync(new Uri(BaseUri, "api/book")).Result;

            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<Book>>(result);
        }

        public Book GetBook(int id)
        {
            var requestUri = new Uri(BaseUri, id.ToString(CultureInfo.InvariantCulture));

            var response = _client.GetAsync(requestUri).Result;

            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Book>(result);
        }

        public Tuple<Book, Uri> PostBook(Book book)
        {
            string content = JsonConvert.SerializeObject(book);
            var response = _client.PostAsync(BaseUri.ToString(), new StringContent(content)).Result;

            response.EnsureSuccessStatusCode();

            var newBookJson = response.Content.ReadAsStringAsync().Result;
            var newBook = JsonConvert.DeserializeObject<Book>(newBookJson);
            var location = response.Headers.Location;

            return new Tuple<Book, Uri>(newBook, location);
        } 
    }
}
