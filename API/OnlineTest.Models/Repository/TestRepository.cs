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
    }
}