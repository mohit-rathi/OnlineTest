using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly OnlineTestContext _context;

        public TechnologyRepository(OnlineTestContext context)
        {
            _context = context;
        }
    }
}