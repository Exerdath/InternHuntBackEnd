using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using StudentsInternships.Data.Repositories;
using StudentsInternships.Models;
using System;
using System.Threading.Tasks;

namespace StudentsInternships.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public StudentsController(IStudentsRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<StudentModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllStudentsAsync();
                return _mapper.Map<StudentModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentModel>> Get(int id)
        {
            try
            {
                var results = await _repository.GetStudentByIdAsync(id);
                return _mapper.Map<StudentModel>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }


    }
}
