using System;
using System.Dynamic;
using Models;
using Newtonsoft.Json;

namespace ElasticSearchService.Converters
{
    public class PriceToDocumentConverter : IDocumentConverter<Price>
    {
        public string Convert(Price value)
        {
            if (value == null)
            {
                throw new ApplicationException("Price value should not be null");
            }

            dynamic doc = new ExpandoObject();
            doc.doc = value;

            var document = JsonConvert.SerializeObject(doc);

            return document;
        }
    }
}
