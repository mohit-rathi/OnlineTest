using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IQuestionService
    {
        ResponseDTO GetQuestionsByTestId(int testId);
        ResponseDTO GetQuestionById(int id);
        ResponseDTO AddQuestion(QuestionDTO question);
        ResponseDTO UpdateQuestion(QuestionDTO question);
    }
}