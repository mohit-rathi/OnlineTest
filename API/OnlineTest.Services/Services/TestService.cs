using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly ITechnologyRepository _technologyRepository;

        public TestService(ITestRepository testRepository, ITechnologyRepository technologyRepository)
        {
            _testRepository = testRepository;
            _technologyRepository = technologyRepository;
        }

        public ResponseDTO GetTests()
        {
            var response = new ResponseDTO();
            try
            {
                var result = _testRepository.GetTests()
                    .Select(t => new TestDTO
                    {
                        Id = t.Id,
                        TestName = t.TestName,
                        Description = t.Description,
                        ExpireOn = t.ExpireOn,
                        TechnologyId = t.TechnologyId
                    }).ToList();
                response.Status = 200;
                response.Message = "Ok";
                response.Data = result;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTestById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var test = _testRepository.GetTestById(id);
                if (test == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test not found";
                    return response;
                }
                var result = new TestDTO
                {
                    Id = test.Id,
                    TestName = test.TestName,
                    Description = test.Description,
                    ExpireOn = test.ExpireOn,
                    TechnologyId = test.TechnologyId
                };
                response.Status = 200;
                response.Message = "Ok";
                response.Data = result;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTestsPaginated(int page, int limit)
        {
            var response = new ResponseDTO();
            try
            {
                var result = _testRepository.GetTestsPaginated(page, limit)
                    .Select(t => new TestDTO
                    {
                        Id = t.Id,
                        TestName = t.TestName,
                        Description = t.Description,
                        ExpireOn = t.ExpireOn,
                        TechnologyId = t.TechnologyId
                    }).ToList();
                response.Status = 200;
                response.Message = "Ok";
                response.Data = result;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO AddTest(TestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologyById(test.TechnologyId);
                if (technologyById == null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Technology does not exist";
                    return response;
                }
                var addFlag = _testRepository.AddTest(new Test
                {
                    TestName = test.TestName,
                    Description = test.Description,
                    CreatedBy = test.CreatedBy,
                    CreatedOn = DateTime.UtcNow,
                    ExpireOn = test.ExpireOn,
                    TechnologyId = test.TechnologyId
                });
                if (addFlag)
                {
                    response.Status = 204;
                    response.Message = "Created";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add test";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO UpdateTest(TestDTO test)
        {
            var response = new ResponseDTO();
            try
            {
                var updateFlag = _testRepository.UpdateTest(new Test
                {
                    Id = test.Id,
                    TestName = test.TestName,
                    Description = test.Description,
                    ExpireOn = test.ExpireOn
                });
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update test";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
    }
}