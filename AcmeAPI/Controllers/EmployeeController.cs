using AcmeContracts;
using AcmeEntities.Models;
using AcmeEntities.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public EmployeeController(ILoggerManager logger,IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        [HttpHead]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _repository.Employee.GetAllEmployeesAsync();
                if (employees != null)
                {
                    var empDetails = _mapper.Map<List<EmployeeDetails>>(employees);
                    _logger.LogInfo($"Returned all employees from database.");
                    return Ok(employees);
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllEmployeesAsync action: {ex.Message}");     
            }
            return StatusCode(500, "Internal server error");
        }

        [HttpGet("{id}", Name = "EmployeeById")] 
        public async Task<IActionResult> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                var employee = await _repository.Employee.GetEmployeeByIdAsync(employeeId);
                if (employee != null)
                {
                    var empDetails = _mapper.Map<EmployeeDetails>(employee);
                    _logger.LogInfo($"Returned employee with id: {employeeId}");
                    return Ok(employee);
                }
                if (employee == null)
                {
                    _logger.LogError($"Employee with id: {employeeId}, hasn't been found in db.");   
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEmployeeByIdAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            return NotFound();
        }
        public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    _logger.LogError("em object sent from client is null.");
                    return BadRequest("Contact object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid contact object sent from client.");
                    return BadRequest("Invalid model object");

                }
                if (ModelState.IsValid)
                {

                }
                var empDetails = _mapper.Map<Employee>(employee);
                _repository.Employee.AddEmployee(employee);
                await _repository.SaveAsync();
                _logger.LogInfo("Added employee object sent from client.");


                return CreatedAtRoute("EmployeeById", new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddContact action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }        
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int Id, [FromBody]Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    _logger.LogError("Employee object sent from client is null.");
                    return BadRequest("Employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid employee object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var dbEmployee = await _repository.Employee.GetEmployeeByIdAsync(Id);
                if (dbEmployee == null)
                {
                    _logger.LogError($"Employee with id: {Id}, hasn't been found in db.");
                    return NotFound();
                }   
                    var empDetails = _mapper.Map<Employee>(employee);
                    _repository.Employee.UpdateEmployee(Id, employee);
                    await _repository.SaveAsync();
                    return NoContent();
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> DeleteEmployee(int Id, Employee employee)
        {
            try
            {
                var dbEmployee = await _repository.Employee.GetEmployeeByIdAsync(Id);
                if (dbEmployee == null)
                {
                    _logger.LogError($"Employee with id: {Id}, hasn't been found in db.");
                    return NotFound();
                }
                if (Id != 0)
                {
                    _repository.Employee.DeleteEmployee(employee);
                    await _repository.SaveAsync();
                  
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteContact action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            return Ok();
        }
    }
}