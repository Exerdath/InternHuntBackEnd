using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using StudentsInternships.Data.Entities;
using StudentsInternships.Data.Repositories;
using StudentsInternships.Models;
using System;
using System.Threading.Tasks;

namespace StudentsInternships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly ICompaniesRepository _companyRepository;

        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public UsersController(IUserRepository repository, IStudentsRepository studentsRepository,
            ICompaniesRepository companiesRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _studentsRepository = studentsRepository;
            _companyRepository = companiesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<UserModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllUsersAsync();
                return Ok(_mapper.Map<UserModel[]>(results));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            try
            {
                var existing = await _repository.GetUserAsync(id);

                if (existing == null)
                {
                    return NotFound("Username not in use");
                }

                return _mapper.Map<UserModel>(existing);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<UserModel>> Authenticate(string username, string password)
        {
            try
            {
                var result = await _repository.AuthenticateUser(username, password);
                if (result == null)
                {
                    return NotFound("Could not authenticate the user");
                }

                return _mapper.Map<UserModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }


        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(UserModel model)
        {
            try
            {
                var existing = await _repository.AuthenticateUserAsync(model.Username, model.Password);
                if (existing == null)
                {
                    return BadRequest("Authorization failed");
                }


                return _mapper.Map<UserModel>(existing);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPatch]
        public async Task<ActionResult<UserModel>> Patch(UserModel model)
        {
            UserModel result;
            try
            {
                if (model.City != null)
                {
                    int id = model.UserId;
                    Student student = await _studentsRepository.GetStudentByIdAsync(id);
                    student.Username = model.Username;
                    student.Password = model.Password;
                    student.City = _mapper.Map<City>(model.City);
                    student.Technology = _mapper.Map<Technology>(model.Technology);

                    result =_mapper.Map<UserModel>(await _studentsRepository.EditStudent(student));
                }
                else
                {
                    int id = model.UserId;
                    Company company = await _companyRepository.GetCompanyByIdAsync(id);
                    company.Username = model.Username;
                    company.Password = model.Password;
                    company.CompanyDescription = model.CompanyDescription;

                    result = _mapper.Map<UserModel>(await _companyRepository.EditCompany(company));
                }

                if (result == null)
                {
                    return BadRequest("Edit mode failed");
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }


    }
}
