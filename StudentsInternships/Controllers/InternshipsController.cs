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
    public class InternshipsController : ControllerBase
    {
        private readonly IInternshipsRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public InternshipsController(IInternshipsRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<InternshipModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllInternshipsAsync();
                if (!results.Any())
                {
                    return NotFound("No Internships in the database");
                }

                return _mapper.Map<InternshipModel[]>(results);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

        }

        [HttpPost]
        public async Task<ActionResult<InternshipModel[]>> GetInternshipsById(UserModel model)
        {
            try
            {
                var results = await _repository.GetInternshipsById(model.UserId, model.City == null ? "company" : "student");
                if (!results.Any())
                {
                    return NotFound("No applications in the database");
                }

                return _mapper.Map<InternshipModel[]>(results);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<InternshipModel>> AddInternship(InternshipModel model)
        {
            try
            {
                var internship = _mapper.Map<Internship>(model);
                var result = await _repository.AddInternship(internship);
                if (result==null)
                {
                    return NotFound("Internship could not be saved");
                }

                return _mapper.Map<InternshipModel>(result);


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternship(int id)
        {
            try
            {
                var result = await _repository.DeleteInternship(id);
                if (result != true)
                {
                    return BadRequest("No internship deleted");
                }

                return Ok("Internship was deleted");


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
