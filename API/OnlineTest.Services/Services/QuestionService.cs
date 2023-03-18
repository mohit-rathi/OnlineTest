﻿using AutoMapper;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class QuestionService : IQuestionService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestRepository _testRepository;
        #endregion

        #region Constructor
        public QuestionService(IMapper mapper, IQuestionRepository questionRepository, ITestRepository testRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _testRepository = testRepository;
        }
        #endregion

        #region Methods
        public ResponseDTO GetQuestionsByTestId(int testId)
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<GetQuestionDTO>>(_questionRepository.GetQuestionsByTestId(testId).ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
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
                var data = _mapper.Map<GetQuestionDTO>(test);
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO AddQuestion(AddQuestionDTO question)
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
                var addFlag = _questionRepository.AddQuestion(_mapper.Map<Question>(question));
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

        public ResponseDTO UpdateQuestion(UpdateQuestionDTO question)
        {
            var response = new ResponseDTO();
            try
            {
                var questionById = _questionRepository.GetQuestionById(question.Id);
                if (questionById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                var updateFlag = _questionRepository.UpdateQuestion(_mapper.Map<Question>(question));
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

        public ResponseDTO DeleteQuestion(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var questionById = _questionRepository.GetQuestionById(id);
                if (questionById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                questionById.IsActive = false;
                var deleteFlag = _questionRepository.DeleteQuestion(_mapper.Map<Question>(questionById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete question";
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
        #endregion
    }
}