using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly OnlineTestContext _context;

        public QuestionRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> GetQuestionsByTestId(int testId)
        {
            var result = _context.Questions.Where(q => q.TestId == testId).ToList();
            return result;
        }

        public Question GetQuestionById(int id)
        {
            var result = _context.Questions.FirstOrDefault(q => q.Id == id);
            return result;
        }

        public bool AddQuestion(Question question)
        {
            _context.Add(question);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateQuestion(Question question)
        {
            _context.Update(question);
            return _context.SaveChanges() > 0;
        }
    }
}