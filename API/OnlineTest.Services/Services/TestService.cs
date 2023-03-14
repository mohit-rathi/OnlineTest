using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
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

        public List<TestDTO> GetTests()
        {
            return _testRepository.GetTests()
                .Select(t => new TestDTO
                {
                    Id = t.Id,
                    TestName = t.TestName,
                    Description = t.Description,
                    CreatedBy = t.CreatedBy,
                    CreatedTime = t.CreatedTime,
                    ExpireOn = t.ExpireOn,
                    TechnologyId = t.TechnologyId
                }).ToList();
        }

        public TestDTO GetTestById(int id)
        {
            var result = _testRepository.GetTestById(id);
            if (result == null)
                return null;
            return new TestDTO
            {
                Id = result.Id,
                TestName = result.TestName,
                Description = result.Description,
                CreatedBy = result.CreatedBy,
                CreatedTime = result.CreatedTime,
                ExpireOn = result.ExpireOn,
                TechnologyId = result.TechnologyId
            };
        }

        public List<TestDTO> GetTestsPaginated(int page, int limit)
        {
            return _testRepository.GetTestsPaginated(page, limit)
                .Select(t => new TestDTO
                {
                    Id = t.Id,
                    TestName = t.TestName,
                    Description = t.Description,
                    CreatedBy = t.CreatedBy,
                    CreatedTime = t.CreatedTime,
                    ExpireOn = t.ExpireOn,
                    TechnologyId = t.TechnologyId
                }).ToList();
        }

        public bool AddTest(TestDTO test)
        {
            return _testRepository.AddTest(new Test
            {
                TestName = test.TestName,
                Description = test.Description,
                CreatedBy = test.CreatedBy,
                CreatedTime = test.CreatedTime,
                ExpireOn = test.ExpireOn,
                TechnologyId = test.TechnologyId
            });
        }

        public bool UpdateTest(TestDTO test)
        {
            return _testRepository.UpdateTest(new Test
            {
                Id = test.Id,
                TestName = test.TestName,
                Description = test.Description,
                CreatedBy = test.CreatedBy,
                CreatedTime = test.CreatedTime,
                ExpireOn = test.ExpireOn,
                TechnologyId = test.TechnologyId
            });
        }
    }
}