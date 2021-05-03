using System.Threading;
using System.Threading.Tasks;
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

        public GetEmployeesQuery(IEmployeeRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository          = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse> Handle(SortingAndPagingOption option, CancellationToken cancellationToken)
        {
            var parameters = new GetEmployeesParameters(option.SortColumn,
                                                        option.SortDirection,
                                                        option.Offset,
                                                        option.PageSize);
            var employees      = await _repository.Get(parameters);
            var employeesCount = await _repository.Count();
            var url            = _httpContextAccessor.HttpContext.GetUrl();
            var data           = new DataCollection<Model.Employee>(employees, employeesCount, url, option);
            
            return new ApiResponse(StatusCodes.Status200OK, data);
        }
    }
}