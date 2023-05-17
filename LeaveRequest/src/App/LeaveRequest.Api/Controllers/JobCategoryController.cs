using AutoMapper;
using LeaveRequest.Application.Contracts.Persistence;
using LeaveRequest.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveRequest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private readonly IJobCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<JobCategoryController> _logger;

        public JobCategoryController(IJobCategoryRepository categoryRepository, IMapper mapper, ILogger<JobCategoryController> logger)
        {
           _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<JobCategory>>> GetJobCategories()
        {
            var listOfJobCategories = await _categoryRepository.ListAllAsync();
            if (listOfJobCategories == null)
            {
                _logger.Log(LogLevel.Information, $"No registered Job Categories");
                return BadRequest($"No registered Job Categories");
            }
            var mappedListOfJobCategories = _mapper.Map<List<JobCategory>>(listOfJobCategories);
            return Ok(mappedListOfJobCategories);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<JobCategory>> GetJobCategory(int jobCategoryId)
        {
            var jobCategory = await _categoryRepository.GetByIdAsync(jobCategoryId);
            if (jobCategory == null)
            {
                _logger.Log(LogLevel.Information, $"requested job category id : {jobCategoryId} not found.");
                return NotFound($"requested job category with id : {jobCategoryId} not found.");
            }
            var mappedJobCategory = _mapper.Map<List<JobCategory>>(jobCategory);
            return Ok(mappedJobCategory);
        }
    }
}
