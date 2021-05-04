using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NoorsoftHomework.DataAccess.Interfaces;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Web.Resources.Shared;

namespace NoorsoftHomework.Web.Handlers.Employee.Commands
{
    public record DeleteEmployeeCommand(int Id) : IRequest<ApiResponse>;

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ApiResponse>
    {
        private readonly IMapper             _mapper;
        private readonly IEmployeeRepository _repository;

        public DeleteEmployeeCommandHandler(IMapper mapper, IEmployeeRepository repository)
        {
            _mapper     = mapper;
            _repository = repository;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var isSupervisorModel = _mapper.Map<IsEmployeeSupervisorModel>(request);
            var isSupervisor      = await _repository.IsSupervisor(isSupervisorModel);
            if (isSupervisor is true) return new ApiResponse(StatusCodes.Status409Conflict, null);
            
            var deleteModel = _mapper.Map<DeleteEmployeeModel>(request);
            await _repository.Delete(deleteModel);
            return new ApiResponse(StatusCodes.Status204NoContent, null);
        }
    }
}