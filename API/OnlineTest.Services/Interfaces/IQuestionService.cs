using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IQuestionService
    {
        List<QuestionDTO> GetQuestionsByTestId(int testId);
        QuestionDTO GetQuestionById(int id);
        bool AddQuestion(QuestionDTO question);
        bool UpdateQuestion(QuestionDTO question);
    }
}