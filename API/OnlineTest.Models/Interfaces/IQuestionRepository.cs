namespace OnlineTest.Models.Interfaces
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestionsByTestId(int testId);
        Question GetQuestionById(int id);
        bool AddQuestion(Question question);
        bool UpdateQuestion(Question question);
    }
}