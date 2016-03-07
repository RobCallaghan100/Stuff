namespace ServiceLayer.Models
{
    using System.Collections.Generic;

    public class Questionaire
    {
        public string QuestionnaireTitle { get; set; }
      
        public IEnumerable<string> QuestionsText { get; set; }
    }
}
