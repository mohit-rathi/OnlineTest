using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestRepository _testRepository;

        public QuestionService(IQuestionRepository questionRepository, ITestRepository testRepository)
        {
            _questionRepository = questionRepository;
            _testRepository = testRepository;
        }

        public ResponseDTO GetQuestionsByTestId(int testId)
        {
            var response = new ResponseDTO();
            try
            {
                var result = _questionRepository.GetQuestionsByTestId(testId)
                    .Select(q => new QuestionDTO
                    {
                        Id = q.Id,
                        QuestionName = q.QuestionName,
                        Que = q.Que,
                        Type = q.Type,
                        Weightage = q.Weightage,
                        SortOrder = q.SortOrder,
                        TestId = q.TestId
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

        public ResponseDTO GetQuestionById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var test = _questionRepository.GetQuestionById(id);
                if (test == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                var result = new QuestionDTO
                {
                    Id = test.Id,
                    QuestionName = test.QuestionName,
                    Que = test.Que,
                    Type = test.Type,
                    Weightage = test.Weightage,
                    SortOrder = test.SortOrder,
                    TestId = test.TestId
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

        public ResponseDTO AddQuestion(QuestionDTO question)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(question.TestId);
                if (testById == null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Test does not exist";
                    return response;
                }
                var addFlag = _questionRepository.AddQuestion(new Question
                {
                    QuestionName = question.QuestionName,
                    Que = question.Que,
                    Type = question.Type,
                    Weightage = question.Weightage,
                    SortOrder = question.SortOrder,
                    IsActive = true,
                    TestId = question.TestId,
                    CreatedBy = question.CreatedBy,
                    CreatedOn = DateTime.UtcNow
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
                    response.Error = "Could not add question";
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

        public ResponseDTO UpdateQuestion(QuestionDTO question)
        {
            var response = new ResponseDTO();
            try
            {
                var updateFlag = _questionRepository.UpdateQuestion(new Question
                {
                    Id = question.Id,
                    QuestionName = question.QuestionName,
                    Que = question.Que,
                    Weightage = question.Weightage,
                    SortOrder = question.SortOrder,
                    IsActive = question.IsActive
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
                    response.Error = "Could not update question";
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