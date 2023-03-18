using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class TestRepository : ITestRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public TestRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public IEnumerable<Test> GetTests()
        {
            return _context.Tests.Where(t => t.IsActive == true).ToList();
        }

        public Test GetTestById(int id)
        {
            return _context.Tests.FirstOrDefault(t => t.Id == id  && t.IsActive == true);
        }

        public IEnumerable<Test> GetTestsPaginated(int page, int limit)
        {
            return _context.Tests.Where(t => t.IsActive == true).Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool AddTest(Test test)
        {
            _context.Add(test);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateTest(Test test)
        {
            _context.Entry(test).Property("TestName").IsModified = true;
            _context.Entry(test).Property("Description").IsModified = true;
            _context.Entry(test).Property("ExpireOn").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteTest(Test test)
        {
            _context.Entry(test).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}