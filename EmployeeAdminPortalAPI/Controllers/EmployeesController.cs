using EmployeeAdminPortalAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        // Get method example
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _dbContext.Employees.ToList();

            // Return Https 200 with message allEmployees (List)
            return Ok(allEmployees);
        }
    }
}
