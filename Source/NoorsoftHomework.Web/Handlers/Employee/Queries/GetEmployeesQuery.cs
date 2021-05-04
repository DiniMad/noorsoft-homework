using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NoorsoftHomework.DataAccess.Interfaces;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Web.Helpers;
using NoorsoftHomework.Web.Resources.Employee;
using NoorsoftHomework.Web.Resources.Shared;

namespace NoorsoftHomework.Web.Handlers.Employee.Queries
{
    public record GetEmployeesQuery(SortingAndPagingResource Resource) : IRequest<ApiResponse>;

    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, ApiResponse>
    {
        private readonly IEmployeeRepository  _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper              _mapper;

        public GetEmployeesQueryHandler(IEmployeeRepository  repository,
                                        IHttpContextAccessor httpContextAccessor,
                                        IMapper              mapper)
        {
            _repository          = repository;
            _httpContextAccessor = httpContextAccessor;
            _mapper              = mapper;
        }

        public async Task<ApiResponse> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
        {
            var resource = query.Resource;

            var parameters = new GetEmployeesParameters(resource.SortColumn,
                                                        resource.SortDirection,
                                                        resource.Offset,
                                                        resource.PageSize);
            var employees = await _repository.Get(parameters);
            if (employees.Count is 0) return new ApiResponse(StatusCodes.Status404NotFound, null);
            
            var employeesCount = await _repository.Count();
            var url = _httpContextAccessor.HttpContext.GetUrl();
            var employeesResource = _mapper.Map<List<EmployeeResource>>(employees);
            var data = new DataCollection<EmployeeResource>(employeesResource, employeesCount, url, resource);

            return new ApiResponse(StatusCodes.Status200OK, data);
        }
    }
}