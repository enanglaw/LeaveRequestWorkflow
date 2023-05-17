using AutoMapper;
using LeaveRequest.Application.Contracts.Persistence;
using LeaveRequest.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveRequest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryRepository repository, IMapper mapper, ILogger<CountryController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Country>>> GetEmployees()
        {

            var listOfCountries= (await _repository.ListAllAsync());
            if (listOfCountries == null)
            {
                _logger.Log(LogLevel.Information,$"No registered Country.");
                return BadRequest($"No registered Country.");
            }
            var mappedListOfCountries = _mapper.Map<List<Country>>(listOfCountries);
            return Ok(mappedListOfCountries);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Country>> GetEmployee(int countryId)
        {

            var country = (await _repository.GetByIdAsync(countryId));

            if (country == null)
            {
                _logger.Log(LogLevel.Information, $"No registered Country with country id: {countryId}");
                return BadRequest($"No registered Country with country id: {countryId}");
            }
            var mappedCountry = _mapper.Map<Country>(country);
            return Ok(mappedCountry);
        }
    }
}
