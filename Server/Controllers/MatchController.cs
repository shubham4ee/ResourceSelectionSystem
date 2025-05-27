using ResourceSelectionSystem.Models;
using ResourceSelectionSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ResourceSelectionSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public MatchController()
        {
            _employeeService = new EmployeeService();
        }

        [HttpPost]
        public IActionResult Match([FromBody] EmployeeMatchRequest request)
        {
            if (request == null || request.RequiredSkills == null)
                return BadRequest("Invalid request");

            var results = _employeeService.MatchEmployees(request);

            var response = results.Select(r => new
            {
                id = r.Employee.Id,
                name = r.Employee.Name,
                score = r.Score
            });

            return Ok(response);
        }
    }
}
