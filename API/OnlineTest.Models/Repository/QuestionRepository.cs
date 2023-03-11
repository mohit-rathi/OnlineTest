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
    }
}