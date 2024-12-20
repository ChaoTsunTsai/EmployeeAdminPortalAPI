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

        // Get All employees method example
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

        // Post method example (Dto = Data Transfer Object)
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
        }
    }
}
