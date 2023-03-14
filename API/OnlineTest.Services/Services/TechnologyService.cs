using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Services.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public ResponseDTO GetTechnologies()
        {
            var response = new ResponseDTO();
            try
            {
                var result = _technologyRepository.GetTechnologies().Select(t => new TechnologyDTO
                {
                    Id = t.Id,
                    TechName = t.TechName,
                    CreatedBy = t.CreatedBy,
                    CreatedOn = t.CreatedOn,
                    ModifiedBy = t.ModifiedBy,
                    ModifiedOn = t.ModifiedOn
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

        public ResponseDTO GetTechnologyById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var result = _technologyRepository.GetTechnologyById(id);
                if (result == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }
                var technology = new TechnologyDTO
                {
                    Id = result.Id,
                    TechName = result.TechName,
                    CreatedBy = result.CreatedBy,
                    CreatedOn = result.CreatedOn,
                    ModifiedBy = result.ModifiedBy,
                    ModifiedOn = result.ModifiedOn
                };
                response.Status = 200;
                response.Message = "Ok";
                response.Data = technology;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        
        public ResponseDTO GetTechnologyByName(string technologyName)
        {
            var response = new ResponseDTO();
            try
            {
                var result = _technologyRepository.GetTechnologyByName(technologyName);
                if (result == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }
                var technology = new TechnologyDTO
                {
                    Id = result.Id,
                    TechName = result.TechName,
                    CreatedBy = result.CreatedBy,
                    CreatedOn = result.CreatedOn,
                    ModifiedBy = result.ModifiedBy,
                    ModifiedOn = result.ModifiedOn
                };
                response.Status = 200;
                response.Message = "Ok";
                response.Data = technology;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTechnologiesPaginated(int page, int limit)
        {
            var response = new ResponseDTO();
            try
            {
                var result = _technologyRepository.GetTechnologiesPaginated(page, limit)
                    .Select(t => new TechnologyDTO
                    {
                        Id = t.Id,
                        TechName = t.TechName,
                        CreatedBy = t.CreatedBy,
                        CreatedOn = t.CreatedOn,
                        ModifiedBy = t.ModifiedBy,
                        ModifiedOn = t.ModifiedOn
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

        public ResponseDTO AddTechnology(TechnologyDTO technology)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyByName = _technologyRepository.GetTechnologyByName(technology.TechName);
                if (technologyByName != null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Technology already exists";
                    return response;
                }
                var addFlag = _technologyRepository.AddTechnology(new Technology
                {
                    TechName = technology.TechName,
                    CreatedBy = technology.CreatedBy,
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
                    response.Error = "Could not add technology";
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

        public ResponseDTO UpdateTechnology(TechnologyDTO technology)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologyById(technology.Id);
                if (technologyById == null)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Technology does not exist";
                    return response;
                }
                var technologyByName = _technologyRepository.GetTechnologyByName(technology.TechName);
                if (technologyByName != null)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Technology already exists";
                    return response;
                }
                var updateFlag = _technologyRepository.UpdateTechnology(new Technology
                {
                    Id = technology.Id,
                    TechName = technology.TechName,
                    ModifiedBy = technology.ModifiedBy,
                    ModifiedOn = DateTime.UtcNow
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
                    response.Error = "Could not update technology";
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