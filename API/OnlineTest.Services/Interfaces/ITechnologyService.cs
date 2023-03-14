using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface ITechnologyService
    {
        ResponseDTO GetTechnologies();
        ResponseDTO GetTechnologyById(int id);
        ResponseDTO GetTechnologyByName(string technologyName);
        ResponseDTO GetTechnologiesPaginated(int page, int limit);
        ResponseDTO AddTechnology(TechnologyDTO technology);
        ResponseDTO UpdateTechnology(TechnologyDTO technology);
    }
}