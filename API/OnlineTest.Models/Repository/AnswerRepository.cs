using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public AnswerRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public IEnumerable<Answer> GetAnswers()
        {
            return _context.Answers.Where(a => a.IsActive == true).ToList();
        }

        public Answer GetAnswerById(int id)
        {
            return _context.Answers.FirstOrDefault(a => a.Id == id && a.IsActive == true);
        }

        public bool AddAnswer(Answer answer)
        {
            _context.Add(answer);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateAnswer(Answer answer)
        {
            _context.Entry(answer).Property("Ans").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteAnswer(Answer answer)
        {
            _context.Entry(answer).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}