using OnlineTest.Models.Interfaces;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
    }
}