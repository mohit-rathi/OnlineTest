using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface ITestService
    {
        ResponseDTO GetTests();
        ResponseDTO GetTestById(int id);
        ResponseDTO GetTestsPaginated(int page, int limit);
        ResponseDTO AddTest(TestDTO test);
        ResponseDTO UpdateTest(TestDTO test);
    }
}