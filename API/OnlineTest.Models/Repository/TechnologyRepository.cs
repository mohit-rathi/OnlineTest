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

        public IEnumerable<Technology> GetTechnologies()
        {
            return _context.Technologies.ToList();
        }

        public Technology GetTechnologyById(int id)
        {
            return _context.Technologies.FirstOrDefault(t => t.Id == id);
        }
        
        public Technology GetTechnologyByName(string technologyName)
        {
            return _context.Technologies.FirstOrDefault(t => t.TechName == technologyName);
        }

        public IEnumerable<Technology> GetTechnologiesPaginated(int page, int limit)
        {
            return _context.Technologies.Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool AddTechnology(Technology technology)
        {
            _context.Add(technology);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateTechnology(Technology technology)
        {
            _context.Entry(technology).Property("TechName").IsModified = true;
            _context.Entry(technology).Property("ModifiedBy").IsModified = true;
            _context.Entry(technology).Property("ModifiedOn").IsModified = true;
            return _context.SaveChanges() > 0;
        }
    }
}