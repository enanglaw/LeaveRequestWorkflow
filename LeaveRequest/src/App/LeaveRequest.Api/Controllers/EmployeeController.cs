using AutoMapper;
using Azure.Core;
using LeaveRequest.Application.Contracts.Persistence;
using LeaveRequest.Application.Profiles.ViewModels;
using LeaveRequest.Domain.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LeaveRequest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository,IMapper mapper, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetEmployee(int id)
        {
           
                var employee = (await _employeeRepository.GetByIdAsync(id));
                if (employee == null)
                {
                _logger.Log(LogLevel.Information, $"requested employee id : {id} not found.");
                    return NotFound($"requested employee id : {id} not found.");
                }
                var mappedEmployee = _mapper.Map<Employee>(employee);

                return Ok(mappedEmployee);
           
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {

            var employee = (await _employeeRepository.ListAllAsync());
            if (employee == null)
            {
                return NotFound($"No registered employee records found.");
            }
            var mappedEmployee = _mapper.Map<List<Employee>>(employee);

            return Ok(mappedEmployee);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Employee>> CreateEmployees([FromBody] Employee employee)
        {
            var createdEmployee = new Employee();
            if (ModelState.IsValid)
            if (employee == null)
            {
                    ModelState.AddModelError("", $"Invalid input");
                }
            {
                 createdEmployee = await _employeeRepository.AddAsync(employee);
            }
            

            return Ok(createdEmployee);

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatetEmployees([FromBody] EmployeeVm employeeVm)
        {

            var employeeToUpdate = (await _employeeRepository.GetByIdAsync(employeeVm.EmployeeId));
            if (employeeToUpdate == null)
            {
                return NotFound($"No registered employee records found.");
            }
            _mapper.Map(employeeVm, employeeToUpdate, typeof(EmployeeVm), typeof(Employee));
            await _employeeRepository.UpdateAsync(employeeToUpdate);
           

            return NoContent();

        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employeeToDelete = await _employeeRepository.GetByIdAsync(id);
            if (employeeToDelete == null) return BadRequest($"No employee with Id : {id} found");
            await _employeeRepository.DeleteAsync(employeeToDelete);
            return NoContent();
        }
    }
}
