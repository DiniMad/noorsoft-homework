using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoorsoftHomework.Web.Handlers.Employee.Commands;
using NoorsoftHomework.Web.Handlers.Employee.Queries;
using NoorsoftHomework.Web.Resources.Employee;
using NoorsoftHomework.Web.Resources.Shared;

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
        public async Task<ActionResult<ActionResultResource>> Get([FromQuery] SortingAndPagingResource resource)
        {
            var (statusCode, data) = await _sender.Send(new GetEmployeesQuery(resource));
            return StatusCode(statusCode, data);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ActionResultResource>> Update(int id, UpdateEmployeeResource resource)
        {
            var (statusCode, data) = await _sender.Send(new UpdateEmployeeCommand(id, resource));
            return StatusCode(statusCode, data);
        }

        [HttpPost]
        public async Task<ActionResult<ActionResultResource>> Add(AddEmployeeResource resource)
        {
            var (statusCode, data) = await _sender.Send(new AddEmployeeCommand(resource));
            return StatusCode(statusCode, data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActionResultResource>> Delete(int id)
        {
            var (statusCode, data) = await _sender.Send(new DeleteEmployeeCommand(id));
            return StatusCode(statusCode, data);
        }
    }
}