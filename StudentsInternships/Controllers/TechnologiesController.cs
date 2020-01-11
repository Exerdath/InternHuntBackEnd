using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using StudentsInternships.Data.Repositories;
using StudentsInternships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    { 
        private readonly ITechnologiesRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public TechnologiesController(ITechnologiesRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<TechnologyModel[]>> Get()
        {
            try
            {
                var results = await _repository.getAllTechnologies();
                if (!results.Any())
                {
                    return NotFound("No technologies in the database");
                }

                return _mapper.Map<TechnologyModel[]>(results);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
