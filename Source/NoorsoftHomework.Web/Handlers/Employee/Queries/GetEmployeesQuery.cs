using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using NoorsoftHomework.DataAccess.Interfaces;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Web.Resources.Employee;
using NoorsoftHomework.Web.Resources.Shared;

namespace NoorsoftHomework.Web.Handlers.Employee.Queries
{
    public record GetEmployeesQuery(SortingAndPagingResource Resource) : IRequest<ActionResultResource>;

    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, ActionResultResource>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IUrlHelper          _urlHelper;
        private readonly IMapper             _mapper;

        public GetEmployeesQueryHandler(IEmployeeRepository    repository,
                                        IUrlHelperFactory      urlHelperFactory,
                                        IActionContextAccessor actionContextAccessor,
                                        IMapper                mapper)
        {
            _repository = repository;
            _urlHelper  = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
            _mapper     = mapper;
        }

        public async Task<ActionResultResource> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
        {
            var resource = query.Resource;

            var parameters = new GetEmployeesParameters(resource.SortColumn,
                                                        resource.SortDirection,
                                                        resource.Offset,
                                                        resource.PageSize);
            var employees = await _repository.Get(parameters);
            if (employees.Count is 0) return new ActionResultResource(StatusCodes.Status404NotFound, null);

            var employeesCount = await _repository.Count();
            var employeesResource = _mapper.Map<List<EmployeeResource>>(employees);
            var data = new DataCollection<EmployeeResource>(employeesResource, employeesCount, resource, _urlHelper);

            return new ActionResultResource(StatusCodes.Status200OK, data);
        }
    }
}