using System.Web.Mvc;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ServiceLayer;

    public class QuestionnaireController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionnaireController() : this(new QuestionApiService())
        {
            _questionService.BaseUri = new Uri("http://localhost:50014");
        }

        public QuestionnaireController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /* ASYNC ACTION METHOD... IF REQUIRED... */
//        public async Task<ViewResult> Index()
//        {
//        }


        public async Task<ViewResult> Index()
        {
            var questions = await _questionService.GetAll();

            var questionnaireViewModel = new QuestionnaireViewModel
            {
                QuestionnaireTitle = questions.QuestionnaireTitle,
                QuestionsText = (IList<string>) questions.QuestionsText
            };

            return View(questionnaireViewModel);
        }
    }
}
