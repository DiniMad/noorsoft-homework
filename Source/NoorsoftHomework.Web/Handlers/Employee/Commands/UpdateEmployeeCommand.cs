using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NoorsoftHomework.DataAccess.Interfaces;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Web.Resources;
using NoorsoftHomework.Web.Resources.Employee;

namespace NoorsoftHomework.Web.Handlers.Employee.Commands
{
    public record UpdateEmployeeCommand(int Id, UpdateEmployeeResource Resource) : IRequest<ApiResponse>;

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ApiResponse>
    {
        private readonly IMapper             _mapper;
        private readonly IEmployeeRepository _repository;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository repository)
        {
            _mapper     = mapper;
            _repository = repository;
        }

        public async Task<ApiResponse> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var updateModel = _mapper.Map<UpdateEmployeeModel>(command);
            await _repository.Update(updateModel);
            return new ApiResponse(StatusCodes.Status204NoContent, null);
        }
    }
}