namespace OnlineTest.Models.Interfaces
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAnswers();
        Answer GetAnswerById(int id);
        bool AddAnswer(Answer answer);
        bool UpdateAnswer(Answer answer);
        bool DeleteAnswer(Answer answer);
    }
}