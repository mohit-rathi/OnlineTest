using OnlineTest.Models.Interfaces;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
    }
}