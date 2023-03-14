using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
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

        public List<QuestionDTO> GetQuestionsByTestId(int testId)
        {
            return _questionRepository.GetQuestionsByTestId(testId)
                .Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    QuestionName = q.QuestionName,
                    Que = q.Que,
                    Type = q.Type,
                    Weightage = q.Weightage,
                    TestId = q.TestId
                }).ToList();
        }

        public QuestionDTO GetQuestionById(int id)
        {
            var result = _questionRepository.GetQuestionById(id);
            if (result == null)
                return null;
            return new QuestionDTO
            {
                Id = result.Id,
                QuestionName = result.QuestionName,
                Que = result.Que,
                Type = result.Type,
                Weightage = result.Weightage,
                TestId = result.TestId
            };
        }

        public bool AddQuestion(QuestionDTO question)
        {
            return _questionRepository.AddQuestion(new Question
            {
                Id = question.Id,
                QuestionName = question.QuestionName,
                Que = question.Que,
                Type = question.Type,
                Weightage = question.Weightage,
                TestId = question.TestId
            });
        }

        public bool UpdateQuestion(QuestionDTO question)
        {
            return _questionRepository.UpdateQuestion(new Question
            {
                Id = question.Id,
                QuestionName = question.QuestionName,
                Que = question.Que,
                Type = question.Type,
                Weightage = question.Weightage,
                TestId = question.TestId
            });
        }
    }
}