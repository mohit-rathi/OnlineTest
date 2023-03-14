namespace OnlineTest.Models.Interfaces
{
    public interface ITechnologyRepository
    {
        IEnumerable<Technology> GetTechnologies();
        Technology GetTechnologyById(int id);
        Technology GetTechnologyByName(string technologyName);
        IEnumerable<Technology> GetTechnologiesPaginated(int page, int limit);
        bool AddTechnology(Technology technology);
        bool UpdateTechnology(Technology technology);
    }
}