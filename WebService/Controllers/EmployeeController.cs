using AutoMapper;
using Domain;
using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.Employee;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public ActionResult<IQueryable<Employee>> Get()
    {
        return Ok(_employeeRepository.GetEmployees());
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        return Ok(_employeeRepository.GetEmployeeById(id));
    }

    [HttpPost]
    public ActionResult<NewCreatedEmployeeDto> CreateEmployee([FromBody] NewEmployeeDto newEmployee)
    {
        var employeeToCreate = new Employee
        {
            Name = newEmployee.Name
        };

        _employeeRepository.CreateEmployee(employeeToCreate);
        var createdResource = _mapper.Map<NewCreatedEmployeeDto>(newEmployee);
        createdResource.EmployeeId = employeeToCreate.EmployeeId;

        return CreatedAtAction(nameof(Get), new { id = createdResource.EmployeeId }, createdResource);
    }

    [HttpPut("{id}")]
    public ActionResult<UpdatedEmployeeDto> UpdateEmployee([FromBody] UpdatedEmployeeDto employeeToChange, int id)
    {
        var employeeToEdit = _employeeRepository.GetEmployeeById(id);

        if (id != employeeToChange.EmployeeId) return BadRequest();

        employeeToEdit!.Name = employeeToChange.Name;
        employeeToEdit.Email = employeeToChange.Email;
        employeeToEdit.CafeteriaId = employeeToChange.CafeteriaId;
        employeeToEdit.EmployeeId = employeeToChange.EmployeeId;
        employeeToEdit.LocationId = employeeToChange.LocationId;

        _employeeRepository.UpdateEmployee(employeeToEdit!);

        var editedResource = _mapper.Map<UpdatedEmployeeDto>(employeeToChange);

        return Ok(editedResource);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEmployee(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);
        _employeeRepository.DeleteEmployee(employee!);
        return new NoContentResult();
    }
}