using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoorsoftHomework.Web.Handlers.Employee.Commands;
using NoorsoftHomework.Web.Handlers.Employee.Queries;
using NoorsoftHomework.Web.Resources;
using NoorsoftHomework.Web.Resources.Employee;

namespace NoorsoftHomework.Web.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender _sender;

        public EmployeeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get([FromQuery] SortingAndPagingResource resource)
        {
            var (statusCode, data) = await _sender.Send(new GetEmployeesQuery(resource));
            return StatusCode(statusCode, data);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ApiResponse>> Update(int id, UpdateEmployeeResource resource)
        {
            var (statusCode, data) = await _sender.Send(new UpdateEmployeeCommand(id, resource));
            return StatusCode(statusCode, data);
        }
    }
}