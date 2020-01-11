using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using StudentsInternships.Data.Entities;
using StudentsInternships.Data.Repositories;
using StudentsInternships.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsInternships.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ApplicationsController(IApplicationsRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        [HttpGet]
        public async Task<ActionResult<AppsModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllApplicationsAsync();
                if (!results.Any())
                {
                    return NotFound("No applications in the database");
                }

                return _mapper.Map<AppsModel[]>(results);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AppsModel[]>> GetApplicationsById(UserModel model)
        {
            try
            {
                var results = await _repository.GetAppsById(model.UserId, model.City == null ? "company" : "student");
                return _mapper.Map<AppsModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost("apply")]
        public async Task<ActionResult<AppsModel>> ApplyToInternship(ApplyToIntModel model)
        {
            try
            { 
                var result = await _repository.ApplyToInternship(model.studentId,model.internshipId);
                if (result == 0)
                {
                    return BadRequest("Could not complete the application ");
                }

                var newApp = await _repository.GetAppById(result);

                return _mapper.Map<AppsModel>(newApp);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPatch]
        public async Task<ActionResult<AppsModel>> ChangeAppStatus(AppsModel model)
        {
            try
            {
                var app = _mapper.Map<Application>(model);

                var result = await _repository.ChangeAppStatus(app);
                if (result == null)
                {
                    return BadRequest("Could not complete the status change");
                }

                return _mapper.Map<AppsModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppById(int id)
        {
            try
            {
                var result = await _repository.DeleteApp(id);
                if (result == false)
                {
                    return BadRequest("Could not complete the app delete");
                }

                return Ok("Deleted with success");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }


    }
}
