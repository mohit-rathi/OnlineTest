using OnlineTest.Models.Interfaces;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
    }
}