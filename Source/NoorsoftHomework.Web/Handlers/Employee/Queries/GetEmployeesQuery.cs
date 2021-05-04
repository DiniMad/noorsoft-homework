using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NoorsoftHomework.DataAccess.Interfaces;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Web.Helpers;
using NoorsoftHomework.Web.Resources;

namespace NoorsoftHomework.Web.Handlers.Employee.Queries
{
    public record SortingAndPagingOption(SortColumn    SortColumn,
                                         SortDirection SortDirection,
                                         int           PageSize   = 10,
                                         int           PageNumber = 1) : IRequest<ApiResponse>
    {
        public int Offset => (PageNumber - 1) * PageSize;
    }

    public class GetEmployeesQuery : IRequestHandler<SortingAndPagingOption, ApiResponse>
    {
        private readonly IEmployeeRepository  _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper              _mapper;

        public GetEmployeesQuery(IEmployeeRepository  repository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IMapper              mapper)
        {
            _repository          = repository;
            _httpContextAccessor = httpContextAccessor;
            _mapper              = mapper;
        }

        public async Task<ApiResponse> Handle(SortingAndPagingOption option, CancellationToken cancellationToken)
        {
            var parameters = new GetEmployeesParameters(option.SortColumn,
                                                        option.SortDirection,
                                                        option.Offset,
                                                        option.PageSize);
            var employees = await _repository.Get(parameters);
            if (employees.Count is 0) return new ApiResponse(StatusCodes.Status404NotFound, null);
            var employeesCount = await _repository.Count();
            var url = _httpContextAccessor.HttpContext.GetUrl();
            var employeesResource = _mapper.Map<List<EmployeeResource>>(employees);
            var data = new DataCollection<EmployeeResource>(employeesResource, employeesCount, url, option);

            return new ApiResponse(StatusCodes.Status200OK, data);
        }
    }
}