using AutoMapper;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class AnswerService : IAnswerService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        #endregion

        #region Constructor
        public AnswerService(IMapper mapper, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
        }
        #endregion

        #region Methods
        public ResponseDTO GetAnswers()
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<GetAnswerDTO>>(_answerRepository.GetAnswers().ToList());
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

        public ResponseDTO GetAnswerById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<GetAnswerDTO>(_answerRepository.GetAnswerById(id));
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

        public ResponseDTO AddAnswer(AddAnswerDTO answer)
        {
            var response = new ResponseDTO();
            try
            {
                var addFlag = _answerRepository.AddAnswer(_mapper.Map<Answer>(answer));
                if (addFlag)
                {
                    response.Status = 204;
                    response.Message = "Created";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add answer";
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

        public ResponseDTO UpdateAnswer(UpdateAnswerDTO answer)
        {
            var response = new ResponseDTO();
            try
            {
                var answerById = _answerRepository.GetAnswerById(answer.Id);
                if (answerById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Answer not found";
                    return response;
                }
                var updateFlag = _answerRepository.UpdateAnswer(_mapper.Map<Answer>(answer));
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update answer";
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

        public ResponseDTO DeleteAnswer(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var answerById = _answerRepository.GetAnswerById(id);
                if (answerById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Answer not found";
                    return response;
                }
                answerById.IsActive = false;
                var deleteFlag = _answerRepository.DeleteAnswer(_mapper.Map<Answer>(answerById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete answer";
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