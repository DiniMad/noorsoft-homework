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
    public record UpdateEmployeeCommand(int Id, UpdateEmployeeResource Resource) : IRequest<ActionResultResource>;

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ActionResultResource>
    {
        private readonly IMapper             _mapper;
        private readonly IEmployeeRepository _repository;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository repository)
        {
            _mapper     = mapper;
            _repository = repository;
        }

        public async Task<ActionResultResource> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var updateModel = _mapper.Map<UpdateEmployeeModel>(command);
            await _repository.Update(updateModel);
            return new ActionResultResource(StatusCodes.Status200OK, null);
        }
    }
}