using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NoorsoftHomework.DataAccess.Interfaces;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Web.Resources.Employee;
using NoorsoftHomework.Web.Resources.Shared;

namespace NoorsoftHomework.Web.Handlers.Employee.Commands
{
    public record AddEmployeeCommand(AddEmployeeResource Resource) : IRequest<ActionResultResource>;

    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, ActionResultResource>
    {
        private readonly IMapper             _mapper;
        private readonly IEmployeeRepository _repository;

        public AddEmployeeCommandHandler(IMapper mapper, IEmployeeRepository repository)
        {
            _mapper     = mapper;
            _repository = repository;
        }

        public async Task<ActionResultResource> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var addModel         = _mapper.Map<AddEmployeeModel>(request);
            var employeeId       = await _repository.Add(addModel);
            var employeeResource = _mapper.Map<EmployeeResource>((employeeId, addModel));
            return new ActionResultResource(StatusCodes.Status201Created, employeeResource);
        }
    }
}