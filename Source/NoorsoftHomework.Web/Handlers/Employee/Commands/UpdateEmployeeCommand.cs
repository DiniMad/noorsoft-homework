using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NoorsoftHomework.DataAccess.Interfaces;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Web.Resources;

namespace NoorsoftHomework.Web.Handlers.Employee.Commands
{
    public record UpdateEmployeeRequest(int Id, UpdateEmployeeResource Resource) : IRequest<ApiResponse>;

    public class UpdateEmployeeCommand : IRequestHandler<UpdateEmployeeRequest, ApiResponse>
    {
        private readonly IMapper             _mapper;
        private readonly IEmployeeRepository _repository;

        public UpdateEmployeeCommand(IMapper mapper, IEmployeeRepository repository)
        {
            _mapper     = mapper;
            _repository = repository;
        }

        public async Task<ApiResponse> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var updateModel = _mapper.Map<UpdateEmployeeModel>(request);
            await _repository.Update(updateModel);
            return new ApiResponse(StatusCodes.Status204NoContent, null);
        }
    }
}