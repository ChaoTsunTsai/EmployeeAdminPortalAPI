using EmployeeAdminPortalAPI.Data;
using EmployeeAdminPortalAPI.Models;
using EmployeeAdminPortalAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortalAPI.Controllers
{
    // Url should be: localhost: xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // Private example
        private readonly ApplicationDbContext _dbContext;
        // Controller example
        public EmployeesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get All employees example
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _dbContext.Employees.AsNoTracking().ToList();

            if (allEmployees == null)
            {
                // return 404 Not Found
                return NotFound();
            }

            // Return Https 200 with message allEmployees (List)
            return Ok(allEmployees);
        }

        // Get employees by Id example
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeesById(Guid id)
        {
            var employees = _dbContext.Employees.Find(id);

            if (employees == null)
            {
                // return 404 Not Found
                return NotFound();
            }

            // Return Https 200 with message allEmployees (List)
            return Ok(employees);
        }

        // Post example (Dto = Data Transfer Object) (Add single data)
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            _dbContext.Employees.Add(employeeEntity);

            // Save change.(Same as COMMIT; in DB.)
            _dbContext.SaveChanges();

            return Ok(employeeEntity);
            // return CreatedAtAction(nameof(GetEmployeesById), new { id = employeeEntity.Id }, employeeEntity);
        }

        // Put example (Update single data)
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                // return 404 Not Found
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            _dbContext.SaveChanges();

            return Ok(employee);
        }

        // Delete example
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                // return 404 Not Found
                return NotFound();
            }

            _dbContext.Employees.Remove(employee);

            _dbContext.SaveChanges();

            return Ok(employee);
        }
    }
}