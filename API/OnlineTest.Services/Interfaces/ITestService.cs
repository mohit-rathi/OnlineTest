using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface ITestService
    {
        List<TestDTO> GetTests();
        TestDTO GetTestById(int id);
        List<TestDTO> GetTestsPaginated(int page, int limit);
        bool AddTest(TestDTO test);
        bool UpdateTest(TestDTO test);
    }
}