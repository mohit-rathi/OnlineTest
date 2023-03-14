using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly OnlineTestContext _context;

        public TestRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public IEnumerable<Test> GetTests()
        {
            return _context.Tests.ToList();
        }

        public Test GetTestById(int id)
        {
            return _context.Tests.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Test> GetTestsPaginated(int page, int limit)
        {
            return _context.Tests.Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool AddTest(Test test)
        {
            _context.Add(test);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateTest(Test test)
        {
            _context.Update(test);
            return _context.SaveChanges() > 0;
        }
    }
}