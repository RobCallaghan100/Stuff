namespace ServiceLayer
{
    using System;
    using System.Threading.Tasks;
    using Models;

    public interface IQuestionService
    {
        Task<Questionaire> GetAll();
        Uri BaseUri { get; set; }
    }
}