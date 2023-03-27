using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class AnswerSheetRepository : IAnswerSheetRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public AnswerSheetRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public int AddAnswerSheet(AnswerSheet answerSheet)
        {
            _context.Add(answerSheet);
            if (_context.SaveChanges() > 0)
                return answerSheet.Id;
            else
                return 0;
        }
        #endregion
    }
}