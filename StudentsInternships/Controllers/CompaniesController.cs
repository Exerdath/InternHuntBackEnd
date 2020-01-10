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
    public class CompaniesController:ControllerBase
    {
        private readonly ICompaniesRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public CompaniesController(ICompaniesRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        [HttpGet]
        public async Task<ActionResult<CompanyModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllCompaniesAsync();
                return _mapper.Map<CompanyModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
