namespace OnlineTest.Models.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetTests();
        Test GetTestById(int id);
        IEnumerable<Test> GetTestsPaginated(int page, int limit);
        bool AddTest(Test test);
        bool UpdateTest(Test test);
    }
}